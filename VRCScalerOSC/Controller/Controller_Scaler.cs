using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using VRC.OSCQuery;
using VRCScalerOSC.Model;
using VRCScalerOSC.Model.SupportAvatarTool;
using VRCScalerOSC.Service;
using VRCScalerOSC.ViewModel;
namespace VRCScalerOSC.Controller
{
    public class Controller_Scaler
    {
        private readonly Service_VRCOSCQuery _serviceOSCQuery = new();
        private Service_VRCOSCProtocols? _serviceOSCProtocols;
        private OscEventCollection _actionAfterGetOSCData = new();
        public event Service_VRCOSCProtocols.EventHandler? OSCDataSanded
        {
            add
            {
                if (_serviceOSCProtocols != null && value != null)
                {
                    _serviceOSCProtocols.OSCDataSanded += value;
                }
            }
            remove
            {
                if (_serviceOSCProtocols != null && value != null)
                {
                    _serviceOSCProtocols.OSCDataSanded -= value;
                }
            }
        }
        public event Service_VRCOSCProtocols.EventHandler? OSCDataReceived
        {
            add
            {
                if (_serviceOSCProtocols != null && value != null)
                {
                    _serviceOSCProtocols.OSCDataReceived += value;
                }
            }
            remove
            {
                if (_serviceOSCProtocols != null && value != null)
                {
                    _serviceOSCProtocols.OSCDataReceived -= value;
                }
            }
        }
        private OSCQueryServiceProfile? _currentProfile = null;
        private ScaleData? _scaleData;
        private CancellationTokenSource _ctsScaler = new();
        private readonly System.Threading.Timer _scalerTimer;
        private readonly System.Threading.Timer _delayTimer;
        private readonly System.Threading.Timer _regularTimer;
        private readonly Dictionary<string, OSCData> _avatarOSCDatas = [];
        private volatile bool _isInitialized = false;
        private volatile bool _isInDelay = false;
        private SupportAvatarTool[]? _supportAvatarTool;

        public readonly string ScalerOSCPathPrefix;
        public ScalerSetting CustomSetting { get; set; }
        public ViewModel_Scaler ViewModelScaler { get; set; }
        public ViewModel_MCC ViewModelMCC { get; set; }
        public SupportAvatarTool[]? SupportAvatarTool
        {
            get
            {
                return _supportAvatarTool;
            }
            set
            {
                _supportAvatarTool = value;
                _actionAfterGetOSCData = new();
                InitOSCActions();
            }
        }

