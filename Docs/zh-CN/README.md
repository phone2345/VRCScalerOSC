# **VRC Scaler OSC 说明书**  

## **一、简介**  

VRC Scaler OSC 是用于改变VRChat中avatar身高的工具应用程式，经由向VRChat发送OSC封包，可让avatar在不安装任何插件(gimmick)的情况下运作，理论上能够修改所有avatar的身高。  

### **1.1 主要特色**  

* 在允许范围内任意修改avatar身高，可选择立即改变或平滑变化，身高数值单位可用米、倍数、增减百分比等方式输入，输入英尺与英吋将自动转换为米。  
* 支持手势改变身高功能，包含经典的`缩放世界`模式，可选择不同手势搭配或停用。  
* 有中英日韩介面，以及win64与linux64版本可选用。  
* 可以透过特定名称的avatar参数控制，具有开发avatar选单控制插件可能性。  

### **1.2 程式版本**  

* 程式以C\#撰写，使用自主开发的OSC封包处理套件及[VRC OSC Query](https://github.com/vrchat-c​​ommunity/vrc-oscquery-lib)  
* 桌面(Windows)版本: 中英日韩介面，适用于Windows 10以上作业系统  
* 命令列(Console)版本: 英文介面，适用于Windows 及Linux 64位元作业系统  
* 预计以MIT授权开源，若使用的系统不支援可自行从原始码编译或改写。  

### **1.3 快速入门指南**  

PC模式：  
1. 执行VRCScalerOSC\_Windows.exe  
2. 确认视窗下方的目前身高后方有出现目前avatar身高数值  
3. 选择或输入要缩放的模型身高  
4. 点`进行缩放`按钮  

![image](image/img1.3.1.png)  
![image](image/img1.3.2.png)  

VR模式：  
1. 执行VRCScalerOSC\_Windows.exe  
2. 进入VRChat，确认已开启`OSC`与`通过OSC共享头显和手柄信息`  
3. 双手控制器按下抓握键后再按两下麦克风键，开启以抓握键的手势缩放功能  
4. 双手按住抓握键，两手远离身高就会逐渐变高，两手靠近身高就会逐渐缩小  

### **1.4 常见问题**  

* 为什么无法改变身高?  
A: 请先确认于VRChat中有开启OSC功能。  

* 为什么应用程式画面中的avatar身高资讯不会更新?  
A: 请检查接收port是否已被占用或有防火墙/防毒软体封锁网路功能。若使用VRChat一体机版本(Quest, Pico)，目前VRC Scaler OSC尚无法接收到这些版本中的OSC封包，仅能对其发送OSC封包，因此显示当前状态、手势缩放与透过VRChat选单控制VRC Scaler OSC的功能将无法正常使用。  

