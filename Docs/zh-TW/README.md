# **VRC Scaler OSC 說明書**

## **一、簡介**

VRC Scaler OSC 是用於改變VRChat中avatar身高的工具應用程式，經由向VRChat發送OSC封包，可讓avatar在不安裝任何插件(gimmick)的情況下運作，理論上能夠修改所有avatar的身高。

### **1.1 主要特色**

* 在允許範圍內任意修改avatar身高，可選擇立即改變或平滑變化，身高數值單位可用公尺、倍數、增減百分比等方式輸入，輸入英尺與英吋將自動轉換為公尺。  
* 支援手勢改變身高功能，包含經典的`縮放世界`模式，可選擇不同手勢搭配或停用。  
* 有中英日韓介面，以及win64與linux64版本可選用。  
* 可以透過特定名稱的avatar參數控制，具有開發avatar選單控制插件可能性。

### **1.2 程式版本**

* 程式以C\#撰寫，使用自主開發的OSC封包處理套件及[VRC OSC Query](https://github.com/vrchat-community/vrc-oscquery-lib)  
* 桌面(Windows)版本: 中英日韓介面，適用於Windows 10以上作業系統  
* 命令列(Console)版本: 英文介面，適用於Windows 及Linux 64位元作業系統  
* 預計以MIT授權開源，若使用的系統不支援可自行從原始碼編譯或改寫。

### **1.3 快速入門指南**

PC模式：
1. 執行VRCScalerOSC\_Windows.exe  
2. 確認視窗下方的目前身高後方有出現目前avatar身高數值  
3. 選擇或輸入要縮放的角色身高  
4. 點`進行縮放`按鈕

![image](image/img1.3.1.png)
![image](image/img1.3.2.png)

VR模式：
1. 執行VRCScalerOSC\_Windows.exe  
2. 進入VRChat，確認已開啟`OSC`與`允許透過OSC發送頭部與腕部的VR追蹤數據`  
3. 雙手控制器按下抓握鍵後再按兩下麥克風鍵，開啟以抓握鍵的手勢縮放功能  
4. 雙手按住抓握鍵，兩手遠離身高就會逐漸變高，兩手靠近身高就會逐漸縮小  

### **1.4 常見問題**

* 為什麼無法改變身高?  
  A: 請先確認於VRChat中有開啟OSC功能。  

* 為什麼應用程式畫面中的avatar身高資訊不會更新?  
  A: 請檢查接收port是否已被占用或有防火牆/防毒軟體封鎖網路功能。若使用VRChat一體機版本(Quest, Pico)，目前VRC Scaler OSC尚無法接收到這些版本中的OSC封包，僅能對其發送OSC封包，因此顯示當前狀態、手勢縮放與透過VRChat選單控制VRC Scaler OSC的功能將無法正常使用。  