        public Controller_Scaler(ScalerSetting customSetting, ViewModel_Scaler viewModel, ViewModel_MCC? viewModelMCC = null)
        {
            ScalerOSCPathPrefix = customSetting.OSCPathPrefix;

            ViewModelMCC = viewModelMCC ?? new ViewModel_MCC();
            viewModel.SmoothScalingIterativeTimesPerSecond = customSetting.SmoothScalingIterativeTimesPerSecond;
            viewModel.ReceivePort = customSetting.ServerOSC_ReceivePort.ToString();
            viewModel.SendPort = customSetting.ServerOSC_SendPort.ToString();
            viewModel.IP = customSetting.ServerOSC_IP.ToString();

            viewModel.TargetEyeHeightList.Clear();
            viewModel.TargetEyeHeightList.AddRange(customSetting.FormTargetEyeHeightList);
            viewModel.ScalingRateDefaultList.Clear();
            viewModel.ScalingRateDefaultList.AddRange(customSetting.FormScalingRateList);
            viewModel.ScalingTimeDefaultList.Clear();
            viewModel.ScalingTimeDefaultList.AddRange(customSetting.FormScalingTimeList);

            CustomSetting = customSetting;
            ViewModelScaler = viewModel;
            SetFixedRate(customSetting.FormFixedRate);
            SetAutoAbort(customSetting.FormAutoAbort);
            SetMinEyeHeight(customSetting.MinHeight);
            SetMaxEyeHeight(customSetting.MaxHeight);
            if (viewModel.FixedRate)
            {
                SetScalingRate(customSetting.FormScalingRate);
            }
            else
            {
                SetScalingTime(customSetting.FormScalingTime);
            }
            InitMenuScaleValueList();

            _serviceOSCQuery.VRCDatareceived += OscQuery_OnGetVRCData;

            _scalerTimer = new System.Threading.Timer((state) =>
            {
                ShowChangeEyeHeightProcess();
            }, null, Timeout.Infinite, Timeout.Infinite);
            _delayTimer = new System.Threading.Timer((state) =>
            {
                _isInDelay = false;
            }, null, Timeout.Infinite, Timeout.Infinite);
            _regularTimer = new System.Threading.Timer(state =>
            {
                if (_serviceOSCProtocols?.SendTaskCount == 0)
                {
                    _serviceOSCProtocols?.SendOscMessage(new OSCData(Service_VRCOSCProtocols.RegularPingPath), false);
                }
            }, null, 1000, 1000);

            SupportAvatarTool = [
                new VRCScaler(this, ViewModelScaler),
                new RSSAdjOld(this, ViewModelScaler),
                new MagScaler(this, ViewModelScaler),
                new JackalAvatarScalerV3(this, ViewModelScaler),
                new MenuControlCamera(customSetting.OSCPathPrefixForMCC, ViewModelMCC)
            ];

            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public void Dispose()
        {
            if (_serviceOSCProtocols != null)
            {
                _serviceOSCProtocols.OSCDataSanded -= null;
                _serviceOSCProtocols.OSCDataReceived -= null;
            }
        }
        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModelScaler.IsInitialized) && ViewModelScaler.IsInitialized)
            {
                _isInitialized = ViewModelScaler.IsInitialized;
                Debug.WriteLine("IsInitialized");
            }
        }

        #region Init Scaler
        private void InitOSCActions()
        {
            _actionAfterGetOSCData.AddEvent("/avatar/change", (isInitialized, service, data) =>
            {
                Debug.WriteLine($"{data} IsInitialized={isInitialized}");
                if (isInitialized)
                {
                    _isInitialized = false;
                    ViewModelScaler.IsInitialized = false;
                    ViewModelScaler.RealHeightRatio = -1;
                    ViewModelScaler.ScalingPercentage = 0;
                    service?.IgnoreAddrListClear();
                    ReLoadVRCData();
                }
            });
            _actionAfterGetOSCData.AddEvent("/avatar/eyeheightscalingallowed", (isInitialized, service, data) =>
            {
                if (data.ValueB.HasValue && !data.ValueB.Value)
                {
                    ViewModelScaler.ScalerUnUsable = true;
                    service?.SendOscMessage(OSCData.GetTrueOSCData(ScalerOSCPathPrefix + "/ScalerUnUsable", "f"));
                }
                else if (data.ValueB.HasValue && data.ValueB.Value)
                {
                    ViewModelScaler.ScalerUnUsable = false;
                    service?.SendOscMessage(OSCData.GetFalseOSCData(ScalerOSCPathPrefix + "/ScalerUnUsable", "f"));
                }
            });
            _actionAfterGetOSCData.AddEvent("/avatar/parameters/ScaleFactor", (isInitialized, service, data) =>
            {
                if (data.ValueF.HasValue)
                {
                    ViewModelScaler.AvatarScaleFactor = data.ValueF.Value;
                    ViewModelScaler.AvatarDefaultEyeHeight = ViewModelScaler.CurrentEyeHeight / ViewModelScaler.AvatarScaleFactor;
                    if (!isInitialized)
                    {
                        DelayForAvatarParameterInit();
                    }
                }
            });
            _actionAfterGetOSCData.AddEvent("/avatar/parameters/EyeHeightAsMeters", (isInitialized, service, data) =>
            {
                if (data.ValueF.HasValue)
                {
                    ViewModelScaler.CurrentEyeHeight = data.ValueF.Value;
                    ViewModelScaler.AvatarDefaultEyeHeight = ViewModelScaler.CurrentEyeHeight / ViewModelScaler.AvatarScaleFactor;
                    if (!isInitialized)
                    {
                        DelayForAvatarParameterInit();
                    }
                }
            });

            if (_supportAvatarTool != null)
            {
                foreach (var supportScaler in _supportAvatarTool)
                {
                    supportScaler.InitOSCFunctions(this._actionAfterGetOSCData);
                }
            }
        }
        public void InitMenuScaleValueList()
        {
            for (int i = 0; i < CustomSetting.MenuScaleValueList.Count && (i + 1) < ViewModelScaler.DefaultHeightValueList.Count; i++)
            {
                ViewModelScaler.DefaultHeightValueList[i + 1] = CustomSetting.MenuScaleValueList[i];
            }
        }
        private void OscQuery_OnGetVRCData(OSCQueryServiceProfile? profile, List<OSCData> dataList)
        {
            if ((!_isInitialized || _currentProfile == null) && dataList.Count > 0)
            {
                _isInitialized = false;
                Debug.WriteLine($"OnGetVRCData {profile?.name ?? "null"} dataList={dataList.Count}");
                LoadVRCData(dataList);
                _currentProfile = profile;
                Debug.WriteLine("OscQuery_OnGetVRCData DelayForAvatarParameterInit");
                //DelayForAvatarParameterInit();
            }
            else if (profile != null && (_currentProfile == null || _currentProfile.name != profile.name) && dataList.Count > 0)
            {
                string avatarId = dataList.Find((data) => { return data.Addr == "/avatar/change"; })?.ValueString ?? "";
                if (_avatarOSCDatas.TryGetValue("/avatar/change", out OSCData? data) && data != null && avatarId == data.ValueString)
                {
                    _currentProfile = profile;
                }
            }

        }
        private void ReLoadVRCData()
        {
            if (_currentProfile != null)
            {
                if (_serviceOSCQuery.GetVRCInitOSCData(_currentProfile, out List<OSCData> dataList))
                {
                    Debug.WriteLine($"ReLoadVRCData {_currentProfile?.name ?? "null"} dataList={dataList.Count}");
                    LoadVRCData(dataList);
                }
            }
            Debug.WriteLine("ReLoadVRCData DelayForAvatarParameterInit");
            //DelayForAvatarParameterInit();
        }
        private void DelayForAvatarParameterInit()
        {

            System.Threading.Timer timer = new((state) =>
            {
                ViewModelScaler.IsInitialized = true;
                _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/AvatarDefaultHeight", "f", ViewModelScaler.AvatarDefaultEyeHeight));
            }, null, 2000, Timeout.Infinite);
        }
        private void LoadVRCData(List<OSCData> dataList)
        {
            _avatarOSCDatas.Clear();
            foreach (OSCData data in dataList)
            {
                SOSCProtocols_OnGetOSCData(_serviceOSCProtocols, data);
                _avatarOSCDatas.TryAdd(data.Addr.ToString(), data);
            }
        }
        #endregion

        #region Scaler control
        public void SetTargetEyeHeight(float eyeHeight)
        {
            ViewModelScaler.TargetEyeHeight = eyeHeight;
            ViewModelScaler.ScalingPercentage = 0;
            ViewModelScaler.ScalingCountdownSeconds = -1;
            if (MathF.Abs(ViewModelScaler.TargetEyeHeight - ViewModelScaler.CurrentEyeHeight) / ViewModelScaler.CurrentEyeHeight > 0.01f)
            {
                if (ViewModelScaler.FixedRate)
                {
                    SetScalingRate(ViewModelScaler.ScalingRate);
                }
                else
                {
                    SetScalingTime(ViewModelScaler.ScalingTime);
                }
            }
        }
        public void SetIsMultiplier(bool toggle)
        {
            if (ViewModelScaler.IsMultiplier != toggle)
            {
                ViewModelScaler.IsMultiplier = toggle;
            }
            if (ViewModelScaler.IsMultiplier)
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetTrueOSCData(ScalerOSCPathPrefix + "/IsMultiplier", "T"));
            }
            else
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetFalseOSCData(ScalerOSCPathPrefix + "/IsMultiplier", "F"));
            }
        }
        public void SetScalingTime(float scalingTime)
        {
            if (MathF.Abs(ViewModelScaler.ScalingTime - scalingTime) > 0.1f)
            {
                ViewModelScaler.ScalingTime = scalingTime;
                UpdateIterativeRateByTargetHeight(ViewModelScaler.TargetEyeHeight);
                _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/ScalingTimeValue", "f", ViewModelScaler.ScalingTime));
            }
        }
        public void SetScalingRate(float scalingRate)
        {
            scalingRate = scalingRate < 1f ? 1f : scalingRate > 10000f ? 10000f : scalingRate;
            if (MathF.Abs(ViewModelScaler.ScalingRate - scalingRate) > 0.01f)
            {
                ViewModelScaler.ScalingRate = scalingRate;
                ViewModelScaler.IterativeRate = MathF.Pow(scalingRate, 1.0f / ViewModelScaler.SmoothScalingIterativeTimesPerSecond);
                UpdateScalingTimeByTargetHeight(ViewModelScaler.TargetEyeHeight);
                _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/ScalingRateValue", "f", ViewModelScaler.ScalingRate));
            }
        }
        public void SetFixedRate(bool toggle)
        {
            if (ViewModelScaler.FixedRate != toggle)
            {
                ViewModelScaler.FixedRate = toggle;
            }
            if (ViewModelScaler.FixedRate)
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetTrueOSCData(ScalerOSCPathPrefix + "/SwitchFixedRate ", "T"));
            }
            else
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetFalseOSCData(ScalerOSCPathPrefix + "/SwitchFixedRate ", "F"));
            }
        }
        public void SetAutoAbort(bool toggle)
        {
            if (ViewModelScaler.AutoAbort != toggle)
            {
                ViewModelScaler.AutoAbort = toggle;
            }
            if (ViewModelScaler.AutoAbort)
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetTrueOSCData(ScalerOSCPathPrefix + "/SwitchAutoAbort", "T"));
            }
            else
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetFalseOSCData(ScalerOSCPathPrefix + "/SwitchAutoAbort", "F"));
            }
        }
        public void SetMaxEyeHeight(float eyeHeight)
        {
            eyeHeight = eyeHeight < 1f ? 1f : (eyeHeight > 10000f ? 10000f : eyeHeight);
            if (ViewModelScaler.MaxEyeHeight != eyeHeight)
            {
                ViewModelScaler.MaxEyeHeight = eyeHeight;
            }
            _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/MaxEyeHeightValue", "f", ViewModelScaler.MaxEyeHeight));
        }
        public void SetMinEyeHeight(float eyeHeight)
        {
            eyeHeight = eyeHeight < 0.01f ? 0.01f : (eyeHeight > 1f ? 1f : eyeHeight);
            if (ViewModelScaler.MinEyeHeight != eyeHeight)
            {
                ViewModelScaler.MinEyeHeight = eyeHeight;
            }
            _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/MinEyeHeightValue", "f", ViewModelScaler.MinEyeHeight));
        }
        public void SetGestureScaling(int mode)
        {
            if (mode < 0 || mode > 9)
            {
                return;
            }
            if (ViewModelScaler.GestureMode != mode)
            {
                ViewModelScaler.GestureMode = mode;
                _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/Gesture/Mode", "i", mode));
            }
            
            if (mode != 0)
            {
                _serviceOSCProtocols?.IgnoreAddrListRemove("#bundle");
            }
            ViewModelScaler.ShowGetWristInfoFailedLabel = mode > 0;
        }
        public void SetGestureMuteDoubleClickMode(bool toggle)
        {
            if (ViewModelScaler.DoubleClickMuteCanSetGesture != toggle)
            {
                ViewModelScaler.DoubleClickMuteCanSetGesture = toggle;
            }
            if (toggle)
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetTrueOSCData(ScalerOSCPathPrefix + "/Gesture/DoubleMuteSetGesture", "T"));
            }
            else
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetFalseOSCData(ScalerOSCPathPrefix + "/Gesture/DoubleMuteSetGesture", "F"));
            }
        }
        public void SetWorldScaling(bool toggle)
        {
            if (ViewModelScaler.WorldScaling != toggle)
            {
                ViewModelScaler.WorldScaling = toggle;
            }
            if (toggle)
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetTrueOSCData(ScalerOSCPathPrefix + "/Gesture/WorldScaling", "T"));
            }
            else
            {
                _serviceOSCProtocols?.SendOscMessage(OSCData.GetFalseOSCData(ScalerOSCPathPrefix + "/Gesture/WorldScaling", "F"));
            }
        }
        public void GestureScaling(float HandDistance)
        {
            if (float.IsNaN(HandDistance))
            {
                if (ViewModelScaler.GestureScalingEyeHeightInitial != -1 || ViewModelScaler.HandDistanceInitial != -1)
                {
                    StopScaling();
                    ViewModelScaler.GestureScalingEyeHeightInitial = -1f;
                    ViewModelScaler.HandDistanceInitial = -1f;
                }
            }
            else
            {
                if (ViewModelScaler.HandDistanceInitial == -1f)
                {
                    ViewModelScaler.HandDistanceInitial = HandDistance;
                    ViewModelScaler.GestureScalingEyeHeightInitial = ViewModelScaler.CurrentEyeHeight;
                }
                if (ViewModelScaler.WorldScaling)
                {
                    Debug.WriteLine(HandDistance.ToString());
                    if (HandDistance > 0.05f && ViewModelScaler.GestureScalingEyeHeightInitial > 0f)
                    {
                        Debug.WriteLine("WorldScaling");
                        StartScalingByTime(ViewModelScaler.GestureScalingEyeHeightInitial * ViewModelScaler.HandDistanceInitial / HandDistance, -1f);
                    }
                }
                else if (HandDistance - ViewModelScaler.HandDistanceInitial > 0.1)
                {
                    //Debug.WriteLine((HandDistance - ViewModel.HandDistanceInitial).ToString());
                    ScaleGrowUp(3 * (HandDistance - ViewModelScaler.HandDistanceInitial));
                }
                else if (HandDistance - ViewModelScaler.HandDistanceInitial < 0.1)
                {
                    //Debug.WriteLine((HandDistance - ViewModel.HandDistanceInitial).ToString());
                    ScaleShrinkDown(-3 * (HandDistance - ViewModelScaler.HandDistanceInitial));
                }
            }
        }
        public void ScaleGrowUp(float scalingRate)
        {
            scalingRate = scalingRate > 1f ? 1f : scalingRate < 0 ? 0 : scalingRate;
            if (scalingRate > 0.2f && ViewModelScaler.CurrentEyeHeight < 10000f)
            {
                if (scalingRate > 0.99f || MathF.Abs(ViewModelScaler.PrevScalingRate - scalingRate) > 0.2f)
                {
                    if (_isInitialized && _serviceOSCProtocols != null)
                    {
                        if (ViewModelScaler.CurrentTargetEyeHeight <= 1 || !ViewModelScaler.IsScalingRunning)
                        {
                            Debug.WriteLine($"ScaleGrowUp rate{scalingRate} StartScaling");
                            StartScaling(false, true, 10000f, -1f, 1.0f + 0.5f * (scalingRate - 0.2f) / 0.8f); //Grow Up to max
                        }
                        else if (ViewModelScaler.PrevScalingRate < 0.99f)
                        {
                            Debug.WriteLine($"ScaleGrowUp rate{scalingRate} UpdateIterativeRate");
                            _scaleData?.UpdateIterativeRate(MathF.Pow(1.0f + 0.5f * (scalingRate - 0.2f) / 0.8f, 1.0f / ViewModelScaler.SmoothScalingIterativeTimesPerSecond));
                        }
                    }
                    ViewModelScaler.PrevScalingRate = scalingRate;
                }
            }
            else
            {
                ViewModelScaler.PrevScalingRate = scalingRate;
                if (ViewModelScaler.IsScalingRunning)
                {
                    StopScaling();
                    _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/TargetEyeHeightValue", "f", 0f));
                }
            }
        }
        public void ScaleShrinkDown(float scalingRate)
        {
            scalingRate = scalingRate > 1f ? 1f : scalingRate < 0f ? 0f : scalingRate;
            if (scalingRate > 0.2f && ViewModelScaler.CurrentEyeHeight > 0.011f)
            {
                if (scalingRate > 0.99f || MathF.Abs(ViewModelScaler.PrevScalingRate - scalingRate) > 0.2f)
                {
                    if (_isInitialized && _serviceOSCProtocols != null)
                    {
                        if (ViewModelScaler.CurrentTargetEyeHeight >= 1 || !ViewModelScaler.IsScalingRunning)
                        {
                            Debug.WriteLine($"ScaleShrinkDown rate{scalingRate} StartScaling");
                            StartScaling(false, true, 0.01f, -1f, 1.0f - 0.5f * (scalingRate - 0.2f) / 0.8f); //Shrink Down to min
                        }
                        else if (ViewModelScaler.PrevScalingRate < 0.99)
                        {
                            Debug.WriteLine($"ScaleShrinkDown rate{scalingRate} UpdateIterativeRate");
                            _scaleData?.UpdateIterativeRate(MathF.Pow(1.0f - 0.5f * (scalingRate - 0.2f) / 0.8f, 1.0f / ViewModelScaler.SmoothScalingIterativeTimesPerSecond));
                        }
                    }
                    ViewModelScaler.PrevScalingRate = scalingRate;
                }
            }
            else
            {
                ViewModelScaler.PrevScalingRate = scalingRate;
                if (ViewModelScaler.IsScalingRunning)
                {
                    StopScaling();
                    _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/TargetEyeHeightValue", "f", 0f));
                }
            }

        }
        public void StartScalingInMultiplierByRate(float eyeHeight = -1f, float rate = float.MaxValue)
        {
            StartScaling(true, true, eyeHeight, 0f, rate);
        }
        public void StartScalingInMultiplierByTime(float eyeHeight = -1f, float time = 0f)
        {
            StartScaling(true, false, eyeHeight, time);
        }
        public void StartScalingInMetersByRate(float eyeHeight = -1f, float rate = float.MaxValue)
        {
            StartScaling(false, true, eyeHeight, 0f, rate);
        }
        public void StartScalingInMetersByTime(float eyeHeight = -1f, float time = 0f)
        {
            StartScaling(false, false, eyeHeight, time);
        }
        public void StartScalingByRate(float eyeHeight = -1f, float rate = float.MaxValue)
        {
            StartScaling(ViewModelScaler.IsMultiplier, true, eyeHeight, 0f, rate);
        }
        public void StartScalingByTime(float eyeHeight = -1f, float time = 0f)
        {
            StartScaling(ViewModelScaler.IsMultiplier, false, eyeHeight, time);
        }
        public void StartScaling(bool isMultiplier, bool fixedRate, float eyeHeight = -1f, float time = 0f, float rate = float.MaxValue)
        {
            if (!ViewModelScaler.IsOSCRunning || eyeHeight == 0 || _isInDelay)
            {
                return;
            }
            else if (eyeHeight == -1)
            {
                eyeHeight = 0;
            }

            if (eyeHeight == 0f)
            {
                if (_isInitialized)
                {
                    eyeHeight = ViewModelScaler.AvatarDefaultEyeHeight;
                }
                else
                {
                    eyeHeight = 1f;
                }
            }
            else if (isMultiplier)
            {
                eyeHeight *= ViewModelScaler.AvatarDefaultEyeHeight;
            }

            _ctsScaler?.Cancel();
            _scalerTimer.Change(Timeout.Infinite, Timeout.Infinite);
            ViewModelScaler.ScalingPercentage = 0;
            ViewModelScaler.ScalingCountdownSeconds = -1;
            ViewModelScaler.IsScalingRunning = false;
            ViewModelScaler.CurrentTargetEyeHeight = eyeHeight;

            OptimizationSmoothScalingIterativeTimes();

            float iterativeRate;
            if (fixedRate && rate < 10000 && rate > 0) // fixedRate with rate value
            {
                iterativeRate = MathF.Pow(rate, 1.0f / ViewModelScaler.SmoothScalingIterativeTimesPerSecond);
                if (time >= 0)
                {
                    UpdateScalingTimeByTargetHeight(eyeHeight);
                }
                time = CaculateScalingTimeByIterativeRate(iterativeRate, eyeHeight, ViewModelScaler.CurrentEyeHeight, ViewModelScaler.SmoothScalingIterativeTimesPerSecond);
            }
            else if (fixedRate) // fixedRate without rate value
            {
                iterativeRate = 1f;
            }
            else if (time > 0) //fixedTime with time value
            {
                iterativeRate = CaculateIterativeRateByTime(time, eyeHeight, ViewModelScaler.CurrentEyeHeight, ViewModelScaler.SmoothScalingIterativeTimesPerSecond);
                if (rate >= 0)
                {
                    UpdateIterativeRateByTargetHeight(eyeHeight);
                }
            }
            else //fixedTime without time value or time = 0
            {
                iterativeRate = 1f;
            }

            //Reverse iterativeRate for Shrink
            if (eyeHeight > ViewModelScaler.CurrentEyeHeight && iterativeRate < 1f || eyeHeight < ViewModelScaler.CurrentEyeHeight && iterativeRate > 1f)
            {
                iterativeRate = 1f / iterativeRate;
            }

            _scaleData = new ScaleData(
                eyeHeight,
                ViewModelScaler.CurrentEyeHeight,
                time,
                ViewModelScaler.AutoAbort,
                iterativeRate,
                ViewModelScaler.SmoothScalingIterativeTimesPerSecond,
                ViewModelScaler.MinEyeHeight,
                ViewModelScaler.MaxEyeHeight
                );

            if (isMultiplier)
            {
                _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/TargetEyeHeightValue", "f", _scaleData.HeightTarget / ViewModelScaler.AvatarDefaultEyeHeight));
            }
            else
            {
                _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/TargetEyeHeightValue", "f", _scaleData.HeightTarget));
            }
            ViewModelScaler.IsScalingRunning = true;
            _isInDelay = true;
            _delayTimer.Change(Convert.ToInt32(_scaleData.SmoothScalingIterativeTimeInterval), Timeout.Infinite);

            if (_scaleData.ScalingTime > 0.1)
            {
                _ctsScaler?.Cancel();
                _ctsScaler = new CancellationTokenSource();
                var tokenScaler = _ctsScaler.Token;
                Task.Run(() => DoChangeEyeHeight(tokenScaler), tokenScaler);
                _scalerTimer.Change(0, 100);
                _regularTimer.Change((int)time * 1000 + 5000, 1000);
            }
            else
            {
                FinalChangeEyeHeight(_scaleData.HeightTarget);
            }

        }
        public void StopScaling()
        {
            Debug.WriteLine("StopScaling");
            _ctsScaler?.Cancel();
            _scalerTimer.Change(Timeout.Infinite, Timeout.Infinite);
            ViewModelScaler.IsScalingRunning = false;
        }
        private void OptimizationSmoothScalingIterativeTimes()
        {
            float avgSenderTaskExecutionTime = 0f;
            if (_scaleData != null && _scaleData.RealScalingTime > 0)
            {
                avgSenderTaskExecutionTime = 1000f * _scaleData.RealScalingTime / _scaleData.ScalingTime / _scaleData.SmoothScalingIterativeTimesPerSecond;
            }
            Debug.WriteLine($"AvgSenderTaskExecutionTime {avgSenderTaskExecutionTime}");
            if (avgSenderTaskExecutionTime > 0f)
            {
                avgSenderTaskExecutionTime = avgSenderTaskExecutionTime > 60 ? 60f : avgSenderTaskExecutionTime < 20f ? 20f : avgSenderTaskExecutionTime;
                ViewModelScaler.SmoothScalingIterativeTimesPerSecond = 1000f / avgSenderTaskExecutionTime;
            }
        }
        private void UpdateIterativeRateByTargetHeight(float targetEyeHeight)
        {
            if (MathF.Abs(targetEyeHeight - ViewModelScaler.CurrentEyeHeight) / ViewModelScaler.CurrentEyeHeight > 0.01)
            {
                float prevValue = ViewModelScaler.IterativeRate;
                float newValue = CaculateIterativeRateByTime(ViewModelScaler.ScalingTime, targetEyeHeight, ViewModelScaler.CurrentEyeHeight, ViewModelScaler.SmoothScalingIterativeTimesPerSecond);
                if (MathF.Abs(prevValue - newValue) > 0.0001f)
                {
                    ViewModelScaler.IterativeRate = newValue;
                    ViewModelScaler.ScalingRate = MathF.Pow(ViewModelScaler.IterativeRate, ViewModelScaler.SmoothScalingIterativeTimesPerSecond);
                    Debug.WriteLine("{0:yyyy/MM/dd HH:mm:ss:fff} Set ScalingRate {1} => {2}", DateTime.Now, prevValue, ViewModelScaler.IterativeRate);
                    _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/ScalingRateValue", "f", ViewModelScaler.ScalingRate));
                }
            }
        }
        private void UpdateScalingTimeByTargetHeight(float targetEyeHeight)
        {
            if (MathF.Abs(targetEyeHeight - ViewModelScaler.CurrentEyeHeight) / ViewModelScaler.CurrentEyeHeight > 0.01f)
            {
                float prevValue = ViewModelScaler.ScalingTime;
                float newValue = CaculateScalingTimeByIterativeRate(ViewModelScaler.IterativeRate, targetEyeHeight, ViewModelScaler.CurrentEyeHeight, ViewModelScaler.SmoothScalingIterativeTimesPerSecond);
                if (MathF.Abs(prevValue - newValue) > 0.01f)
                {
                    ViewModelScaler.ScalingTime = newValue;
                    Debug.WriteLine("{0:yyyy/MM/dd HH:mm:ss:fff} Set ScalingTime {1} => {2}", DateTime.Now, prevValue, ViewModelScaler.ScalingTime);
                    _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/ScalingTimeValue", "f", ViewModelScaler.ScalingTime));
                }
                _serviceOSCProtocols?.SendOscMessage(new OSCData(ScalerOSCPathPrefix + "/ScalingRateValue", "f", ViewModelScaler.ScalingRate));
            }
        }
        public static float CaculateIterativeRateByTime(float time, float eyeheightTarget, float eyeheightCurrent, float smoothScalingIterativeTimesPerSecond)
        {
            float iterativeRate;
            if (time <= 0)
            {
                return 1f;
            }
            else
            {
                iterativeRate = MathF.Pow(eyeheightTarget / eyeheightCurrent, 1.0f / smoothScalingIterativeTimesPerSecond / time);
            }
            if ((iterativeRate > 1 && iterativeRate - 1 < 0.00000001) || (iterativeRate < 1 && 1 - iterativeRate < 0.00000001))
            {
                return 1f;
            }
            return iterativeRate;
        }
        public static float CaculateScalingTimeByIterativeRate(float iterativeRate, float eyeheightTarget, float eyeheightCurrent, float smoothScalingIterativeTimesPerSecond)
        {
            if (eyeheightCurrent == 0 || smoothScalingIterativeTimesPerSecond == 0)
            {
                return 0f;
            }
            return MathF.Abs(MathF.Log(eyeheightTarget / eyeheightCurrent, iterativeRate) / smoothScalingIterativeTimesPerSecond);
        }
        public static bool TryConvertFtInToMeters(string input, out float meters)
        {
            meters = 0f;

            if (string.IsNullOrWhiteSpace(input)) return false;

            input = input.Replace(" ", "");

            int feetSignCount = input.Split('\'').Length - 1;
            int inchSignCount = input.Split('"').Length - 1;
            if (feetSignCount > 1 || inchSignCount > 1) return false;

            if (feetSignCount == 0 && inchSignCount == 0) return false;

            string pattern = @"^(?:(?<ft>\d+(?:\.\d+)?)\')?(?:(?<in>\d+(?:\.\d+)?)"")?$";
            Match match = Regex.Match(input, pattern);

            if (!match.Success) return false;

            float feet = 0f;
            float inches = 0f;

            if (match.Groups["ft"].Success)
            {
                feet = float.Parse(match.Groups["ft"].Value);
            }

            if (match.Groups["in"].Success)
            {
                inches = float.Parse(match.Groups["in"].Value);
            }

            meters = (feet * 0.3048f) + (inches * 0.0254f);

            meters = MathF.Round(meters, 4);

            return true;
        }
        #endregion

        #region OSC Control
        public void OSCSetup()
        {
            _isInitialized = false;
            ViewModelScaler.IsInitialized = false;
            ViewModelScaler.ScalingPercentage = 0;
            if (_serviceOSCProtocols != null)
            {
                while (!_serviceOSCProtocols.Stop())
                {
                    Task.Delay(_serviceOSCProtocols.SendTaskDelay);
                }
                _serviceOSCProtocols.OSCDataReceived -= SOSCProtocols_OnGetOSCData;
                _serviceOSCProtocols.Dispose();
            }
            _currentProfile = null;
            _serviceOSCQuery.ProfileList.Clear();
            if (CustomSetting.UsingOSCQuery)
            {
                CustomSetting.ServerOSC_ReceivePort = _serviceOSCQuery.ReStart(IPAddress.Loopback, CustomSetting.ServerOSC_ReceivePort);
            }
            else if (CustomSetting.ServerOSC_ReceivePort == 0)
            {
                CustomSetting.ServerOSC_ReceivePort = 9001;
            }

            _serviceOSCProtocols = new Service_VRCOSCProtocols(CustomSetting.ServerOSC_IP.ToString(), CustomSetting.ServerOSC_SendPort, CustomSetting.ServerOSC_ReceivePort, CustomSetting.SendTaskDelay);
            ViewModelScaler.IP = CustomSetting.ServerOSC_IP.ToString();
            ViewModelScaler.ReceivePort = CustomSetting.ServerOSC_ReceivePort.ToString();
            ViewModelScaler.SendPort = CustomSetting.ServerOSC_SendPort.ToString();
            _serviceOSCProtocols.OSCDataReceived -= SOSCProtocols_OnGetOSCData;
            _serviceOSCProtocols.OSCDataReceived += SOSCProtocols_OnGetOSCData;
            OSCStart();
        }
        public void OSCStart()
        {
            _serviceOSCProtocols?.Start();
            ReLoadVRCData();
            ViewModelScaler.IsOSCRunning = true;
        }
        public void OSCStop()
        {
            _serviceOSCProtocols?.Stop();
            _serviceOSCQuery.Stop();
            _ctsScaler?.Cancel();
            _scalerTimer.Change(Timeout.Infinite, Timeout.Infinite);
            ViewModelScaler.IsOSCRunning = false;
        }
        #endregion

        #region OSC Scaling
        private void SOSCProtocols_OnGetOSCData(Service_VRCOSCProtocols? service, OSCData data)
        {
            if (_actionAfterGetOSCData.TryExecuteEvent(data.Addr, _isInitialized, service, data))
            {
                return;
            }
            else if (!_isInitialized && _supportAvatarTool != null)
            {
                foreach (var supportScaler in _supportAvatarTool)
                {
                    Action<bool, Service_VRCOSCProtocols?, OSCData>? newAction = supportScaler.TryAddNewFunction(data);
                    if (newAction != null)
                    {
                        _actionAfterGetOSCData.AddEvent(data.Addr, newAction);
                        newAction(_isInitialized, service, data);
                        return;
                    }
                }
            }
            _serviceOSCProtocols?.IgnoreAddrListAdd(data);
        }

        private async Task DoChangeEyeHeight(CancellationToken ct)
        {
            if (_scaleData == null)
            {
                return;
            }
            using PeriodicTimer timer = new(TimeSpan.FromMilliseconds(_scaleData.SmoothScalingIterativeTimeInterval));
            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                long t = 0;
                long d = 0;
                long timeInterval = (long)_scaleData.SmoothScalingIterativeTimeInterval;
                float eyeHeight;
                while (!ct.IsCancellationRequested && await timer.WaitForNextTickAsync(ct))
                {
                    if (_scaleData == null)
                    {
                        return;
                    }
                    eyeHeight = _scaleData.NextEyeheight;
                    t = sw.ElapsedMilliseconds;
                    d += timeInterval;
                    while (d < t)
                    {
                        eyeHeight = _scaleData.NextEyeheight;
                        d += timeInterval;

                    }
                    if (MathF.Abs(_scaleData.HeightOrginal - _scaleData.HeightTarget) < 0.0000001f ||
                        MathF.Abs(_scaleData.HeightOrginal - _scaleData.HeightTarget) / _scaleData.HeightOrginal < 0.01f)
                    {
                        FinalChangeEyeHeight(eyeHeight);
                        _scaleData.RealScalingTime = 0;
                        return;
                    }
                    else if (_isInitialized && _scaleData.AutoAbort && MathF.Abs(eyeHeight - ViewModelScaler.CurrentEyeHeight * _scaleData.IterativeRate) / eyeHeight > 0.1f)
                    {
                        _scaleData.IsAutoAbort = true;
                        FinalChangeEyeHeight(eyeHeight, true);
                        _scaleData.RealScalingTime = 0;
                        return;
                    }
                    else if (_scaleData.IsFinish)
                    {
                        FinalChangeEyeHeight(eyeHeight);
                        return;
                    }
                    else
                    {
                        DoChangeEyeHeight(eyeHeight);
                    }
                    if (_scaleData.IsFinish && MathF.Abs(_scaleData.HeightTarget - eyeHeight) > 0.0001)
                    {
                        FinalChangeEyeHeight(eyeHeight);
                        return;
                    }
                }
            }
            catch (OperationCanceledException) { }
        }
        private void DoChangeEyeHeight(float eyeHeight)
        {
            if (_scaleData == null)
            {
                return;
            }
            //int processValue = Convert.ToInt32(
            //        MathF.Log(eyeHeight / _scaleData.HeightOrginal, _scaleData.IterativeRate) * 100f /
            //        MathF.Log(_scaleData.HeightTarget / _scaleData.HeightOrginal, _scaleData.IterativeRate)); ;
            //int ScalingCountdownSeconds = Convert.ToInt32(_scaleData.ScalingTime -
            //    MathF.Log(eyeHeight / _scaleData.HeightOrginal, _scaleData.IterativeRate) * _scaleData.ScalingTime /
            //    MathF.Log(_scaleData.HeightTarget / _scaleData.HeightOrginal, _scaleData.IterativeRate));

            //ViewModelScaler.ScalingPercentage = processValue > 100 ? 100 : processValue < 0 ? 0 : processValue;
            //ViewModelScaler.ScalingCountdownSeconds = ScalingCountdownSeconds;

            eyeHeight = Math.Clamp(eyeHeight, _scaleData.HeightMin, _scaleData.HeightMax);
            Debug.WriteLine("{0:yyyy/MM/dd HH:mm:ss:fff} Send {1}: {2:0.0000} Task={3}", DateTime.Now, "/avatar/eyeheight", eyeHeight, _serviceOSCProtocols?.SendTaskCount);
            _serviceOSCProtocols?.SendOscMessage(OSCData.GetEyeHeightByteArray(eyeHeight));
        }
        private void FinalChangeEyeHeight(float eyeHeight, bool isAutoAbort = false)
        {
            if (_scaleData == null)
            {
                return;
            }
            eyeHeight = Math.Clamp(eyeHeight, _scaleData.HeightMin, _scaleData.HeightMax);
            float realScalingTime = _scaleData.RealScalingTime;
            _scaleData.RealScalingTime = realScalingTime;
            Debug.WriteLine("{0:yyyy/MM/dd HH:mm:ss:fff} Send {1}: {2:0.0000} Task={3} {4}",
                DateTime.Now,
                "/avatar/eyeheight",
                eyeHeight,
                _serviceOSCProtocols?.SendTaskCount,
                isAutoAbort ? $"(Auto-Abort)\neyeHeight {eyeHeight}\nCurrent * Multiplier {ViewModelScaler.CurrentEyeHeight * _scaleData.IterativeRate}\n(eyeHeight-Current * Multiplier)/eyeHeight {MathF.Abs(eyeHeight - ViewModelScaler.CurrentEyeHeight * _scaleData.IterativeRate) / eyeHeight} " : $"(Finish)\nIterativeTimesPerSecond: {_scaleData.SmoothScalingIterativeTimesPerSecond}\nIterativeTime: {_scaleData.SmoothScalingIterativeTimeInterval:0.00}ms\nScalingTime: {_scaleData.ScalingTime:0.###}s\nRealScalingTime: {realScalingTime:0.###}s"
                );
            _serviceOSCProtocols?.SendOscMessage(OSCData.GetEyeHeightByteArray(eyeHeight));
            _ctsScaler?.Cancel();
            _scalerTimer.Change(Timeout.Infinite, Timeout.Infinite);
            ViewModelScaler.ScalingPercentage = isAutoAbort ? 0 : 100;
            ViewModelScaler.ScalingCountdownSeconds = 0;
            ViewModelScaler.IsScalingRunning = false;
        }
        private void ShowChangeEyeHeightProcess()
        {
            if (_scaleData == null)
            {
                _scalerTimer.Change(Timeout.Infinite, Timeout.Infinite);
                return;
            }
            if (MathF.Abs(_scaleData.HeightOrginal - _scaleData.HeightTarget) < 0.0000001f ||
                MathF.Abs(_scaleData.HeightOrginal - _scaleData.HeightTarget) / _scaleData.HeightOrginal < 0.01f ||
                _scaleData.AutoAbort && MathF.Abs(_scaleData.HeightNow - ViewModelScaler.CurrentEyeHeight * _scaleData.IterativeRate) / _scaleData.HeightNow > 0.1f ||
                _scaleData.IsFinish
                )
            {
                return;
            }
            float processValue =
                    MathF.Log(_scaleData.HeightNow / _scaleData.HeightOrginal, _scaleData.IterativeRate) * 100f /
                    MathF.Log(_scaleData.HeightTarget / _scaleData.HeightOrginal, _scaleData.IterativeRate);
            float ScalingCountdownSeconds = _scaleData.ScalingTime -
                MathF.Log(_scaleData.HeightNow / _scaleData.HeightOrginal, _scaleData.IterativeRate) * _scaleData.ScalingTime /
                MathF.Log(_scaleData.HeightTarget / _scaleData.HeightOrginal, _scaleData.IterativeRate);

            ViewModelScaler.ScalingPercentage = Math.Clamp((int)processValue, 0, 100);
            ViewModelScaler.ScalingCountdownSeconds = (int)ScalingCountdownSeconds;
        }

        #endregion
    }
}