* VRC Scaler OSC会与其他OSC工具冲突吗?  
A: VRC Scaler OSC使用VRC OSC Query及随机接收port功能来避免port冲突。若VRC OSC Query无法正常运作，则可以使用OSC封包分配转发工具来处理冲突，例如[VOR](https://github.com/SutekhVRC/VOR)，但依赖VRC OSC Query的手势缩放功能可能无法正常运作。  

* 为什么手势缩放功能无法正常使用?  
A: 请先确认画面中的avatar身高资讯是否会随身高改变更新，若可正常更新但依然无法使用手势缩放，则可能是未在设定画面中开启`通过OSC共享头显和手柄信息`，或是VRC OSC Query无法正常运作。  

* 如果安装或使用VRC Scaler OSC遇到问题，我该如何寻求协助?  
A: 请于发布VRC Scaler OSC的网站或Discord频道寻求作者协助。  

### **1.5 关联商品**  

5. Real Size Scale Adjuster (RSSAdj) v2，以VRC Scaler OSC为基础的avatar插件，让玩家在VRChat中透过选单修改身高。  
6. Menu Control Camera (MCC)，利用OSC发送VRC相机指令功能，让玩家能用选单选项调整相机设定与拍照，以解决avatar尺寸过大时难以控制相机的问题。 Lite版本已整合在RSSAdj v2中。  

## **二、功能介绍**  

本章大部分说明以桌面(Windows)版本为主，命令列(Conlose)版本请参阅2.8节。在使用前，请先确保有开启VRChat中的OSC功能，并且在VRChat的设定选单中已开启`通过OSC共享头显和手柄信息`。  

![image](image/img2.0.1.png)  
![image](image/img2.0.2.png)  

### **2.1 视窗设定**  

介面语言将自动跟随电脑作业系统语言，若系统非中文，日文，韩文，则以英文版为主。若需要自行切换，请点击`Lang.`按钮并选择语言。  

![image](image/img2.1.1.png)  

如果您的桌面解析度很高并且显示的比例为100%，导致视窗看起来过小，可以点击`大小`按钮进行修改，最多可放大到4倍(长宽为2倍)。  

![image](image/img2.1.2.png)  

点选`精简模式`将以固定身高数值的控制面板取代原视窗画面，可让用户更直接的透过不同身高数值的按钮改变身高。详细内容请参阅2.8节。  

### **2.2 身高调整**  

从左上角`模型身高`中直接输入身高，再按`进行缩放`即可改变身高。按`▼`将开启预设身高选单，可从中快速选择身高。点击`回到预设身高`将立刻恢复成avatar上传时的预设身高。  

![image](image/img2.2.1.png)  

`模型身高`中的单位可选`米`或`倍`，若选择`倍`代表输入的数值为avatar预设身高的倍数。如果想要以当前身高为基础进行计算，请输入百分比数字并于结尾加上%符号并按`enter`键，输入值将会以当前身高百分比自动转换。若输入值开头为 \+ 或 \- 符号，转换结果将再加上当前身高。  

`模型身高`栏位另有自动转换英尺英吋功能，以便于习惯英制单位的用户输入尺寸。当输入的数值带有 " 或 ' 符号的字串时，例如5'3"，将会视为输入英制单位数值，并自动转换输入值为对应的米数值，同时单位也会自动切换成`米`。  

### **2.3 缩放范围**  

缩放范围用于限制VRC Scaler OSC的改变身高后的最大值与与最小值。此功能不影响VRChat内建模型缩放功能、World缩放功能或其他改变身高工具的缩放效果。点选模型身高区块右上角的齿轮可以开启缩放范围设定选单。共有以下几种选项:  
* Avatar预设值 (0.2 \~ 5米): 与VRChat中内建的缩放范围一致  
* World预设值(0.1 \~ 100米): 过去VRChat中Wirld容许改变的身高范围  
* 安全预设值(0.05 \~ 3000米): VR玩家是否能看见手中圆形选单的建议范围  
* VRChat限制值(0.01 \~ 10000米): 目前VRChat容许改变的身高的最大范围  
* 用户设定档: 在用户设定档中设定的数值，若未特别设定则为最大范围  
* 将上限设为所选的值: 把输入的模型身高设为上限，数值需1米以上  
* 将下限设为所选的值: 把输入的模型身高设为下限，数值需1米以下  

![image](image/img2.3.1.png)  

### **2.4 缩放速率与时间**  

修改缩放速率或时间可获得不同的平滑缩放效果。当勾选`定速缩放`时，每秒改变的倍数将会恒定，所需的缩放时间将随目标身高与当前身高差值增加。取消勾选`定速缩放`将改为固定缩放时间的模式，缩放速度将随目标身高与当前身高差值增加。  

如果不想要平滑缩放效果，希望按下`进行缩放`时就立刻变成该身高，可将缩放速率设为10000，或将缩放时间设为0。  

![image](image/img2.4.1.png)  
![image](image/img2.4.2.png)  

勾选`自动中断`将检测平滑缩放期间当前身高是否在预期范围中，若因使用VRChat内建身高调整功能、World身高修改或其他修改avatar身高工具导致当前身高超出预期范围，将自动中断平滑缩放。如果VRC Scaler OSC应用程式未收到VRChat的OSC封包，导致无法检测当前身高，则`自动中断`功能可能无法正常运作，此时建议取消勾选`自动中断`以停用此功能。  

### **2.5 手势缩放**  

此功能在VR模式中透过双手控制器的按钮组合，并结合双手控制器彼此靠近或分开的动作，直接调整avatar身高。预设手势缩放模式为双手靠近时逐渐缩小，双手分开时逐渐放大。若勾选`世界缩放模式`，则会变成类似双手控制世界的尺寸，自己相对变大或变小。  

在`世界缩放模式`中，双手靠近代表把世界缩小使自己变大，双手分开则为放大世界，使自己缩小。控制器按键组合共有五种，其中L代表左手控制器、R代表右手控制器、T代表板机键、G代表抓握键。以`LT+RG`为例，代表需同时按下左手扳机键与右手抓握键才会触发手势缩放。  

![image](image/img2.5.1.png)  
![image](image/img2.5.2.png)  

如果勾选`双击麦克风键切换缩放手势`，则可以透过先按压双手控制器中要当作缩放手势的按钮组合，再点两下麦克风键切换。若要关闭手势缩放则可以在不按任何按钮的情况下点两下麦克风键停用手势缩放。  

![image](image/img2.5.3.png)  

若麦克风并非是`按下切换`模式，此功能将无法正常运作，但可以改用`耳罩模式`的开关替代。使用`耳罩模式`开关切换手势时会有0.5秒的延迟，让您有时间先用扳机键点选`耳罩模式`开关后再按压缩放手势的按钮组合。  

![image](image/img2.5.4.png)  

由于手势缩放功能依赖于VRC avatar parameter中的GestureLeft与GestureRight参数来推测控制器按钮状态，因此与实际控制器按钮状态可能略有不同。例如单按板机键只能由RockNRoll手势触发，手势与按键对照请参阅下表:  

| 手势名称 | Gesture参数值 | 板机键按下(T) | 抓握键按下(G) |  
| :---- | :---- | :---- | :---- |  
| Neutral | 0 | ❌ | ❌ |  
| Fist | 1 | ✅ | ✅ |  
| HandOpen | 2 | ❌ | ❌ |  
| FingerPoint | 3 | ❌ | ✅ |  
| Victory | 4 | ❌ | ❌ |  
| RockNRoll | 5 | ✅ | ❌ |  
| HandGun | 6 | ❌ | ✅ |  
| ThumbsUp | 7 | ✅ | ✅ |  

### **2.6 OSC设定**  

VRC Scaler OSC应用程式使用VRC OSCQuery以实现自动设定port的功能，避免与其他OSC应用程式冲突。若取消勾选`自动设定接收port`，将会通知VRChat以指定的port传送OSC封包。如果你的VRChat.exe运行在不同电脑中或VR眼镜中，请在`目标IP`中输入该设备IP，若有修改VRChat接收OSC封包的port，请在`发送port`中调整为该port。修改任何设定后要再按一下`套用`才会生效。按下`停止`将立即停止应用程式OSC封包收发功能。  

![image](image/img2.6.1.png)  

### **2.7 用户配置**  

VRC Scaler OSC应用程式可经由用户设定档来调整画面中的预设值与清单数值。应用程式开启时将读取执行目录下的VRCScalerOSC.Setting.txt文件。若该文件不存在则采用预设值。点选`导入配置`可以用指定的设定档进行重新设定。点选`导出配置`可储存当前系统中的设定值。  

![image](image/img2.7.1.png)  

可设定项目与说明如下:  

| 项目 | 预设值 | 说明 |  
| :---- | :---- | :---- |  
| ScalerOSCPathPrefix | /avatar/parameters/VRCScaleOSC | OSC封包路径开头字串<br>于VRChat中动画参数交换数据与接收指令时使用 |  
| MenuControlCameraOSCPathPrefix | /avatar/parameters/MCC | Menu Control Camera的OSC封包路径开头字串<br>用于从VRC选单控制VRC相机设定(详见3.3节说明) |  
| UsingOSCQuery | Y | 启用OSC Query (Y/N) |  
| SendTaskDelay | 5 | 发送OSC封包间格(毫秒) |  
| SmoothScalingIterativeTimesPerSecond | 50 | 每秒发送平滑身高调整封包次数<br>若电脑较差可设定为30或20 |  
| MaxHeight | 10000 | 最大身高值(米) |  
| MinHeight | 0.01 | 最小身高值(米) |  
| OSC\_IP | 127.0.0.1 | OSC发送目标IP |  
| OSC\_SendPort | 9000 | OSC发送Port |  
| OSC\_ReceivePort | 0 | OSC接收Port，设为0代表随机由9010至9100中取一数值使用 |  
| DefaultTargetEyeHeight | 10 | 模型身高输入栏位预设值 |  
| DefaultScalingTime | 3 | 缩放时间预设值(秒) |  
| DefaultScalingRate | 2 | 缩放速率预设值(倍/秒) |  
| UseFixedRate | Y | 启用定速缩放 (Y/N) |  
| UseAutoAbort | N | 启用自动中断 (Y/N) |  
| TargetEyeHeightSelectItems | 0.01\|0.05\|0.1\|0.5\|1\|<br>1.5\|2\|3\|5\|10\|<br>15\|20\|30\|50\|100\|<br>150\|200\|300\|500\|1000\|<br>1500\|2000\|3000\|5000\|10000 | 模型身高下拉式选单中的清单值<br>以符号 | 分隔 |  
| ScalingTimeSelectItems | 0\|1\|2\|3\|5\|<br>10\|15\|30\|60\|120\|<br>300\|600\|900\|1800\|3600\|<br>7200\|10800\|14400\|18000\|21600\|<br>25600\|28800 | 缩放时间下拉式选单中的清单值<br>以符号 | 分隔 |  
| ScalingRateSelectItems | 1.1\|1.2\|1.3\|1.5\|2\|<br>5\|10\|20\|50\|100\|<br>200\|500\|1000\|2000\|<br>5000\|10000 | 缩放速率下拉式选单中的清单值<br>以符号 | 分隔 |  
| ScalerMenuSelectItems | 0.01\|0.05\|0.1\|0.5\|1\|<br>1.5\|2\|3\|5\|10\|<br>15\|20\|30\|50\|100\|<br>150\|200\|300\|500\|1000\|<br>1500\|2000\|3000\|5000\|10000\|<br>0.5\|0.25\|0.1\|0.05\|<br>-0.05\|-0.1\|-0.25\|-0.5 | 精简模式中的身高按钮数值<br>以符号 | 分隔<br>RSSAdj v2中的尺寸选单也会共用此清单数值 |  

### **2.8 精简模式**d  

此为简化版本的控制画面，点选画面中33个尺寸按钮即可改变avatar身高。预设平滑缩放速率为每秒2倍，勾选`即时缩放`可取消平滑缩放。按钮上的数值单位预设为米，勾选`米→倍`可将数值单位由米转为以avatar预设身高为基础的倍数。结尾为%的按钮功能为以当前身高为基础增加或减少固定百分比。点选`停止`立刻中断平滑缩放。点选`预设身高`将直接变为avatar上传时的预设身高。点选`返回`将回到普通版本的控制画面。  

![image](image/img2.8.1.png)  

### **2.9 命令列(Console)版本**  

命令列版本包含桌面版本大部分的功能，主要区别为需要键盘操作，只有英文版本，有支援Linux64位元OS的编译版本可用。除了切换说明分页用`z`键，其余指令需要输入完后要按`enter`键才会执行，另可使用`↑`与`↓`键浏览历史指令。  

**即时显示资讯**:  

* **Current height:** 由VRChat经OSC封包传递获得的目前avatar身高  
* **Default height:** 上传avatar时的预设身高  
* **Scale:** 目前身高基于预设身高的倍数  
* **Range:** 目前可缩放的上下限  
* **Scaling time:** 平滑缩放时间，以秒为单位  
* **Scaling rate:** 平滑缩放速率，以倍/秒为单位  
* **FiexdRate:** 定速缩放设定状态  
* **Auto-Abort:** 自动中断设定状态  
* **Gesture:** 手势缩放设定状态  

**一般模式缩放指令**:  

* **exit:** 关闭应用程式  
* **c:** 停止缩放  
* **d:** 变回预设身高  
* **h[数字][单位]:** 立刻缩放至指定`数字`的身高，`单位`可输入`m`,`x`,`p`，分别代表米、倍数、以目前avatar身高增减百分比。  
* **s[数字][单位]:** 平滑缩放至指定`数字`的身高，`单位`的说明同上  
* **g[数字]:** 手势缩放控制，`数字`可输入0至5，分别对应: 0: 禁用手势缩放, 1: LT+RT, 2: LG+RG, 3:LT+RG, 4:LG+RT, 5:LT+RT+LG+RG  
* **ws:** 切换`世界缩放模式`为启用或禁用  
* **dm:** 切换`双击静音键切换缩放手势`为启用或禁用  

![image](image/img2.9.1.png)  

**精简模式缩放指令**:  

* **q[数字]:** 立刻缩放至指定数字代表的身高值  
* **w[数字]:** 平滑缩放至指定数字代表的身高值  

指定数字与身高请参考画面中显示的数值，以下图为例，数字11代表15米。  

![image](image/img2.9.2.png)  

**系统设定指令**:  

* **ip[IP4地址]:** 设定OSC使用的IP  
* **port s [数字]:** 设定OSC发送封包的port，预设为9000  
* **port s [数字]:** 设定OSC接收封包的port，预设为9010至9100间的随机值  
* **t[数字]:** 设定缩放时间，以秒为单位，并禁用定速缩放  
* **r[数字]:** 设定缩放速率，以倍/秒为单位，并启用定速缩放  
* **f:** 切换`定速缩放`为启用或禁用  
* **a:** 切换`自动中断`为启用或禁用  
* **m[数字]:** 设定缩放身高最大值  
* **n[数字]:** 设定缩放身高最小值  

![image](image/img2.9.3.png)  

若画面底部持续呈现 Waiting for initialization，代表正在等候VRChat的OSC封包，此时将无法正确显示。  

## **三、开发支援**  

本章内容为面相开发者的进阶功能，在此假设读者已熟悉Unity中的动画控制器与VRC parameter如何使用，故仅针对VRC Scaler OSC的交换参数做简单的介绍。若还想要深入了解内部运作方式请参阅开源的C\#原始码。  

### **3.1 OSC参数列表**  

表中的参数名称已省略路径开头字串(/avatar/parameters/VRCScaleOSC)。型别请参阅[VRC wiki OSC](https://wiki.vrchat.com/wiki/OSC)中的说明。若型别为f (float)或T(bool, True)，则会忽略资料为0或false的封包。在读写栏中，RW代表可读可写，R代表只能读取，W代表只能写入。参数列表如下:  

| 参数名称 | 型别 | 读写 | 说明 |  
| :---- | :---- | :---- | :---- |  
| /Input/Horizontal | f | W | 玩家左右移动(正数向右，负数向左)<br>当数值超过0.95自动进入跑步状态 |
| /input/Vertical | f | W | 玩家前后移动(正数向前，负数向后)<br>当数值超过0.95自动进入跑步状态 |
|  |  |  | 说明: 上面两个参数可替代控制器移动，并根据玩家缩小的程度自动减少移动速度 |
| /Input/MovingPuppetOn | T/F | W | 控制器移动选单是否开启<br>选单关闭后将自动停止移动 |
| /input/Run | T/F | W | 玩家跑步 |
| /Input/Jump | T/F | W | 玩家跳跃(设为T后须自行重设为F) |
| /Input/LookHorizontal | f | W | 玩家视角水平转动(正数向右，负数向左)<br>当视角过大时会带动身体转动 |
| /Input/LookVertical | f | W | 玩家视角上下转动(正数向上，负数向下)<br>当视角达到90度后会停止 |
| /Input/UseRight | T/F | W | 玩家右手使用物件，例如抓物件或进入station<br>设为T后0.5秒将自动设为F |
| /Input/UseLeft | T/F | W | 玩家左手使用物件，同上 |
|  |  |  | 说明: 上面六个参数可用于开发玩家互动效果，例如被巨大的踏步震飞(跳跃)、被抓着头转动视角 |
| /StopScaling | T | W | 立刻停止缩放 |  
| /AvatarDefaultHeight | f | R | 取得avatar预设身高 |  
| /BackAvatarDefaultHeight  | T | W | 即时缩放至avatar预设身高 |  
| /ScalingNow | T | W | 以先前指定的目标身高立刻缩放<br>身高单位根据/IsMultiplier而定 |  
| /Meters/ScalingNow | T | W | 以先前指定的目标身高立刻缩放(米) |  
| /Multiplier/ScalingNow | T | W | 以先前指定的目标身高立刻缩放(倍数) |  
| /SmoothScalingStart | T | W | 以先前指定的目标身高平滑缩放<br>身高单位根据/IsMultiplier而定 |  
| /Meters/SmoothScalingStart | T | W | 以先前指定的目标身高平滑缩放(米) |  
| /Multiplier/SmoothScalingStart | T | W | 以先前指定的目标身高平滑缩放(倍数) |  
| /ScalingEyeHeight | f | W | 以输入的数值为目标身高立刻缩放<br>身高单位根据/IsMultiplier而定 |  
| /Meters/ScalingEyeHeight | f | W | 以输入的数值为目标身高立刻缩放(米) |  
| /Multiplier/ScalingEyeHeight | f | W | 以输入的数值为目标身高立刻缩放(倍数) |  
| /SmoothScalingEyeHeight | f | W | 以输入的数值为目标身高平滑缩放<br>身高单位根据/IsMultiplier而定 |  
| /Meters/SmoothScalingEyeHeight | f | W | 以输入的数值为目标身高平滑缩放(米) |  
| /Multiplier/SmoothScalingEyeHeight | f | W | 以输入的数值为目标身高立刻缩放(倍数) |  
| /ScalingPercentage | f | W | 以输入的数值为当前身高百分比数立刻缩放 |  
| /SmoothScalingPercentage | f | W | 以输入的数值为当前身高百分比数平滑缩放 |  
|  |  |  | 例如当前身高2米，输入数值为200，则代表缩放到4米 |  
| /ScalingDiffPercentage | f | W | 以输入的数值为当前身高百分比数差值立刻缩放 |  
| /SmoothScalingDiffPercentage | f | W | 以输入的数值为当前身高百分比数差值平滑缩放 |  
|  |  |  | 说明: 例如当前身高2米，输入数值为+50，则代表缩放到3米 |  
| /SetEyeHeight | f | W | 设定目标身高值(米) |  
| /SetMultiplier | f | W | 设定目标身高值(倍数) |  
| /SetPercentage | f | W | 设定目标身高值(当前身高百分比) |  
| /SetDiffPercentage | f | W | 设定目标身高值(当前身高百分比差值) |  
| /SetScalingTime  | f | W | 设定缩放时间(秒) |  
| /SetScalingRate  | f | W | 设定缩放速率(倍/秒) |  
| /ScalingTimeValue  | f | R | 取得缩放时间 |  
| /ScalingRateValue  | f | R | 取得缩放速率 |  
| /SwitchAutoAbort | T/F | RW | 取得或设定自动中断状态。 |  
| /SetMaxEyeHeight | f | W | 设定缩放最大身高 |  
| /MaxEyeHeightValue | f | R | 取得缩放最大身高 |  
| /SetMinEyeHeight | f | W | 设定缩放最小身高 |  
| /MinEyeHeightValue | f | R | 取得缩放最小身高 |  
| /SwitchFixedRate | T/F | RW | 取得或设定定速缩放状态。 |  
| /SetFixedRate | f | W | 设定启用定速缩放 (平滑缩放模式为固定速率) |  
| /SetFixedTime | f | W | 设定禁用定速缩放 (平滑缩放模式为固定时间) |  
| /IsMultiplier | T/F | RW | 取得或设定目标身高是否为倍率 |  
| /GrowUp | f | W | 以输入的速率逐渐变大至身高上限 |  
| /ShrinkDown | f | W | 以输入的速率逐渐变小至身高下限 |  
|  |  |  | 逐渐变大/变小的速率<br>输入值需大于0.2才会启动缩放<br>实际速率值介于1.5至2倍/秒之间 |  
| /Gesture/Mode | i | RW | 取得或设定手势缩放模式 |  
| /Gesture/WorldScaling | T/F | RW | 取得或设定是否启用世界缩放模式 |  
| /Gesture/DoubleMuteSetGesture | T/F | RW | 取得或设定是否启用双击静音键切换缩放手势 |  
| /DefaultValue{n}/Value | f | R | 取得预设选单位置{n}的数值 |  
| DefaultValue{n}/SetValue | T/F | RW | 取得预设选单位置{n}的数值的设定状态<br>设为T时复制当前身高为暂存身高<br>设为F时删除暂存身高 (详见3.2节说明) |  
| /DefaultValue{n}/Scaling | T | W | 以预设选单位置{n}的数值立刻缩放 |  
| /DefaultValue{n}/Smooth  | T | W | 以预设选单位置{n}的数值平滑缩放 |  
| /DefaultValue{n}/PercentageScaling | T | W | 以预设选单位置{n}的数值为当前身高倍数立刻缩放 |  
| /DefaultValue{n}/PercentageSmooth | T | W | 以预设选单位置{n}的数值为当前身高倍数差值立刻缩放 |  
|  |  |  | 为配合VRC选单Radial显示数值1为100%，此处参数名称虽为Percentage，设定时请以当前身高的倍数为单位<br>例如当前身高2米，输入数值为2，则代表缩放到4米 |  
| /DefaultValue{n}/DiffPercentageScaling | T | W | 以预设选单位置{n}的数值为当前身高倍数平滑缩放 |  
| /DefaultValue{n}/DiffPercentageSmooth | T | W | 以预设选单位置{n}的数值为当前身高倍数差值平滑缩放 |  
|  |  |  | 为配合VRC选单Radial显示数值1为100%，此处参数名称虽为Percentage，设定时请以当前身高的倍数为单位<br>例如当前身高2米，输入数值为+0.5，则代表缩放到3米 |  
| /DefaultValue{n}/Save | T | W | 将目前身高数值复制到预设选单位置{n}的数值 |  
| /DefaultValue{n}/Delete | T | W | 删除预设选单位置{n}的用户暂存数值 |  
| /DefaultValue{n}/InputValue | f | W | 将指定数值设为预设选单位置{n}的数值(详见3.2节说明) |  

以 /GrowUp 与 /ShrinkDown 参数为例，将其加入FourAxisPuppet选单的Up Param 与 Down Param中，就能成为用上下按钮调整身高的控制器  

![image](image/img3.1.1.png)  

以手势缩放设定 /Gesture/Mode 为例，可使用Toggle制作切换控制模式的开关  

![image](image/img3.1.2.png)  

## **3.2 尺寸选单同步功能**  

VRC Scaler OSC其中一项特色是用户能自订精简模式的缩放选单数值，在前一节中提到的/DefaultValue{n}系列参数即为将此功能同步至avatar插件中尺寸清单的实作方法。除了选单同步功能外，用户也可以透过此功能于VRChat中透过选单暂存身高数值，以便未来需要用时直接缩放到暂存值。  

目前位置分配如下：  
| 位置编号 | 预设值 | 用途 |  
| :---- | :---- | :---- |  
| 0 | 0 | 保留为暂存身高功能<br>预设值为0代表缩放至avatar预设身高 |  
| 1 ~ 25 | 0.01 ~ 10000 | 预设身高选单(米或倍数) |  
| 26 ~ 33 | -0.5 ~ 0.5 | 预设身高选单(当前身高百分比) |  
| 34 ~ 100 | 0 | 用户自定义 |  

要在VRC Expressions Menu中加入尺寸选单，请使用`RadialPuppet`，并将`Rotation`的参数设为/DefaultValue{n}/Value，使数值可以呈现在选单上方。接着再根据这个选单的功能需求设定`Parameter`的参数，例如设定为/DefaultValue{n}/Scaling代表开启这个`RadialPuppet`时会以/DefaultValue{n}/Value的数值立刻缩放，同时选单会因OSC回传false封包而立刻关闭。  

![image](image/img3.2.1.png)  

要对每个尺寸选单选项增加暂存身高数值的功能，可使用`Toggle`或`Button`制作对应的功能选项。选用`Button`可分别制作`暂存`与`删除`两种按钮。 `暂存`按钮中的`Parameter`设为/DefaultValue{n}/Copy，点击按钮时将目前身高暂存至对应的/DefaultValue{n}/Value中。 `删除`按钮中的`Parameter`设为/DefaultValue{n}/Delete，点击按钮时将暂存数值回复成预设值。  

选用`Toggle`并将`Parameter`的参数设为/SetValue，可制作设定/删除暂存值的开关。  

![image](image/img3.2.2.png)  

要直接将特定身高数值存入尺寸选单中，可对/DefaultValue{n}/InputValue设定大于0的数值。若数值设为-1则代表删除用户暂存值。当VRC Scaler OSC应用程式收到设定值后，会自动将此参数值设为0，因此您可以透过检查此参数值是否变为0来判断此设定指令是否完成。  

### **3.3 MCC参数转发功能**  

Menu Control Camera (MCC)是一款能用VRC Expressions Menu控制VRC相机的avatar插件，其控制原理为透过向OSC应用程式传送avatar参数，并回送usercamera封包给VRChat，以便让VRC选单也具备控制相机的功能，避免avatar身高过高时难以点击相机面板上的选项。 PC模式无此问题，可直接用滑鼠点选相机面板上的选项。  

预设的avatar参数名称开头是MCC，对应的OSC封包路径开头字串是/avatar/parameters/MCC。 VRC Scaler OSC应用程式会将对应的参数转换成OSC控制相机的封包路径/usercamera。以`5秒后拍照`指令为例，VRC选单中button的参数是MCC/CaptureDelayed，当用户点击按钮后，会透过MCC参数转发功能接收OSC封包/avatar/parameters/MCC/CaptureDelayed，并回送/usercamera/CaptureDelayed至VRChat，让VRC相机执行5秒后拍照的指令。  

目前支援的相机参数如下表:  

| 参数名称 | 型别 | 说明 |  
| :---- | :---- | :---- |  
| Mode | i | 相机模式 <br>0: Off <br>1: Photo <br>2: Stream <br>3: Emoji <br>4: Multilayer <br>5: Print <br>6: Drone <br> 为了避免意外关闭相机，会自动忽略数值为0的OSC封包。 |  
| Close <br>Capture <br>CaptureDelayed | T | 这些参数为按钮性质，只接受true值封包，并且会自动回送false值封包 若相机未开启，VRChat.exe将于开启相机后执行拍照指令(Capture, CaptureDelayed)。 |  
| TriggerTakesPhotos <br>DollyPathsStayVisible <br>RollWhileFlying <br>GreenScreen <br>Lock <br>OrientationIsLandscape <br>Flying <br>SmoothMovement <br>AutoLevelRoll <br>AutoLevelPitch <br>ShowUIInCamera <br>LocalPlayer <br>RemotePlayer <br>Environment <br>Streaming <br>ShowFocus <br>AudioFromCamera <br>LookAtMe | T/F | 这些参数只会在相机开启时才能经由发送/usercamera进行设定，若相机未开启时更动选单数值，可能导致选单数值与相机实际数值不一致。参数详细说明请参阅[官方公告](https://docs.vrchat.com/docs/vrchat-202533#osc-camera-endpoints)。 |  
| Zoom <br>Exposure <br>FocalDistance <br>Aperture <br>FlySpeed <br>TurnSpeed <br>SmoothingStrength <br>PhotoRate <br>Duration | f | float型别参数各有不同范围与预设值，为使其能由选单RadialPuppet设定数值，于/avatar/parameters/MCC中的数值范围调整为0至1，并以0.5作为预设值。详细说明与预设值请参阅[官方公告](https://docs.vrchat.com/docs/vrchat-202533#osc-camera-endpoints)。此外，这些参数只会在相机开启时才能经由发送/usercamera进行设定，因此选单中的数值可能与相机实际参数值不同。 |  
| Hue <br>Saturation <br>Lightness | f | 绿幕颜色设定于/avatar/parameters/MCC中的数值范围调整为0至1，并以1为预设值。 |  
| LookAtMeXOffset <br>LookAtMeYOffset | f | 此参数不直接转换为/usercamera参数，而是做为选单TwoAxisPuppet的参数使用，范围介于-1至1之间。当数值大于0.5或小于-0.5时会开始平滑调整/usercamera/LookAtMeXOffset与/usercamera/LookAtMeYOffset。 |  
| LookAtMeOffsetPuppetOn | T/F | 此参数不属于/usercamera参数，仅为了判断当下是否正在透过选单调整LookAtMeX/YOffset时使用。 |  

## **四、服务条款**  

### **4.1 授权条款**  

本软体采用 MIT 授权条款。您可以免费获得软体不受限制的使用许可，包含使用、复制、修改、合并、出版发行、散布、再授权和/或贩售软体及软体的副本，及授予被供应人同等权利，但必须在所有副本中保留以上著作权声明及注明原始作者。  

### **4.2 免责声明与保证限制**  

本软体以「现状 (As-is)」提供。作者会尽力修复问题，但不保证本工具可于 VRChat 中永久正常使用。您必须理解并同意，本软体之尺寸缩放及其他功能，未来可能因 VRChat 改版而失效。  
若因使用本软体或因使用不当造成任何损失(包含用户本人或第三者)，作者不负担任何赔偿责任。
