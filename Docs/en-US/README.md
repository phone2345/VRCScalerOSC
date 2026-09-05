# **VRC Scaler OSC Manual**

## **I. Introduction**

VRC Scaler OSC is a utility application for changing avatar height in VRChat by sending OSC packets to VRChat, allowing avatars to function without installing any plugins (gimmicks). In theory, it can modify the height of all avatars.

### **1.1 Main Features**

* Modify avatar height within allowed ranges with options for immediate change or smooth transitions. Height values can be input in meters, multiples, percentage increases/decreases, and feet/inches will automatically convert to meters.
* Support gesture-based height adjustment, including the classic "scale the world" mode with options to select different gesture combinations or disable.
* Available in Chinese, English, Japanese, and Korean interfaces, with versions for Windows 64-bit and Linux 64-bit.
* Allows control through specific avatar parameters, enabling potential development of avatar menu control plugins.

### **1.2 Program Version**

* Program written in C#, using self-developed OSC packet handling packages and [VRC OSC Query](https://github.com/vrchat-community/vrc-oscquery-lib)
* Desktop (Windows) version: Chinese, English, Japanese, and Korean interfaces, compatible with Windows 10 and above
* Command-line (Console) version: English interface, compatible with Windows and Linux 64-bit operating systems
* Planned to be open-sourced under MIT license. If your system doesn't support it, you can compile or modify it from source code yourself.

### **1.3 Quick Start Guide**

PC Mode:
1. Run VRCScalerOSC_Windows.exe.
2. Confirm that the current height appears after the height display at the bottom of the window.
3. Select or input the desired Avatar height to scale.
4. Click the [Scaling Now] button.

![](image/img1.3.1.png)
![](image/img1.3.2.png)

VR Mode:
1. Run VRCScalerOSC_Windows.exe.
2. In VRChat, make sure [OSC] and [Allow Sending Head and Wrist VR Tracking OSC Data] are enabled.
3. Hold the grip buttons on both controllers, then double-press the microphone key to enable grip gesture scaling.
4. While holding both grip buttons, move your hands apart to increase height, or move them closer together to decrease height.

### **1.4 Frequently Asked Questions**

* Why can't I change the height?  
  A: Please first confirm that OSC is enabled in VRChat.

* Why doesn't the avatar height information in the application update?  
  A: Check if the receive port is already in use or blocked by firewall/antivirus software. If using VRChat standalone versions (Quest, Pico), VRC Scaler OSC cannot currently receive OSC packets from these versions, only send them. Therefore, displaying current status, gesture scaling, and VRChat menu control functions will not work properly.

* Will VRC Scaler OSC conflict with other OSC tools?  
  A: VRC Scaler OSC uses VRC OSC Query and random receive port functionality to avoid port conflicts. If VRC OSC Query doesn't work properly, you can use OSC packet distribution forwarding tools to handle conflicts, such as [VOR](https://github.com/SutekhVRC/VOR), but gesture scaling functionality relying on VRC OSC Query may not work properly.

* Why doesn't gesture scaling work properly?  
  A: First confirm that avatar height information on screen updates with height changes. If it updates normally but gesture scaling still doesn't work, it may be because [Allow Sending Head and Wrist VR Tracking OSC Data] is not enabled in settings, or VRC OSC Query is not working properly.

* How do I get help if I encounter problems installing or using VRC Scaler OSC?  
  A: Seek assistance from the author at the website or Discord channel where VRC Scaler OSC is released.

### **1.5 Related Products**

* Real Size Scale Adjuster (RSSAdj) v2: An avatar plugin based on VRC Scaler OSC that allows players to adjust height through menus in VRChat.
* Menu Control Camera (MCC): Utilizes OSC to send VRC camera commands, allowing players to adjust camera settings and take photos through menu options, solving the difficulty of controlling the camera when avatar size is too large. Lite version is already integrated into RSSAdj v2.

## **II. Feature Description**

