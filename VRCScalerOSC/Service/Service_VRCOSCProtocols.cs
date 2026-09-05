using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Hashing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using VRCScalerOSC.Model;

namespace VRCScalerOSC.Service
{
    public class Service_VRCOSCProtocols : IDisposable
    {
        private UdpClient? _udpReceive;
        private CancellationTokenSource? _ctsReceive;
        private CancellationTokenSource? _ctsProcess;
        private CancellationTokenSource? _ctsSend;
        private readonly Channel<OSCDataEventArgs> _channelReceiveTask;
        private readonly Channel<OSCDataEventArgs> _channelSendTask;
        private readonly int _sendTaskDelay = 5;
        private HashSet<ulong> _ignoreAddrList = [];
        private readonly Dictionary<string, OSCData> _ignoreAddrListTemp = [];
        public static readonly byte[] RegularPingPath = "/avatar/parameters/VRCScaleOSC/RegularPing\0\0,f\0\0\0\0\0\0"u8.ToArray();

        public int SendTaskDelay
        {
            get { return _sendTaskDelay; }
        }
        public int SendTaskCount
        {
            get { return _channelSendTask.Reader.Count; }
        }
        public class OSCDataEventArgs : EventArgs
        {
            public byte[] Data { get; init; } = [];
            public IPEndPoint? EndPoint { get; init; } = null;
            public DateTime Timestamp { get; init; }
        }
        public delegate void EventHandler(Service_VRCOSCProtocols service, OSCData data);
        public event EventHandler? OSCDataReceived;
        public event EventHandler? OSCDataSanded;

        private IPAddress RemoteIp { get; set; }
        private IPAddress LocalIp { get; set; }
        private int SendPort { get; set; }
        private int ListenPort { get; set; }
        private readonly IPEndPoint? SendPEndPoint;

        public bool IsActive = false;
        private readonly ConcurrentDictionary<ulong, ulong> _tempCache = new();
        public Service_VRCOSCProtocols(string RemoteIp = "", int SendPort = 9000, int ListenPort = 9001, int SendTaskDelay = 5)
        {
            _channelReceiveTask = Channel.CreateBounded<OSCDataEventArgs>(new BoundedChannelOptions(1000) { FullMode = BoundedChannelFullMode.DropNewest });
            _channelSendTask = Channel.CreateBounded<OSCDataEventArgs>(new BoundedChannelOptions(1000) { FullMode = BoundedChannelFullMode.DropNewest });
            _sendTaskDelay = SendTaskDelay;
            _tempCache = [];
            LocalIp = IPAddress.Any;
            if (IPAddress.TryParse(RemoteIp, out IPAddress? oRemoteIp))
            {
                this.RemoteIp = oRemoteIp;
            }
            else
            {
                this.RemoteIp = IPAddress.Parse("127.0.0.1");
            }
            SendPEndPoint = new IPEndPoint(this.RemoteIp, SendPort);
            SetIpAndPort(this.RemoteIp, SendPort, ListenPort);
        }

        #region OSC setting
        private void SetIpAndPort(IPAddress? aRemoteIp = null, int aSendPort = 9000, int aListenPort = 9001)
        {
            aRemoteIp ??= IPAddress.Parse("127.0.0.1");
            RemoteIp = aRemoteIp;
            SendPort = aSendPort;
            ListenPort = aListenPort;
            if (SendPEndPoint != null)
            {
                SendPEndPoint.Address = RemoteIp;
                SendPEndPoint.Port = SendPort;
            }
        }