* VRC Scaler OSC會與其他OSC工具衝突嗎?  
  A: VRC Scaler OSC使用VRC OSC Query及隨機接收port功能來避免port衝突。若VRC OSC Query無法正常運作，則可以使用OSC封包分配轉發工具來處理衝突，例如[VOR](https://github.com/SutekhVRC/VOR)，但依賴VRC OSC Query的手勢縮放功能可能無法正常運作。  

* 為什麼手勢縮放功能無法正常使用?  
  A: 請先確認畫面中的avatar身高資訊是否會隨身高改變更新，若可正常更新但依然無法使用手勢縮放，則可能是未在設定畫面中開啟`允許透過OSC發送頭部與腕部的VR追蹤數據`，或是VRC OSC Query無法正常運作。  

* 如果安裝或使用VRC Scaler OSC遇到問題，我該如何尋求協助?  
  A: 請於發布VRC Scaler OSC的網站或Discord頻道尋求作者協助。

### **1.5 關聯商品**

5. Real Size Scale Adjuster (RSSAdj) v2，以VRC Scaler OSC為基礎的avatar插件，讓玩家在VRChat中透過選單修改身高。  
6. Menu Control Camera (MCC)，利用OSC發送VRC相機指令功能，讓玩家能用選單選項調整相機設定與拍照，以解決avatar尺寸過大時難以控制相機的問題。Lite版本已整合在RSSAdj v2中。

## **二、功能介紹**

本章大部分說明以桌面(Windows)版本為主，命令列(Conlose)版本請參閱2.8節。在使用前，請先確保有開啟VRChat中的OSC功能，並且在VRChat的設定選單中已開啟`允許透過OSC發送頭部與腕部的VR追蹤數據`。  

![image](image/img2.0.1.png)
![image](image/img2.0.2.png)

### **2.1 視窗設定**

介面語言將自動跟隨電腦作業系統語言，若系統非中文，日文，韓文，則以英文版為主。若需要自行切換，請點擊`Lang.`按鈕並選擇語言。  

![image](image/img2.1.1.png)

如果您的桌面解析度很高並且顯示的比例為100%，導致視窗看起來過小，可以點擊`大小`按鈕進行修改，最多可放大到4倍(長寬為2倍)。  

![image](image/img2.1.2.png)

點選`精簡模式`將以固定身高數值的控制面板取代原視窗畫面，可讓使用者更直接的透過不同身高數值的按鈕改變身高。詳細內容請參閱2.8節。

### **2.2 身高調整**

從左上角`角色身高`中直接輸入身高，再按`進行縮放`即可改變身高。按`▼`將開啟預設身高選單，可從中快速選擇身高。點擊`回到預設身高`將立刻恢復成avatar上傳時的預設身高。  

![image](image/img2.2.1.png)

`角色身高`中的單位可選`公尺`或`倍`，若選擇`倍`代表輸入的數值為avatar預設身高的倍數。如果想要以當前身高為基礎進行計算，請輸入百分比數字並於結尾加上%符號並按`enter`鍵，輸入值將會以當前身高百分比自動轉換。若輸入值開頭為 \+ 或 \- 符號，轉換結果將再加上當前身高。  

`角色身高`欄位另有自動轉換英尺英吋功能，以便於習慣英制單位的使用者輸入尺寸。當輸入的數值帶有 " 或 ' 符號的字串時，例如5'3"，將會視為輸入英制單位數值，並自動轉換輸入值為對應的公尺數值，同時單位也會自動切換成`公尺`。

### **2.3 縮放範圍**

縮放範圍用於限制VRC Scaler OSC的改變身高後的最大值與與最小值。此功能不影響VRChat內建角色縮放功能、World縮放功能或其他改變身高工具的縮放效果。點選角色身高區塊右上角的齒輪可以開啟縮放範圍設定選單。共有以下幾種選項:   
* Avatar預設值 (0.2 \~ 5公尺): 與VRChat中內建的縮放範圍一致  
* World預設值(0.1 \~ 100公尺): 過去VRChat中Wirld容許改變的身高範圍  
* 安全預設值(0.05 \~ 3000公尺): VR玩家是否能看見手中圓形選單的建議範圍  
* VRChat限制值(0.01 \~ 10000公尺): 目前VRChat容許改變的身高的最大範圍  
* 使用者設定檔: 在使用者設定檔中設定的數值，若未特別設定則為最大範圍  
* 將上限設為所選的值: 把輸入的角色身高設為上限，數值需1公尺以上  
* 將下限設為所選的值: 把輸入的角色身高設為下限，數值需1公尺以下  

![image](image/img2.3.1.png)

### **2.4 縮放速率與時間**

修改縮放速率或時間可獲得不同的平滑縮放效果。當勾選`定速縮放`時，每秒改變的倍數將會恆定，所需的縮放時間將隨目標身高與當前身高差值增加。取消勾選`定速縮放`將改為固定縮放時間的模式，縮放速度將隨目標身高與當前身高差值增加。  

如果不想要平滑縮放效果，希望按下`進行縮放`時就立刻變成該身高，可將縮放速率設為10000，或將縮放時間設為0。  

![image](image/img2.4.1.png)
![image](image/img2.4.2.png)

勾選`自動中斷`將檢測平滑縮放期間當前身高是否在預期範圍中，若因使用VRChat內建身高調整功能、World身高修改或其他修改avatar身高工具導致當前身高超出預期範圍，將自動中斷平滑縮放。如果VRC Scaler OSC應用程式未收到VRChat的OSC封包，導致無法檢測當前身高，則`自動中斷`功能可能無法正常運作，此時建議取消勾選`自動中斷`以停用此功能。

### **2.5 手勢縮放**

此功能在VR模式中透過雙手控制器的按鈕組合，並結合雙手控制器彼此靠近或分開的動作，直接調整avatar身高。預設手勢縮放模式為雙手靠近時逐漸縮小，雙手分開時逐漸放大。若勾選`世界縮放模式`，則會變成類似雙手控制世界的尺寸，自己相對變大或變小。

在`世界縮放模式`中，雙手靠近代表把世界縮小使自己變大，雙手分開則為放大世界，使自己縮小。控制器按鍵組合共有五種，其中L代表左手控制器、R代表右手控制器、T代表板機鍵、G代表抓握鍵。以`LT+RG`為例，代表需同時按下左手扳機鍵與右手抓握鍵才會觸發手勢縮放。  

![image](image/img2.5.1.png)
![image](image/img2.5.2.png)

如果勾選`雙擊麥克風鍵切換縮放手勢`，則可以透過先按壓雙手控制器中要當作縮放手勢的按鈕組合，再點兩下麥克風鍵切換。若要關閉手勢縮放則可以在不按任何按鈕的情況下點兩下麥克風鍵停用手勢縮放。

![image](image/img2.5.3.png)

若麥克風並非是`點擊切換`模式，此功能將無法正常運作，但可以改用`音罩模式`的開關替代。使用`音罩模式`開關切換手勢時會有0.5秒的延遲，讓您有時間先用扳機鍵點選`音罩模式`開關後再按壓縮放手勢的按鈕組合。

![image](image/img2.5.4.png)

由於手勢縮放功能依賴於VRC avatar parameter中的GestureLeft與GestureRight參數來推測控制器按鈕狀態，因此與實際控制器按鈕狀態可能略有不同。例如單按板機鍵只能由RockNRoll手勢觸發，手勢與按鍵對照請參閱下表: 

| 手勢名稱 | Gesture參數值 | 板機鍵按下(T) | 抓握鍵按下(G) |
| :---- | :---- | :---- | :---- |
| Neutral | 0 | ❌ | ❌ |
| Fist | 1 | ✅ | ✅ |
| HandOpen | 2 | ❌ | ❌ |
| FingerPoint | 3 | ❌ | ✅ |
| Victory | 4 | ❌ | ❌ |
| RockNRoll | 5 | ✅ | ❌ |
| HandGun | 6 | ❌ | ✅ |
| ThumbsUp | 7 | ✅ | ✅ |

### **2.6 OSC設定**

VRC Scaler OSC應用程式使用VRC OSCQuery以實現自動設定port的功能，避免與其他OSC應用程式衝突。若取消勾選`自動設定接收port`，將會通知VRChat以指定的port傳送OSC封包。如果你的VRChat.exe運行在不同電腦中或VR眼鏡中，請在`目標IP`中輸入該設備IP，若有修改VRChat接收OSC封包的port，請在`發送port`中調整為該port。修改任何設定後要再按一下`套用`才會生效。按下`停止`將立即停止應用程式OSC封包收發功能。  

![image](image/img2.6.1.png)

### **2.7 使用者設定**

VRC Scaler OSC應用程式可經由使用者設定檔來調整畫面中的預設值與清單數值。應用程式開啟時將讀取執行目錄下的VRCScalerOSC.Setting.txt文件。若該文件不存在則採用預設值。點選`匯入設定`可以用指定的設定檔進行重新設定。點選`匯出設定`可儲存當前系統中的設定值。  

![image](image/img2.7.1.png)

可設定項目與說明如下: 

| 項目 | 預設值 | 說明 |
| :---- | :---- | :---- |
| ScalerOSCPathPrefix | /avatar/parameters/VRCScaleOSC | OSC封包路徑開頭字串<br>於VRChat中動畫參數交換數據與接收指令時使用 |
| MenuControlCameraOSCPathPrefix | /avatar/parameters/MCC | Menu Control Camera的OSC封包路徑開頭字串<br>用於從VRC選單控制VRC相機設定(詳見3.3節說明) |
| UsingOSCQuery | Y | 啟用OSC Query (Y/N) |
| SendTaskDelay | 5 | 發送OSC封包間格(毫秒) |
| SmoothScalingIterativeTimesPerSecond | 50 | 每秒發送平滑身高調整封包次數<br>若電腦較差可設定為30或20 |
| MaxHeight | 10000 | 最大身高值(公尺) |
| MinHeight | 0.01 | 最小身高值(公尺) |
| OSC\_IP | 127.0.0.1 | OSC發送目標IP |
| OSC\_SendPort | 9000 | OSC發送Port |
| OSC\_ReceivePort | 0 | OSC接收Port，設為0代表隨機由9010至9100中取一數值使用 |
| DefaultTargetEyeHeight | 10 | 角色身高輸入欄位預設值 |
| DefaultScalingTime | 3 | 縮放時間預設值(秒) |
| DefaultScalingRate | 2 | 縮放速率預設值(倍/秒) |
| UseFixedRate | Y | 啟用定速縮放 (Y/N) |
| UseAutoAbort | N | 啟用自動中斷 (Y/N) |
| TargetEyeHeightSelectItems | 0.01\|0.05\|0.1\|0.5\|1\|<br>1.5\|2\|3\|5\|10\|<br>15\|20\|30\|50\|100\|<br>150\|200\|300\|500\|1000\|<br>1500\|2000\|3000\|5000\|10000 | 角色身高下拉式選單中的清單值<br>以符號 | 分隔 |
| ScalingTimeSelectItems | 0\|1\|2\|3\|5\|<br>10\|15\|30\|60\|120\|<br>300\|600\|900\|1800\|3600\|<br>7200\|10800\|14400\|18000\|21600\|<br>25600\|28800 | 縮放時間下拉式選單中的清單值<br>以符號 | 分隔 |
| ScalingRateSelectItems | 1.1\|1.2\|1.3\|1.5\|2\|<br>5\|10\|20\|50\|100\|<br>200\|500\|1000\|2000\|<br>5000\|10000 | 縮放速率下拉式選單中的清單值<br>以符號 | 分隔 |
| ScalerMenuSelectItems | 0.01\|0.05\|0.1\|0.5\|1\|<br>1.5\|2\|3\|5\|10\|<br>15\|20\|30\|50\|100\|<br>150\|200\|300\|500\|1000\|<br>1500\|2000\|3000\|5000\|10000\|<br>0.5\|0.25\|0.1\|0.05\|<br>-0.05\|-0.1\|-0.25\|-0.5 | 精簡模式中的身高按鈕數值<br>以符號 | 分隔<br>RSSAdj v2中的尺寸選單也會共用此清單數值 |

### **2.8 精簡模式**d

此為簡化版本的控制畫面，點選畫面中33個尺寸按鈕即可改變avatar身高。預設平滑縮放速率為每秒2倍，勾選`即時縮放`可取消平滑縮放。按鈕上的數值單位預設為公尺，勾選`公尺→倍`可將數值單位由公尺轉為以avatar預設身高為基礎的倍數。結尾為%的按鈕功能為以當前身高為基礎增加或減少固定百分比。點選`停止`立刻中斷平滑縮放。點選`預設身高`將直接變為avatar上傳時的預設身高。點選`返回`將回到普通版本的控制畫面。  

![image](image/img2.8.1.png)

### **2.9 命令列(Console)版本**

命令列版本包含桌面版本大部分的功能，主要區別為需要鍵盤操作，只有英文版本，有支援Linux64位元OS的編譯版本可用。除了切換說明分頁用`z`鍵，其餘指令需要輸入完後要按`enter`鍵才會執行，另可使用`↑`與`↓`鍵瀏覽歷史指令。  

**即時顯示資訊**: 

* **Current height:** 由VRChat經OSC封包傳遞獲得的目前avatar身高  
* **Default height:** 上傳avatar時的預設身高  
* **Scale:** 目前身高基於預設身高的倍數  
* **Range:** 目前可縮放的上下限  
* **Scaling time:** 平滑縮放時間，以秒為單位  
* **Scaling rate:** 平滑縮放速率，以倍/秒為單位  
* **FiexdRate:** 定速縮放設定狀態  
* **Auto-Abort:** 自動中斷設定狀態  
* **Gesture:** 手勢縮放設定狀態

**一般模式縮放指令**:   

* **exit:** 關閉應用程式  
* **c:** 停止縮放  
* **d:** 變回預設身高  
* **h[數字][單位]:** 立刻縮放至指定`數字`的身高，`單位`可輸入`m`,`x`,`p`，分別代表公尺、倍數、以目前avatar身高增減百分比。  
* **s[數字][單位]:** 平滑縮放至指定`數字`的身高，`單位`的說明同上  
* **g[數字]:** 手勢縮放控制，`數字`可輸入0至5，分別對應: 0: 禁用手勢縮放, 1: LT+RT, 2: LG+RG, 3:LT+RG, 4:LG+RT, 5:LT+RT+LG+RG
* **ws:** 切換`世界縮放模式`為啟用或禁用
* **dm:** 切換`雙擊靜音鍵切換縮放手勢`為啟用或禁用

![image](image/img2.9.1.png)

**精簡模式縮放指令**:   

* **q[數字]:** 立刻縮放至指定數字代表的身高值  
* **w[數字]:** 平滑縮放至指定數字代表的身高值

  指定數字與身高請參考畫面中顯示的數值，以下圖為例，數字11代表15公尺。

![image](image/img2.9.2.png)

**系統設定指令**:   

* **ip[IP4地址]:** 設定OSC使用的IP  
* **port s [數字]:** 設定OSC發送封包的port，預設為9000  
* **port s [數字]:** 設定OSC接收封包的port，預設為9010至9100間的隨機值  
* **t[數字]:** 設定縮放時間，以秒為單位，並禁用定速縮放  
* **r[數字]:** 設定縮放速率，以倍/秒為單位，並啟用定速縮放  
* **f:** 切換`定速縮放`為啟用或禁用  
* **a:** 切換`自動中斷`為啟用或禁用  
* **m[數字]:** 設定縮放身高最大值  
* **n[數字]:** 設定縮放身高最小值

![image](image/img2.9.3.png)

  若畫面底部持續呈現 Waiting for initialization，代表正在等候VRChat的OSC封包，此時將無法正確顯示。

## **三、開發支援**

本章內容為面相開發者的進階功能，在此假設讀者已熟悉Unity中的動畫控制器與VRC parameter如何使用，故僅針對VRC Scaler OSC的交換參數做簡單的介紹。若還想要深入了解內部運作方式請參閱開源的C\#原始碼。

### **3.1 OSC參數列表**

表中的參數名稱已省略路徑開頭字串(/avatar/parameters/VRCScaleOSC)。型別請參閱[VRC wiki OSC](https://wiki.vrchat.com/wiki/OSC)中的說明。若型別為f (float)或T(bool, True)，則會忽略資料為0或false的封包。在讀寫欄中，RW代表可讀可寫，R代表只能讀取，W代表只能寫入。參數列表如下: 

| 參數名稱 | 型別 | 讀寫 | 說明 |
| :---- | :---- | :---- | :---- |
| /Input/Horizontal | f | W | 玩家左右移動(正數向右，負數向左)<br>當數值超過0.95自動進入跑步狀態 |
| /input/Vertical | f | W | 玩家前後移動(正數向前，負數向後)<br>當數值超過0.95自動進入跑步狀態 |
|  |  |  | 說明: 上面兩個參數可替代控制器移動，並根據玩家縮小的程度自動減少移動速度 |
| /Input/MovingPuppetOn | T/F | W | 控制器移動選單是否開啟<br>選單關閉後將自動停止移動 |
| /input/Run | T/F | W | 玩家跑步狀態 |
| /Input/Jump | T/F | W | 玩家跳躍狀態(設為T後須自行重設為F) |
| /Input/LookHorizontal | f | W | 玩家視角水平轉動(正數向右，負數向左)<br>當視角過大時會帶動身體轉動 |
| /Input/LookVertical | f | W | 玩家視角上下轉動(正數向上，負數向下)<br>當視角達到90度後會停止 |
| /Input/UseRight | T/F | W | 玩家右手使用物件，例如抓物件或進入station<br>設為T後0.5秒將自動設為F |
| /Input/UseLeft | T/F | W | 玩家左手使用物件，同上 |
|  |  |  | 說明: 上面六個參數可用於開發玩家互動效果，例如被巨大的踏步震飛(跳躍)、被抓著頭轉動視角 |
| /StopScaling | T | W | 立刻停止縮放 |
| /AvatarDefaultHeight | f | R | 取得avatar預設身高 |
| /BackAvatarDefaultHeight  | T | W | 即時縮放至avatar預設身高 |
| /ScalingNow | T | W | 以先前指定的目標身高立刻縮放<br>身高單位根據/IsMultiplier而定 |
| /Meters/ScalingNow | T | W | 以先前指定的目標身高立刻縮放(公尺) |
| /Multiplier/ScalingNow | T | W | 以先前指定的目標身高立刻縮放(倍數) |
| /SmoothScalingStart | T | W | 以先前指定的目標身高平滑縮放<br>身高單位根據/IsMultiplier而定 |
| /Meters/SmoothScalingStart | T | W | 以先前指定的目標身高平滑縮放(公尺) |
| /Multiplier/SmoothScalingStart | T | W | 以先前指定的目標身高平滑縮放(倍數) |
| /ScalingEyeHeight | f | W | 以輸入的數值為目標身高立刻縮放<br>身高單位根據/IsMultiplier而定 |
| /Meters/ScalingEyeHeight | f | W | 以輸入的數值為目標身高立刻縮放(公尺) |
| /Multiplier/ScalingEyeHeight | f | W | 以輸入的數值為目標身高立刻縮放(倍數) |
| /SmoothScalingEyeHeight | f | W | 以輸入的數值為目標身高平滑縮放<br>身高單位根據/IsMultiplier而定 |
| /Meters/SmoothScalingEyeHeight | f | W | 以輸入的數值為目標身高平滑縮放(公尺) |
| /Multiplier/SmoothScalingEyeHeight | f | W | 以輸入的數值為目標身高立刻縮放(倍數) |
| /ScalingPercentage | f | W | 以輸入的數值為當前身高百分比數立刻縮放 |
| /SmoothScalingPercentage | f | W | 以輸入的數值為當前身高百分比數平滑縮放 |
|  |  |  | 例如當前身高2公尺，輸入數值為200，則代表縮放到4公尺 |
| /ScalingDiffPercentage | f | W | 以輸入的數值為當前身高百分比數差值立刻縮放 |
| /SmoothScalingDiffPercentage | f | W | 以輸入的數值為當前身高百分比數差值平滑縮放 |
|  |  |  | 說明: 例如當前身高2公尺，輸入數值為+50，則代表縮放到3公尺 |
| /SetEyeHeight | f | W | 設定目標身高值(公尺) |
| /SetMultiplier | f | W | 設定目標身高值(倍數) |
| /SetPercentage | f | W | 設定目標身高值(當前身高百分比) |
| /SetDiffPercentage | f | W | 設定目標身高值(當前身高百分比差值) |
| /SetScalingTime  | f | W | 設定縮放時間(秒) |
| /SetScalingRate  | f | W | 設定縮放速率(倍/秒) |
| /ScalingTimeValue  | f | R | 取得縮放時間 |
| /ScalingRateValue  | f | R | 取得縮放速率 |
| /SwitchAutoAbort | T/F | RW | 取得或設定自動中斷狀態。 |
| /SetMaxEyeHeight | f | W | 設定縮放最大身高 |
| /MaxEyeHeightValue | f | R | 取得縮放最大身高 |
| /SetMinEyeHeight | f | W | 設定縮放最小身高 |
| /MinEyeHeightValue | f | R | 取得縮放最小身高 |
| /SwitchFixedRate | T/F | RW | 取得或設定定速縮放狀態。 |
| /SetFixedRate | f | W | 設定啟用定速縮放 (平滑縮放模式為固定速率) |
| /SetFixedTime | f | W | 設定禁用定速縮放 (平滑縮放模式為固定時間) |
| /IsMultiplier | T/F | RW | 取得或設定目標身高是否為倍率 |
| /GrowUp | f | W | 以輸入的速率逐漸變大至身高上限 |
| /ShrinkDown | f | W | 以輸入的速率逐漸變小至身高下限 |
|  |  |  | 逐漸變大/變小的速率<br>輸入值需大於0.2才會啟動縮放<br>實際速率值介於1.5至2倍/秒之間 |
| /Gesture/Mode | i | RW | 取得或設定手勢縮放模式 |
| /Gesture/WorldScaling | T/F | RW | 取得或設定是否啟用世界縮放模式 |
| /Gesture/DoubleMuteSetGesture | T/F | RW | 取得或設定是否啟用雙擊靜音鍵切換縮放手勢 |
| /DefaultValue{n}/Value | f | R | 取得預設選單位置{n}的數值 |
| DefaultValue{n}/SetValue | T/F | RW | 取得預設選單位置{n}的數值的設定狀態<br>設為T時複製當前身高為暫存身高<br>設為F時刪除暫存身高 (詳見3.2節說明) |
| /DefaultValue{n}/Scaling | T | W | 以預設選單位置{n}的數值立刻縮放 |
| /DefaultValue{n}/Smooth  | T | W | 以預設選單位置{n}的數值平滑縮放 |
| /DefaultValue{n}/PercentageScaling | T | W | 以預設選單位置{n}的數值為當前身高倍數立刻縮放 |
| /DefaultValue{n}/PercentageSmooth | T | W | 以預設選單位置{n}的數值為當前身高倍數差值立刻縮放 |
|  |  |  | 為配合VRC選單Radial顯示數值1為100%，此處參數名稱雖為Percentage，設定時請以當前身高的倍數為單位<br>例如當前身高2公尺，輸入數值為2，則代表縮放到4公尺 |
| /DefaultValue{n}/DiffPercentageScaling | T | W | 以預設選單位置{n}的數值為當前身高倍數平滑縮放 |
| /DefaultValue{n}/DiffPercentageSmooth | T | W | 以預設選單位置{n}的數值為當前身高倍數差值平滑縮放 |
|  |  |  | 為配合VRC選單Radial顯示數值1為100%，此處參數名稱雖為Percentage，設定時請以當前身高的倍數為單位<br>例如當前身高2公尺，輸入數值為+0.5，則代表縮放到3公尺 |
| /DefaultValue{n}/Save | T | W | 將目前身高數值複製到預設選單位置{n}的數值 |
| /DefaultValue{n}/Delete | T | W | 刪除預設選單位置{n}的使用者暫存數值 |
| /DefaultValue{n}/InputValue | f | W | 將指定數值設為預設選單位置{n}的數值(詳見3.2節說明) |

以 /GrowUp 與 /ShrinkDown 參數為例，將其加入FourAxisPuppet選單的Up Param 與 Down Param中，就能成為用上下按鈕調整身高的控制器

![image](image/img3.1.1.png)

以手勢縮放設定 /Gesture/Mode 為例，可使用Toggle製作切換控制模式的開關

![image](image/img3.1.2.png)

## **3.2 尺寸選單同步功能**

VRC Scaler OSC其中一項特色是使用者能自訂精簡模式的縮放選單數值，在前一節中提到的/DefaultValue{n}系列參數即為將此功能同步至avatar插件中尺寸清單的實作方法。除了選單同步功能外，使用者也可以透過此功能於VRChat中透過選單暫存身高數值，以便未來需要用時直接縮放到暫存值。  

目前位置分配如下：
| 位置編號 | 預設值 | 用途 |
| :---- | :---- | :---- |
| 0 | 0 | 保留為暫存身高功能<br>預設值為0代表縮放至avatar預設身高 |
| 1 ~ 25 | 0.01 ~ 10000 | 預設身高選單(公尺或倍數) |
| 26 ~ 33 | -0.5 ~ 0.5 | 預設身高選單(當前身高百分比) |
| 34 ~ 100 | 0 | 使用者自定義 |

要在VRC Expressions Menu中加入尺寸選單，請使用`RadialPuppet`，並將`Rotation`的參數設為/DefaultValue{n}/Value，使數值可以呈現在選單上方。接著再根據這個選單的功能需求設定`Parameter`的參數，例如設定為/DefaultValue{n}/Scaling代表開啟這個`RadialPuppet`時會以/DefaultValue{n}/Value的數值立刻縮放，同時選單會因OSC回傳false封包而立刻關閉。  

![image](image/img3.2.1.png)

要對每個尺寸選單選項增加暫存身高數值的功能，可使用`Toggle`或`Button`製作對應的功能選項。選用`Button`可分別製作`暫存`與`刪除`兩種按鈕。`暫存`按鈕中的`Parameter`設為/DefaultValue{n}/Copy，點擊按鈕時將目前身高暫存至對應的/DefaultValue{n}/Value中。`刪除`按鈕中的`Parameter`設為/DefaultValue{n}/Delete，點擊按鈕時將暫存數值回復成預設值。  

選用`Toggle`並將`Parameter`的參數設為/SetValue，可製作設定/刪除暫存值的開關。 

![image](image/img3.2.2.png)

要直接將特定身高數值存入尺寸選單中，可對/DefaultValue{n}/InputValue設定大於0的數值。若數值設為-1則代表刪除使用者暫存值。當VRC Scaler OSC應用程式收到設定值後，會自動將此參數值設為0，因此您可以透過檢查此參數值是否變為0來判斷此設定指令是否完成。

### **3.3 MCC參數轉發功能**

Menu Control Camera (MCC)是一款能用VRC Expressions Menu控制VRC相機的avatar插件，其控制原理為透過向OSC應用程式傳送avatar參數，並回送usercamera封包給VRChat，以便讓VRC選單也具備控制相機的功能，避免avatar身高過高時難以點擊相機面板上的選項。PC模式無此問題，可直接用滑鼠點選相機面板上的選項。  

預設的avatar參數名稱開頭是MCC，對應的OSC封包路徑開頭字串是/avatar/parameters/MCC。VRC Scaler OSC應用程式會將對應的參數轉換成OSC控制相機的封包路徑/usercamera。以`5秒後拍照`指令為例，VRC選單中button的參數是MCC/CaptureDelayed，當使用者點擊按鈕後，會透過MCC參數轉發功能接收OSC封包/avatar/parameters/MCC/CaptureDelayed，並回送/usercamera/CaptureDelayed至VRChat，讓VRC相機執行5秒後拍照的指令。  

目前支援的相機參數如下表: 

| 參數名稱 | 型別 | 說明 |
| :---- | :---- | :---- |
| Mode | i | 相機模式 <br>0: Off <br>1: Photo <br>2: Stream <br>3: Emoji <br>4: Multilayer <br>5: Print <br>6: Drone <br> 為了避免意外關閉相機，會自動忽略數值為0的OSC封包。 |
| Close <br>Capture <br>CaptureDelayed | T | 這些參數為按鈕性質，只接受true值封包，並且會自動回送false值封包 若相機未開啟，VRChat.exe將於開啟相機後執行拍照指令(Capture, CaptureDelayed)。 |
| TriggerTakesPhotos <br>DollyPathsStayVisible <br>RollWhileFlying <br>GreenScreen <br>Lock <br>OrientationIsLandscape <br>Flying <br>SmoothMovement <br>AutoLevelRoll <br>AutoLevelPitch <br>ShowUIInCamera <br>LocalPlayer <br>RemotePlayer <br>Environment <br>Streaming <br>ShowFocus <br>AudioFromCamera <br>LookAtMe | T/F | 這些參數只會在相機開啟時才能經由發送/usercamera進行設定，若相機未開啟時更動選單數值，可能導致選單數值與相機實際數值不一致。參數詳細說明請參閱[官方公告](https://docs.vrchat.com/docs/vrchat-202533#osc-camera-endpoints)。 |
| Zoom <br>Exposure <br>FocalDistance <br>Aperture <br>FlySpeed <br>TurnSpeed <br>SmoothingStrength <br>PhotoRate <br>Duration | f | float型別參數各有不同範圍與預設值，為使其能由選單RadialPuppet設定數值，於/avatar/parameters/MCC中的數值範圍調整為0至1，並以0.5作為預設值。詳細說明與預設值請參閱[官方公告](https://docs.vrchat.com/docs/vrchat-202533#osc-camera-endpoints)。此外，這些參數只會在相機開啟時才能經由發送/usercamera進行設定，因此選單中的數值可能與相機實際參數值不同。 |
| Hue <br>Saturation <br>Lightness | f | 綠幕顏色設定於/avatar/parameters/MCC中的數值範圍調整為0至1，並以1為預設值。 |
| LookAtMeXOffset <br>LookAtMeYOffset | f | 此參數不直接轉換為/usercamera參數，而是做為選單TwoAxisPuppet的參數使用，範圍介於-1至1之間。當數值大於0.5或小於-0.5時會開始平滑調整/usercamera/LookAtMeXOffset與/usercamera/LookAtMeYOffset。 |
| LookAtMeOffsetPuppetOn | T/F | 此參數不屬於/usercamera參數，僅為了判斷當下是否正在透過選單調整LookAtMeX/YOffset時使用。 |

## **四、服務條款**

### **4.1 授權條款**

本軟體採用 MIT 授權條款。您可以免費獲得軟體不受限制的使用許可，包含使用、複製、修改、合併、出版發行、散布、再授權和/或販售軟體及軟體的副本，及授予被供應人同等權利，但必須在所有副本中保留以上著作權聲明及註明原始作者。

### **4.2 免責聲明與保證限制**

本軟體以「現狀 (As-is)」提供。作者會盡力修復問題，但不保證本工具可於 VRChat 中永久正常使用。您必須理解並同意，本軟體之尺寸縮放及其他功能，未來可能因 VRChat 改版而失效。  
若因使用本軟體或因使用不當造成任何損失(包含使用者本人或第三者)，作者不負擔任何賠償責任。