Most of this section focuses on the desktop (Windows) version. For the command-line (Console) version, please see section 2.9. Before use, ensure that OSC is enabled in VRChat and that [Allow Sending Head and Wrist VR Tracking OSC Data] is enabled in VRChat's settings menu.

![](image/img2.0.1.png)
![](image/img2.0.2.png)

### **2.1 Window Settings**

The interface language will automatically follow the computer's operating system language. If the system is not set to Chinese, Japanese, or Korean, English will be the default. To manually switch, click the [Lang.] button and select a language.

![](image/img2.1.1.png)

If your desktop resolution is high and the display scale is 100%, causing the window to appear too small, click the [Size] button to resize it, up to 4 times magnification (2 times length and width).

![](image/img2.1.2.png)

Clicking [Compact Mode] replaces the original window with a fixed height value control panel, allowing users to change height more directly through buttons for different height values. See section 2.8 for details.

### **2.2 Height Adjustment**

Enter the height directly in [Avatar Height] in the upper left, then press [Scaling Now] to change the height. Click [▼] to open the default height menu and quickly select a height. To scale by multiplier instead, click [m] and switch to [x]. Click [Reset Height] to immediately restore the avatar's default height from upload.

![](image/img2.2.1.png)

The unit in [Avatar Height] can be selected as [m] or [x]. Selecting [x] means the input value is a multiple of the avatar's default height. If you want to calculate based on the current height, input a percentage number and add the % symbol at the end, then press [Enter]. The input will automatically convert based on the current height percentage. If the input begins with + or - symbols, the conversion result will be added to the current height.

The [Avatar Height] field also has automatic feet and inches conversion, convenient for users accustomed to imperial units. When the input value contains a string with " or ' symbols, such as 5'3", it will be treated as imperial unit input and automatically convert to the corresponding meter value, with the unit automatically switching to [m].

### **2.3 Scaling Range**

The scaling range is used to limit the maximum and minimum values of height changes made by VRC Scaler OSC. This function does not affect VRChat's built-in character scaling, world scaling, or other height adjustment tools. Click the gear icon in the upper right corner of the character height block to open the scaling range settings menu. There are several options:

* Avatar Default (0.2 ~ 5 meters): Same as the scaling range in VRChat
* World Default (0.1 ~ 100 meters): Past height range allowed for worlds in VRChat
* Safe Default (0.05 ~ 3000 meters): Recommended range for VR players to see the circular menu in hand
* VRChat Limit (0.01 ~ 10000 meters): Current maximum range allowed for height changes in VRChat
* User Profile: Values set in the user profile; defaults to maximum range if not specifically set
* Set Upper Limit to Selected Value: Set the input character height as the upper limit, value must be 1 meter or more
* Set Lower Limit to Selected Value: Set the input character height as the lower limit, value must be 1 meter or less

![](image/img2.3.1.png)

### **2.4 Scaling Speed and Time**

Modifying scaling speed or time provides different smooth scaling effects. When [Fixed rate] is checked, the multiple changed per second remains constant, and the required scaling time increases with the difference between target and current height. Unchecking [Fixed rate] switches to fixed scaling time mode, where scaling speed increases with the difference between target and current height.

If you don't want smooth scaling and want the height to change immediately when pressing [Scaling Now], you can set the scaling rate to 10000 or the scaling time to 0.

![](image/img2.4.1.png)
![](image/img2.4.2.png)

Checking [Auto-abort] will detect whether the current height is within the expected range during smooth scaling. If the current height exceeds the expected range due to using VRChat's built-in height adjustment, world height modification, or other avatar height tools, smooth scaling will be automatically interrupted. If the VRC Scaler OSC application doesn't receive OSC packets from VRChat, making it unable to detect current height, the [Auto-abort] function may not work properly. In this case, it's recommended to uncheck [Auto-abort] to disable this function.

### **2.5 Gesture Scaling**