        public bool Start()
        {
            if (IsActive)
            {
                Stop();
            }
            _udpReceive = new UdpClient();
            _udpReceive.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            _udpReceive.Client.Bind(new IPEndPoint(LocalIp, ListenPort));

            RunSender();
            RunReceiverProcess();
            RunReceiverListen();

            IsActive = true;
            Debug.WriteLine("OSC Protocol Start");
            return IsActive;
        }
        public void RunReceiverListen()
        {
            _ctsReceive?.Cancel();
            _ctsReceive = new CancellationTokenSource();
            var tokenReceive = _ctsReceive.Token;
            Task.Run(() => ReceiverListenAsync(tokenReceive), tokenReceive);
        }
        public void RunReceiverProcess()
        {
            _ctsProcess?.Cancel();
            _ctsProcess = new CancellationTokenSource();
            var tokenProcess = _ctsProcess.Token;
            Task.Run(() => ReceiverProcessAsync(tokenProcess), tokenProcess);
        }
        public void RunSender()
        {
            _ctsSend?.Cancel();
            _ctsSend = new CancellationTokenSource();
            var tokenSend = _ctsSend.Token;
            Task.Run(() => SenderAsync(tokenSend), tokenSend);
        }

        public bool Stop()
        {
            if (IsActive)
            {
                _ctsReceive?.Cancel();
                _ctsProcess?.Cancel();
                _ctsSend?.Cancel();
                _udpReceive?.Close();
                _udpReceive?.Dispose();
                IsActive = false;
                while (_channelReceiveTask.Reader.TryRead(out _)) { }
                while (_channelSendTask.Reader.TryRead(out _)) { }
                Debug.WriteLine("OSC Protocol Stop");
            }

            return !IsActive;
        }

        public void Dispose()
        {
            Stop();
        }

        private void IgnoreAddrListUpdate()
        {
            if (_ignoreAddrListTemp != null)
            {
                _ignoreAddrList = _ignoreAddrListTemp.Keys.ToList()
                    .Select(p => XxHash64.HashToUInt64(Encoding.UTF8.GetBytes(p)))
                    .ToHashSet();
                _tempCache?.Clear();
            }
        }
        public bool IgnoreAddrListContainsKey(string addr)
        {
            if (string.IsNullOrEmpty(addr))
            {
                return false;
            }
            return _ignoreAddrListTemp.ContainsKey(addr);
        }
        public void IgnoreAddrListAdd(OSCData data, string addr = "")
        {
            if (addr == "")
            {
                addr = data.Addr.ToString();
            }
            if (_ignoreAddrListTemp.TryAdd(addr, data))
            {
                IgnoreAddrListUpdate();
            }
        }

        public void IgnoreAddrListRemove(string addr)
        {
            if (_ignoreAddrListTemp.Remove(addr))
            {
                IgnoreAddrListUpdate();
            }
        }
        public void IgnoreAddrListRemoveByKeyWord(string keyWord)
        {
            if (string.IsNullOrEmpty(keyWord))
            {
                return;
            }
            List<string> removeItem = [];
            foreach (var key in _ignoreAddrListTemp.Keys)
            {
                if (key.Contains(keyWord))
                {
                    removeItem.Add(key);
                }
            }
            foreach (var item in removeItem)
            {
                _ignoreAddrListTemp.Remove(item);
            }
            if (removeItem.Count > 0)
            {
                IgnoreAddrListUpdate();
            }
        }
        public void IgnoreAddrListClear()
        {
            _ignoreAddrListTemp?.Clear();
            IgnoreAddrListUpdate();
            _tempCache?.Clear();
        }

        public OSCData[] IgnoreAddrListToArray()
        {
            return [.. _ignoreAddrListTemp.Values];
        }
        #endregion