This function in VR mode uses button combinations on both hand controllers combined with the action of both controllers getting closer or farther apart to directly adjust avatar height. The default gesture scaling mode is for the avatar to gradually shrink when both hands get closer and gradually enlarge when they separate. If [World-Scaling] is checked, it becomes similar to controlling the world's size with both hands, making yourself relatively larger or smaller.

In [World-Scaling], bringing both hands closer shrinks the world making you larger, while separating them enlarges the world making you smaller. There are five controller button combinations, where L represents the left hand controller, R represents the right hand controller, T represents the trigger button, and G represents the grip button. For example, [LT+RG] means you need to press the left trigger and right grip simultaneously to trigger gesture scaling.

![](image/img2.5.1.png)
![](image/img2.5.2.png)

If you check [Double-tap Mute Button to set gesture], you can toggle the gesture scaling button combination by first pressing the scaling button on both hand controllers, then double-clicking the mute button. To disable gesture scaling, you can double-click the mute button without pressing any other buttons.

![](image/img2.5.3.png)

If your microphone is not set to [Toggle] mode, this feature will not function correctly. In that case, you can use the [Earmuff Mode] toggle instead. Switching via [Earmuff Mode] introduces approximately 0.5 seconds of delay, so use the trigger to toggle [Earmuff Mode] first, then press the gesture buttons you wish to assign.

![](image/img2.5.4.png)

Since gesture scaling relies on the GestureLeft and GestureRight parameters in the VRC avatar parameter to infer controller button status, it may differ slightly from actual controller button states. Please refer to the following table:

| Gesture Name | Gesture Parameter Value | Trigger Button Pressed (T) | Grip Button Pressed (G) |
| :---- | :---- | :---- | :---- |
| Neutral | 0 | ❌ | ❌ |
| Fist | 1 | ✅ | ✅ |
| HandOpen | 2 | ❌ | ❌ |
| FingerPoint | 3 | ❌ | ✅ |
| Victory | 4 | ❌ | ❌ |
| RockNRoll | 5 | ✅ | ❌ |
| HandGun | 6 | ❌ | ✅ |
| ThumbsUp | 7 | ✅ | ✅ |

### **2.6 OSC Settings**

VRC Scaler OSC application uses VRC OSCQuery to achieve automatic port configuration, avoiding conflicts with other OSC applications. If you uncheck [Auto-configure receive port], the application will notify VRChat to send OSC packets to the specified port. If your VRChat.exe is running on a different computer or VR headset, input that device's IP in [IP Address]. If you've modified the port where VRChat receives OSC packets, adjust it in [Send port]. Changes take effect only after clicking [Setup]. Click [Stop] to immediately stop the application's OSC packet sending/receiving function.

![](image/img2.6.1.png)

### **2.7 User Settings**

VRC Scaler OSC application can adjust default values and list values through user profiles. When the application starts, it reads the VRCScalerOSC.Setting.txt file in the execution directory. If the file doesn't exist, default values are used. Click [Import] to reconfigure using a specified settings file. Click [Export] to save the current system settings.

![](image/img2.7.1.png)

Configurable items are explained below:

| Item | Default Value | Description |
| :---- | :---- | :---- |
| ScalerOSCPathPrefix | /avatar/parameters/VRCScaleOSC | OSC packet path prefix string used when exchanging data with avatar animation parameters and receiving commands in VRChat |
| MenuControlCameraOSCPathPrefix | /avatar/parameters/MCC | Menu Control Camera OSC packet path prefix string for controlling VRC camera settings from VRC menu (see section 3.3) |
| UsingOSCQuery | Y | Enable OSC Query (Y/N) |
| SendTaskDelay | 5 | OSC packet sending interval (milliseconds) |
| SmoothScalingIterativeTimesPerSecond | 50 | Number of times per second smooth height adjustment packets are sent. Can be set to 30 or 20 for lower-end computers |
| MaxHeight | 10000 | Maximum height value (meters) |
| MinHeight | 0.01 | Minimum height value (meters) |
| OSC_IP | 127.0.0.1 | OSC sending target IP |
| OSC_SendPort | 9000 | OSC sending port |
| OSC_ReceivePort | 0 | OSC receiving port; 0 means randomly select from 9010 to 9100 |
| DefaultTargetEyeHeight | 10 | Default value for character height input field |
| DefaultScalingTime | 3 | Default scaling time (seconds) |
| DefaultScalingRate | 2 | Default scaling rate (multiples/second) |
| UseFixedRate | Y | Enable fixed rate scaling (Y/N) |
| UseAutoAbort | N | Enable auto-abort (Y/N) |
| TargetEyeHeightSelectItems | 0.01\|0.05\|0.1\|0.5\|1\|<br>1.5\|2\|3\|5\|10\|<br>15\|20\|30\|50\|100\|<br>150\|200\|300\|500\|1000\|<br>1500\|2000\|3000\|5000\|10000 | List values in character height dropdown menu separated by \| symbol |
| ScalingTimeSelectItems | 0\|1\|2\|3\|5\|<br>10\|15\|30\|60\|120\|<br>300\|600\|900\|1800\|3600\|<br>7200\|10800\|14400\|18000\|21600\|<br>25600\|28800 | List values in scaling time dropdown menu separated by \| symbol |
| ScalingRateSelectItems | 1.1\|1.2\|1.3\|1.5\|2\|<br>5\|10\|20\|50\|100\|<br>200\|500\|1000\|2000\|<br>5000\|10000 | List values in scaling rate dropdown menu separated by \| symbol |
| ScalerMenuSelectItems | 0.01\|0.05\|0.1\|0.5\|1\|<br>1.5\|2\|3\|5\|10\|<br>15\|20\|30\|50\|100\|<br>150\|200\|300\|500\|1000\|<br>1500\|2000\|3000\|5000\|10000\|<br>0.5\|0.25\|0.1\|0.05\|<br>-0.05\|-0.1\|-0.25\|-0.5 | Height button values in compact mode separated by \| symbol. The size menu in RSSAdj v2 also shares these list values |

### **2.8 Compact Mode**

This is a simplified version of the control screen where clicking 25 height buttons on screen can change avatar height. Default smooth scaling rate is 2 multiples per second. Check [Instant] to disable smooth scaling. Button values default to meters; check [Meters→Multiplier] to convert units from meters to multiples of the avatar's default height. Buttons ending with % function to increase or decrease the current height by a fixed percentage. Click [Stop] to immediately interrupt smooth scaling. Click [Reset] to return directly to the avatar's default height from upload. Click [Back] to go back to the normal version control screen.

![](image/img2.8.1.png)

### **2.9 Command-line (Console) Version**

The command-line version includes most of the desktop version's features, with the main difference being keyboard operation, English-only interface, and a compilation version available for Linux 64-bit OS support. Except for using [z] to switch help pages, all other commands require pressing [Enter] after input to execute. You can also use [↑][↓] keys to navigate command history.

**Real-time Display Information**:

* **Current height:** Avatar's current height obtained via OSC packets from VRChat
* **Default height:** Avatar's default height from upload
* **Scale:** Current height as a multiple of default height
* **Range:** Current scaling upper and lower limits
* **Scaling time:** Smooth scaling time in seconds
* **Scaling rate:** Smooth scaling rate in multiples/second
* **FixedRate:** Fixed rate scaling setting status
* **Auto-Abort:** Auto-abort setting status
* **Gesture:** Gesture scaling setting status

**General Mode Scaling Commands**:

* **exit:** Close the application
* **c:** Stop scaling
* **d:** Return to default height
* **h[number][unit]:** Immediately scale to specified [number] height. [unit] can input [m], [x], [p], representing meters, multiples, percentage increase/decrease based on current avatar height respectively.
* **s[number][unit]:** Smooth scale to specified [number] height. [unit] is same as above.
* **g[number]:** Gesture scaling control. [number] can input 0 to 5, corresponding to: 0: disable gesture scaling, 1: LT+RT, 2: LG+RG, 3: LT+RG, 4: LG+RT, 5: LT+RT+LG+RG
* **ws:** Toggle [World Scaling Mode] on or off
* **dm:** Toggle [Double-click Mute Button to Switch Scaling Gesture] on or off

![](image/img2.9.1.png)

**Compact Mode Scaling Commands**:

* **q[number]:** Immediately scale to height value represented by specified number
* **w[number]:** Smooth scale to height value represented by specified number

  Refer to the values displayed on screen for specified numbers. In the example below, number 11 represents 15 meters.

![](image/img2.9.2.png)

**System Configuration Commands**:

* **ip[IPv4 address]:** Configure IP used for OSC
* **port s [number]:** Configure OSC sending packet port, default 9000
* **port r [number]:** Configure OSC receiving packet port, default random value between 9010 and 9100
* **t[number]:** Configure scaling time in seconds and disable fixed rate scaling
* **r[number]:** Configure scaling rate in multiples/second and enable fixed rate scaling
* **f:** Toggle [Fixed Rate Scaling] on or off
* **a:** Toggle [Auto-Abort] on or off
* **m[number]:** Configure maximum scaling height
* **n[number]:** Configure minimum scaling height

![](image/img2.9.3.png)

  If the bottom of the screen continuously shows "Waiting for initialization," it means waiting for VRChat's OSC packets, and display will be incorrect at this time.

## **III. Developer Support**

This section contains advanced features for developers, assuming readers are already familiar with animation controllers and VRC parameters in Unity. Only VRC Scaler OSC's exchanged parameters are briefly introduced here. To learn more about internal operations, please refer to the open-source C# source code.

### **3.1 OSC Parameter List**