        #region OSC receiver
        private async Task ReceiverListenAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested && _udpReceive != null && _channelReceiveTask != null)
            {
                try
                {
                    var result = await _udpReceive.ReceiveAsync(ct);
                    int nullIndex = result.Buffer.AsSpan().IndexOf((byte)0);
                    if (nullIndex < 0)
                    {
                        continue;
                    }
                    ulong pathHash = XxHash64.HashToUInt64(result.Buffer.AsSpan()[..nullIndex]);
                    lock (_ignoreAddrList)
                    {
                        if (_ignoreAddrList.Contains(pathHash))
                        {
                            continue;
                        }
                    }
                    ulong dataHash = XxHash64.HashToUInt64(result.Buffer.AsSpan()[nullIndex..]);
                    lock (_tempCache)
                    {
                        if (!_tempCache.TryAdd(pathHash, dataHash))
                        {
                            if (_tempCache[pathHash] == dataHash)
                            {
                                continue;
                            }
                            _tempCache[pathHash] = dataHash;
                        }
                    }
                    await _channelReceiveTask.Writer.WriteAsync(new OSCDataEventArgs()
                    {
                        Data = result.Buffer,
                        EndPoint = result.RemoteEndPoint,
                        Timestamp = DateTime.Now
                    }, ct);
                }
                catch (OperationCanceledException)
                {
                    Debug.WriteLine("ReceiverListen Stop");
                    break;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"UpdListenError: {ex.Message}");
                    try
                    {
                        await Task.Delay(2000, ct);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }
        }
        private async Task ReceiverProcessAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested && _channelReceiveTask != null)
            {
                try
                {
                    await foreach (var item in _channelReceiveTask.Reader.ReadAllAsync(ct))
                    {
                        if (OSCDataReceived != null)
                        {
                            OSCData oOSCData = new(item.Data);
                            if (!oOSCData.VOID)
                            {
                                OSCDataReceived.Invoke(this, oOSCData);
                            }
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    Debug.WriteLine("DataProcess Stop");
                    break;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"DataProcessError: {ex.Message}");
                    try
                    {
                        await Task.Delay(2000, ct);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }
        }
        #endregion

        #region OSC Sender
        private async Task SenderAsync(CancellationToken ct)
        {
            using UdpClient udpSend = new();
            using PeriodicTimer periodicTimer = new(TimeSpan.FromMilliseconds(SendTaskDelay));
            Stopwatch sw = Stopwatch.StartNew();
            while (!ct.IsCancellationRequested && _channelSendTask != null)
            {
                try
                {
                    await foreach (var item in _channelSendTask.Reader.ReadAllAsync(ct))
                    {
                        if (item.Data.Length > 0)
                        {
                            await periodicTimer.WaitForNextTickAsync(ct);
                            await udpSend.SendAsync(item.Data, item.Data.Length, item.EndPoint);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    Debug.WriteLine("UpdSend Stop");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"UpdSendError: {ex.Message}");
                    try
                    {
                        await Task.Delay(2000, ct);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }
            udpSend.Dispose();
        }
        public bool SendOscMessage(byte[] Message)
        {
            if (IsActive && Message.Length != 0)
            {
                try
                {
                    int retryTimes = 3;
                    while (retryTimes > 0 && !_channelSendTask.Writer.TryWrite(new OSCDataEventArgs
                    {
                        Data = Message,
                        EndPoint = SendPEndPoint,
                        Timestamp = DateTime.Now
                    }))
                    {
                        retryTimes -= 1;
                    }
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Send OSC Message Error");
                    return false;
                }
            }
            else
            {
                Debug.WriteLine($"Convert To OSC Array Error");
            }
            return true;
        }
        public bool SendOscMessage(OSCData aData, bool debug = true)
        {
            if (aData.Message.Length != 0)
            {
                try
                {
                    int retryTimes = 3;
                    while (retryTimes > 0 && !_channelSendTask.Writer.TryWrite(new OSCDataEventArgs
                    {
                        Data = aData.Message,
                        EndPoint = SendPEndPoint,
                        Timestamp = DateTime.Now
                    }))
                    {
                        retryTimes -= 1;
                    }
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Send OSC Message Error");
                    return false;
                }
                if (debug)
                {
                    Debug.WriteLine("{0:yyyy/MM/dd HH:mm:ss:fff} Send {1}: {2}", DateTime.Now, aData.Addr.ToString(), aData.ValueString);
                    OSCDataSanded?.Invoke(this, aData);
                }
            }
            else
            {
                Debug.WriteLine($"Convert To OSC Array Error");
            }
            return true;
        }

        #endregion
    }
}