Parameter names in the table omit the path prefix (/avatar/parameters/VRCScaleOSC). Refer to [VRC wiki OSC](https://wiki.vrchat.com/wiki/OSC) for type descriptions. If the type is f (float) or T (bool, True), packets with data of 0 or false are ignored. In the Read/Write column, RW means readable and writable, R means read-only, W means write-only. The parameter list is as follows:

| Parameter Name | Type | Read/Write | Description |
| :---- | :---- | :---- | :---- |
| /Input/Horizontal | f | W | Player horizontal movement (positive: right, negative: left)<br>Automatically runs above 0.95. |
| /input/Vertical | f | W | Player forward/backward movement (positive: forward, negative: backward)<br>Automatically runs above 0.95. |
|  |  |  | These two parameters replace controller movement and adjust speed based on scale size. |
| /Input/MovingPuppetOn | T/F | W | Controller movement menu state<br>Movement stops when OFF. |
| /input/Run | T/F | W | Player running state |
| /Input/Jump | T/F | W | Player jump state (Reset to F manually after setting T) |
| /Input/LookHorizontal | f | W | View horizontal rotation (positive: right, negative: left)<br>Large rotation also rotates the body. |
| /Input/LookVertical | f | W | View vertical rotation (positive: up, negative: down)<br>Stops at 90 degrees. |
| /Input/UseRight | T/F | W | Using objects with the right hand (e.g. taking object, get into station)<br>Set it to **T**, and it will automatically switch back to **F** after 0.5 seconds.
  |
| /Input/UseLeft | T/F | W | Using objects with the left hand. Same as UseRight |
|  |  |  | These six parameters can be used for player interaction gimmicks (e.g. being launched by giant footsteps, having your view rotated while grabbed). |
| /StopScaling | T | W | Stop scaling immediately |
| /AvatarDefaultHeight | f | R | Get avatar default height |
| /BackAvatarDefaultHeight | T | W | Immediately scale to avatar default height |
| /ScalingNow | T | W | Immediately scale to previously specified target height. Height unit depends on '/IsMultiplier' |
| /Meters/ScalingNow | T | W | Immediately scale to previously specified target height (meters) |
| /Multiplier/ScalingNow | T | W | Immediately scale to previously specified target height (multiplier) |
| /SmoothScalingStart | T | W | Smooth scale to previously specified target height. Height unit depends on '/IsMultiplier' |
| /Meters/SmoothScalingStart | T | W | Smooth scale to previously specified target height (meters) |
| /Multiplier/SmoothScalingStart | T | W | Smooth scale to previously specified target height (multiplier) |
| /ScalingEyeHeight | f | W | Immediately scale to specified height value. Height unit depends on /IsMultiplier |
| /Meters/ScalingEyeHeight | f | W | Immediately scale to specified height value (meters) |
| /Multiplier/ScalingEyeHeight | f | W | Immediately scale to specified height value (multiplier) |
| /SmoothScalingEyeHeight | f | W | Smooth scale to specified height value. Height unit depends on /IsMultiplier |
| /Meters/SmoothScalingEyeHeight | f | W | Smooth scale to specified height value (meters) |
| /Multiplier/SmoothScalingEyeHeight | f | W | Smooth scale to specified height value (multiplier) |
| /ScalingPercentage | f | W | Immediately scale based on input value as percentage of current height |
| /SmoothScalingPercentage | f | W | Smooth scale based on input value as percentage of current height |
|  |  |  | Example: If current height is 2 meters and input value is 200, it scales to 4 meters |
| /ScalingDiffPercentage | f | W | Immediately scale based on input value as percentage difference from current height |
| /SmoothScalingDiffPercentage | f | W | Smooth scale based on input value as percentage difference from current height |
|  |  |  | Example: If current height is 2 meters and input value is +50, it scales to 3 meters |
| /SetEyeHeight | f | W | Set target height value (meters) |
| /SetMultiplier | f | W | Set target height value (multiplier) |
| /SetPercentage | f | W | Set target height value (percentage of current height) |
| /SetDiffPercentage | f | W | Set target height value (percentage difference from current height) |
| /SetScalingTime | f | W | Set scaling time (seconds) |
| /SetScalingRate | f | W | Set scaling rate (multiples/second) |
| /ScalingTimeValue | f | R | Get scaling time |
| /ScalingRateValue | f | R | Get scaling rate |
| /SwitchAutoAbort | T/F | RW | Get or set auto-abort status |
| /SetMaxEyeHeight | f | W | Set maximum scaling height |
| /MaxEyeHeightValue | f | R | Get maximum scaling height |
| /SetMinEyeHeight | f | W | Set minimum scaling height |
| /MinEyeHeightValue | f | R | Get minimum scaling height |
| /SwitchFixedRate | T/F | RW | Get or set fixed rate scaling status |
| /SetFixedRate | f | W | Enable fixed rate scaling (smooth scaling mode uses fixed rate) |
| /SetFixedTime | f | W | Disable fixed rate scaling (smooth scaling mode uses fixed time) |
| /IsMultiplier | T/F | RW | Get or set whether target height is in multiples |
| /GrowUp | f | W | Gradually enlarge at input rate to height upper limit |
| /ShrinkDown | f | W | Gradually shrink at input rate to height lower limit |
|  |  |  | Rate of gradual enlargement/shrinkage. Input value must be greater than 0.2 to activate scaling. Actual rate value is between 1.5 to 2 multiples/second |
| /Gesture/Mode | i | RW | Get or set gesture scaling mode |
| /Gesture/WorldScaling | T/F | RW | Get or set whether world scaling mode is enabled |
| /Gesture/DoubleMuteSetGesture | T/F | RW | Get or set whether double-click mute button to switch scaling gesture is enabled |
| /DefaultValue{n}/Value | f | R | Get value at preset menu position {n} |
| /DefaultValue{n}/SetValue | T/F | RW | Get set status of value at preset menu position {n}. Set to T to copy current height as temporary height, set to F to delete temporary height (see section 3.2) |
| /DefaultValue{n}/Scaling | T | W | Immediately scale using value at preset menu position {n} |
| /DefaultValue{n}/Smooth | T | W | Smooth scale using value at preset menu position {n} |
| /DefaultValue{n}/PercentageScaling | T | W | Immediately scale using value at preset menu position {n} as multiple of current height |
| /DefaultValue{n}/PercentageSmooth | T | W | Smooth scale using value at preset menu position {n} as multiple of current height |
|  |  |  | To match VRC menu Radial display where 1 is 100%, when setting, use multiples of current height as unit. Example: If current height is 2 meters and input value is 2, it scales to 4 meters |
| /DefaultValue{n}/DiffPercentageScaling | T | W | Immediately scale using value at preset menu position {n} as percentage difference multiple of current height |
| /DefaultValue{n}/DiffPercentageSmooth | T | W | Smooth scale using value at preset menu position {n} as percentage difference multiple of current height |
|  |  |  | To match VRC menu Radial display where 1 is 100%, when setting, use multiples of current height as unit. Example: If current height is 2 meters and input value is +0.5, it scales to 3 meters |
| /DefaultValue{n}/Save | T | W | Copy current height value to preset menu position {n} |
| /DefaultValue{n}/Delete | T | W | Delete user temporary value at preset menu position {n} |
| /DefaultValue{n}/InputValue | f | W | Set specified value as value at preset menu position {n} (see section 3.2) |

For example, adding '/GrowUp' and '/ShrinkDown' parameters to the FourAxisPuppet menu's Up Param and Down Param can create a controller that adjusts height using up/down buttons.

![](image/img3.1.1.png)

For example, using gesture scaling mode '/Gesture/Mode' can create a toggle switch to switch control modes.

![](image/img3.1.2.png)

## **3.2 Size Menu Sync Feature**

One of VRC Scaler OSC's features is allowing users to customize the scaling menu values in compact mode. The /DefaultValue{n} series parameters mentioned in the previous section implement this feature by syncing to the size list in avatar plugins. Besides menu sync, users can also store height values through menus in VRChat for later use when needed.

Current position allocation is as follows:

| Position Number | Default Value | Purpose |
| :---- | :---- | :---- |
| 0 | 0 | Reserved for temporary height function.<br>The default value of 0 indicates the default height of the avatar. |
| 1 ~ 25 | 0.01 ~ 10000 | Default height menu (meters or multiples) |
| 26 ~ 33 | -0.5 ~ 0.5 | Default height menu (current height percentage) |
| 34 ~ 100 | 0 | User-defined |

To add a size menu in VRC Expressions Menu, use [RadialPuppet] and set the [Rotation] parameter to /DefaultValue{n}/Value to display the value on the menu. Then configure the [Parameter] parameter according to the menu's functional needs. For example, setting [Parameter] to /DefaultValue{n}/Scaling means opening this [RadialPuppet] will immediately scale using the /DefaultValue{n}/Value, and the menu will close immediately as OSC sends back a false packet.

![](image/img3.2.1.png)

To add temporary height value functionality to each size menu option, use [Toggle] or [Button] to create corresponding functional options. Using [Button] can create both [Save] and [Delete] buttons. The [Save] button's [Parameter] is set to /DefaultValue{n}/Copy. Clicking saves the current height to corresponding /DefaultValue{n}/Value. The [Delete] button's [Parameter] is set to /DefaultValue{n}/Delete. Clicking restores the temporary value to default.

Using [Toggle] and setting [Parameter] to /SetValue can create an on/off switch for setting/deleting temporary values.

![](image/img3.2.2.png)

To directly store a specific height value in a size menu, you can set a value greater than 0 to /DefaultValue{n}/InputValue. Setting to -1 means delete user temporary value. When VRC Scaler OSC receives the set value, it automatically sets this parameter to 0, so you can check if this parameter has become 0 to determine if the set command completed.

### **3.3 MCC Parameter Forwarding Function**

Menu Control Camera (MCC) is an avatar plugin that can control VRC camera through VRC Expressions Menu. Its control principle is by sending avatar parameters to the OSC application and returning usercamera packets to VRChat, allowing VRC menu to also have camera control capability, avoiding the difficulty of clicking camera panel options when avatar height is too high. Desktop mode doesn't have this issue and can directly click options on the camera panel.

The default avatar parameter name prefix is MCC, with corresponding OSC packet path prefix /avatar/parameters/MCC. VRC Scaler OSC application converts corresponding parameters to OSC camera control packet path /usercamera. For example, the [Capture Delayed] command sends /avatar/parameters/MCC/CaptureDelayed through MCC parameter forwarding, receiving OSC packet and sending /usercamera/CaptureDelayed to VRChat for VRC camera to execute the delayed capture command.

Currently supported camera parameters are as follows:

| Parameter Name | Type | Description |
| :---- | :---- | :---- |
| Mode | i | Camera mode. 0: Off, 1: Photo, 2: Stream, 3: Emoji, 4: Multilayer, 5: Print, 6: Drone. To avoid accidentally closing the camera, OSC packets with value 0 are automatically ignored. |
| Close, Capture, CaptureDelayed | T | These parameters are button-type, only accepting true value packets and automatically sending back false value packets. If camera is not open, VRChat.exe will open the camera before executing capture commands (Capture, CaptureDelayed). |
| TriggerTakesPhotos, DollyPathsStayVisible, RollWhileFlying, GreenScreen, Lock, OrientationIsLandscape, Flying, SmoothMovement, AutoLevelRoll, AutoLevelPitch, ShowUIInCamera, LocalPlayer, RemotePlayer, Environment, Streaming, ShowFocus, AudioFromCamera, LookAtMe | T/F | These parameters can only be set via /usercamera when camera is open. Changing menu values when camera is closed may cause menu values to be inconsistent with actual camera values. Detailed parameter descriptions refer to [official announcement](https://docs.vrchat.com/docs/vrchat-202533#osc-camera-endpoints). |
| Zoom, Exposure, FocalDistance, Aperture, FlySpeed, TurnSpeed, SmoothingStrength, PhotoRate, Duration | f | Float-type parameters each have different ranges and default values. To enable setting values through menu RadialPuppet, value ranges in /avatar/parameters/MCC are adjusted to 0 to 1, with 0.5 as default. Detailed descriptions and defaults refer to [official announcement](https://docs.vrchat.com/docs/vrchat-202533#osc-camera-endpoints). Additionally, these parameters can only be set via /usercamera when camera is open, so menu values may differ from actual camera parameters. |
| Hue, Saturation, Lightness | f | Green screen color settings. Value ranges in /avatar/parameters/MCC are adjusted to 0 to 1, with 1 as default. |
| LookAtMeXOffset, LookAtMeYOffset | f | These parameters don't directly convert to /usercamera parameters but are used as parameters for menu TwoAxisPuppet, ranging from -1 to 1. When value is greater than 0.5 or less than -0.5, smooth adjustment of /usercamera/LookAtMeXOffset and /usercamera/LookAtMeYOffset begins. |
| LookAtMeOffsetPuppetOn | T/F | This parameter is not a /usercamera parameter, only used to determine whether currently adjusting LookAtMeX/YOffset through menu. |

## **IV. Terms of Service**

### **4.1 License Terms**

This software uses the MIT License. You may freely obtain unrestricted usage rights to the software, including use, copying, modification, merging, publication, distribution, sublicensing, and/or selling the software and copies thereof, and granting equivalent rights to recipients. However, you must retain the above copyright notice and credit the original author in all copies.

### **4.2 Disclaimer and Warranty Limitation**

This software is provided "as-is." The author will make best efforts to fix issues but does not guarantee the tool will work permanently with VRChat. You must understand and agree that the height scaling and other functions of this software may become invalid due to future VRChat updates.

If any loss occurs from using this software or improper use (including to the user or third parties), the author bears no liability for compensation.
