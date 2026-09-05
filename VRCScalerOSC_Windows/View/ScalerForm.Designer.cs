namespace VRCScalerOSC_Windows
{
    partial class ScalerForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScalerForm));
            labelOSCSendPort = new Label();
            textBoxSendPort = new TextBox();
            labelOSCReceivePort = new Label();
            textBoxReceivePort = new TextBox();
            labelOSCIP = new Label();
            textBoxIP = new TextBox();
            buttonOSCSetup = new Button();
            buttonChangeScale = new Button();
            buttonResetHeight = new Button();
            groupBoxHeight = new GroupBox();
            buttonHeightRange = new Button();
            labelHeightRange = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            buttonComboEyeHeight = new Button();
            comboBoxTargetEyeHeight = new ComboBox();
            comboBoxIsMultiplier = new ComboBox();
            groupBoxScalingTime = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            checkBoxFixedRate = new CheckBox();
            panel3 = new Panel();
            panel4 = new Panel();
            buttonComboScalingTime = new Button();
            comboBoxScalingTime = new ComboBox();
            comboBoxScalingRate = new ComboBox();
            checkBoxAutoAbort = new CheckBox();
            labelSec = new Label();
            groupBoxOSCConfig = new GroupBox();
            checkBoxOSCRandomReceiverPort = new CheckBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            buttonOSCStop = new Button();
            buttonStop = new Button();
            progressBarScaling = new ProgressBar();
            tableLayoutPanelStd = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            labelSCS = new Label();
            groupBoxSetting = new GroupBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            buttonLanguage = new Button();
            buttonFormSize = new Button();
            buttonLite = new Button();
            groupBoxCustom = new GroupBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            buttonCustomImport = new Button();
            buttonCustomExport = new Button();
            groupBoxGesture = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            checkBoxWorldScaling = new CheckBox();
            comboBoxGesture = new ComboBox();
            checkBoxGestureMuteDoubleClickMode = new CheckBox();
            contextMenuStripFormSize = new ContextMenuStrip(components);
            toolStripMenuItemFormSize1x = new ToolStripMenuItem();
            toolStripMenuItemFormSize2x = new ToolStripMenuItem();
            toolStripMenuItemFormSize3x = new ToolStripMenuItem();
            toolStripMenuItemFormSize4x = new ToolStripMenuItem();
            contextMenuStripLanguage = new ContextMenuStrip(components);
            toolStripMenuItemLangEN = new ToolStripMenuItem();
            toolStripMenuItemLangJP = new ToolStripMenuItem();
            toolStripMenuItemLangKR = new ToolStripMenuItem();
            toolStripMenuItemLangCN = new ToolStripMenuItem();
            toolStripMenuItemLangTW = new ToolStripMenuItem();
            tableLayoutPanelLite = new TableLayoutPanel();
            buttonSet23 = new Button();
            buttonSet22 = new Button();
            buttonSet21 = new Button();
            buttonSet17 = new Button();
            buttonSet16 = new Button();
            buttonSet15 = new Button();
            buttonSet14 = new Button();
            buttonSet13 = new Button();
            buttonSet25 = new Button();
            buttonSet24 = new Button();
            buttonSet20 = new Button();
            buttonSet19 = new Button();
            buttonSet18 = new Button();
            checkBoxInstant = new CheckBox();
            buttonResetHeightLite = new Button();
            buttonSet12 = new Button();
            buttonSet11 = new Button();
            buttonSet10 = new Button();
            buttonStop2 = new Button();
            buttonSet9 = new Button();
            buttonSet8 = new Button();
            buttonSet7 = new Button();
            buttonSet6 = new Button();
            buttonSet5 = new Button();
            buttonSet4 = new Button();
            buttonStd = new Button();
            buttonSet3 = new Button();
            buttonSet2 = new Button();
            buttonSet1 = new Button();
            checkBoxIsMultiplier = new CheckBox();
            tableLayoutPanelLitePercentage = new TableLayoutPanel();
            buttonSet26 = new Button();
            buttonSet27 = new Button();
            buttonSet28 = new Button();
            buttonSet29 = new Button();
            buttonSet30 = new Button();
            buttonSet31 = new Button();
            buttonSet32 = new Button();
            buttonSet33 = new Button();
            splitContainer1 = new SplitContainer();
            flowLayoutPanelAvatarHeight = new FlowLayoutPanel();
            labelCEH = new Label();
            labelCEHV = new Label();
            labelDEH = new Label();
            labelDEHV = new Label();
            labelSF = new Label();
            labelSFV = new Label();
            labelGetWristInfoFailed = new Label();
            labelAvatarScalingDisabled = new Label();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            contextMenuStripHetightRange = new ContextMenuStrip(components);
            toolStripMenuItemHeightRangeVRChatAvatar = new ToolStripMenuItem();
            toolStripMenuItemHeightRangeVRChatWorld = new ToolStripMenuItem();
            toolStripMenuItemHeightRangeAdvanced = new ToolStripMenuItem();
            toolStripMenuItemHeightRangeMaximum = new ToolStripMenuItem();
            toolStripMenuItemHeightRangeUserSettings = new ToolStripMenuItem();
            toolStripMenuItemHeightRangeSetUpper = new ToolStripMenuItem();
            toolStripMenuItemHeightRangeSetLower = new ToolStripMenuItem();
            groupBoxHeight.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBoxScalingTime.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            groupBoxOSCConfig.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanelStd.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBoxSetting.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            groupBoxCustom.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            groupBoxGesture.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            contextMenuStripFormSize.SuspendLayout();
            contextMenuStripLanguage.SuspendLayout();
            tableLayoutPanelLite.SuspendLayout();
            tableLayoutPanelLitePercentage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanelAvatarHeight.SuspendLayout();
            contextMenuStripHetightRange.SuspendLayout();
            SuspendLayout();
            // 
            // labelOSCSendPort
            // 
            labelOSCSendPort.Dock = DockStyle.Fill;
            labelOSCSendPort.Location = new Point(1, 35);
            labelOSCSendPort.Margin = new Padding(1, 3, 1, 0);
            labelOSCSendPort.Name = "labelOSCSendPort";
            labelOSCSendPort.Size = new Size(161, 29);
            labelOSCSendPort.TabIndex = 1;
            labelOSCSendPort.Text = "Send port:";
            labelOSCSendPort.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxSendPort
            // 
            textBoxSendPort.Dock = DockStyle.Fill;
            textBoxSendPort.Location = new Point(164, 33);
            textBoxSendPort.Margin = new Padding(1, 1, 1, 0);
            textBoxSendPort.Name = "textBoxSendPort";
            textBoxSendPort.Size = new Size(89, 33);
            textBoxSendPort.TabIndex = 4;
            textBoxSendPort.Text = "9000";
            // 
            // labelOSCReceivePort
            // 
            labelOSCReceivePort.Dock = DockStyle.Fill;
            labelOSCReceivePort.Location = new Point(1, 67);
            labelOSCReceivePort.Margin = new Padding(1, 3, 1, 0);
            labelOSCReceivePort.Name = "labelOSCReceivePort";
            labelOSCReceivePort.Size = new Size(161, 29);
            labelOSCReceivePort.TabIndex = 2;
            labelOSCReceivePort.Text = "Receive port:";
            labelOSCReceivePort.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxReceivePort
            // 
            textBoxReceivePort.Dock = DockStyle.Fill;
            textBoxReceivePort.Location = new Point(164, 65);
            textBoxReceivePort.Margin = new Padding(1, 1, 1, 0);
            textBoxReceivePort.Name = "textBoxReceivePort";
            textBoxReceivePort.Size = new Size(89, 33);
            textBoxReceivePort.TabIndex = 5;
            textBoxReceivePort.Text = "9001";
            // 
            // labelOSCIP
            // 
            labelOSCIP.Dock = DockStyle.Fill;
            labelOSCIP.Location = new Point(1, 3);
            labelOSCIP.Margin = new Padding(1, 3, 1, 0);
            labelOSCIP.Name = "labelOSCIP";
            labelOSCIP.Size = new Size(161, 29);
            labelOSCIP.TabIndex = 3;
            labelOSCIP.Text = "IP Address:";
            labelOSCIP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxIP
            // 
            tableLayoutPanel5.SetColumnSpan(textBoxIP, 2);
            textBoxIP.Dock = DockStyle.Fill;
            textBoxIP.Location = new Point(164, 1);
            textBoxIP.Margin = new Padding(1, 1, 1, 0);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(199, 33);
            textBoxIP.TabIndex = 6;
            textBoxIP.Text = "127.0.0.1";
            // 
            // buttonOSCSetup
            // 
            buttonOSCSetup.AutoSize = true;
            buttonOSCSetup.Dock = DockStyle.Top;
            buttonOSCSetup.ForeColor = Color.Blue;
            buttonOSCSetup.Location = new Point(254, 64);
            buttonOSCSetup.Margin = new Padding(0);
            buttonOSCSetup.Name = "buttonOSCSetup";
            buttonOSCSetup.Size = new Size(110, 32);
            buttonOSCSetup.TabIndex = 7;
            buttonOSCSetup.Text = "Setup";
            buttonOSCSetup.UseVisualStyleBackColor = true;
            buttonOSCSetup.Click += buttonOSCSetup_Click;
            // 
            // buttonChangeScale
            // 
            buttonChangeScale.Dock = DockStyle.Fill;
            buttonChangeScale.ForeColor = Color.Green;
            buttonChangeScale.Location = new Point(3, 29);
            buttonChangeScale.Margin = new Padding(3, 4, 3, 4);
            buttonChangeScale.Name = "buttonChangeScale";
            buttonChangeScale.Size = new Size(182, 44);
            buttonChangeScale.TabIndex = 24;
            buttonChangeScale.Text = "Scaling Now";
            buttonChangeScale.UseVisualStyleBackColor = true;
            buttonChangeScale.Click += buttonChangeScale_Click;
            // 
            // buttonResetHeight
            // 
            buttonResetHeight.Dock = DockStyle.Fill;
            buttonResetHeight.Location = new Point(181, 0);
            buttonResetHeight.Margin = new Padding(0);
            buttonResetHeight.Name = "buttonResetHeight";
            buttonResetHeight.Size = new Size(183, 32);
            buttonResetHeight.TabIndex = 25;
            buttonResetHeight.Text = "Reset Height";
            buttonResetHeight.UseVisualStyleBackColor = true;
            buttonResetHeight.Click += buttonResetHeight_Click;
            // 
            // groupBoxHeight
            // 
            tableLayoutPanelStd.SetColumnSpan(groupBoxHeight, 2);
            groupBoxHeight.Controls.Add(buttonHeightRange);
            groupBoxHeight.Controls.Add(labelHeightRange);
            groupBoxHeight.Controls.Add(tableLayoutPanel3);
            groupBoxHeight.Dock = DockStyle.Fill;
            groupBoxHeight.Location = new Point(3, 4);
            groupBoxHeight.Margin = new Padding(3, 4, 3, 4);
            groupBoxHeight.Name = "groupBoxHeight";
            groupBoxHeight.Padding = new Padding(3, 2, 3, 4);
            groupBoxHeight.Size = new Size(370, 64);
            groupBoxHeight.TabIndex = 28;
            groupBoxHeight.TabStop = false;
            groupBoxHeight.Text = "Avatar EyeHeight";
            // 
            // buttonHeightRange
            // 
            buttonHeightRange.BackgroundImage = (Image)resources.GetObject("buttonHeightRange.BackgroundImage");
            buttonHeightRange.BackgroundImageLayout = ImageLayout.Zoom;
            buttonHeightRange.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            buttonHeightRange.Location = new Point(332, 0);
            buttonHeightRange.Margin = new Padding(0);
            buttonHeightRange.Name = "buttonHeightRange";
            buttonHeightRange.Size = new Size(22, 22);
            buttonHeightRange.TabIndex = 2;
            buttonHeightRange.UseVisualStyleBackColor = true;
            buttonHeightRange.Click += buttonHeightRange_Click;
            // 
            // labelHeightRange
            // 
            labelHeightRange.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelHeightRange.AutoSize = true;
            labelHeightRange.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            labelHeightRange.Location = new Point(183, 4);
            labelHeightRange.Name = "labelHeightRange";
            labelHeightRange.Size = new Size(138, 16);
            labelHeightRange.TabIndex = 1;
            labelHeightRange.Text = "Range: 0.01 to 10000m";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(panel1, 0, 0);
            tableLayoutPanel3.Controls.Add(buttonResetHeight, 2, 0);
            tableLayoutPanel3.Controls.Add(comboBoxIsMultiplier, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 28);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(364, 32);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(comboBoxTargetEyeHeight);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(116, 32);
            panel1.TabIndex = 35;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonComboEyeHeight);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(86, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(30, 32);
            panel2.TabIndex = 30;
            // 
            // buttonComboEyeHeight
            // 
            buttonComboEyeHeight.Dock = DockStyle.Top;
            buttonComboEyeHeight.Location = new Point(0, 0);
            buttonComboEyeHeight.Margin = new Padding(0);
            buttonComboEyeHeight.Name = "buttonComboEyeHeight";
            buttonComboEyeHeight.Size = new Size(30, 32);
            buttonComboEyeHeight.TabIndex = 29;
            buttonComboEyeHeight.Text = "▼";
            buttonComboEyeHeight.UseVisualStyleBackColor = true;
            buttonComboEyeHeight.Click += buttonCombo_Click;
            // 
            // comboBoxTargetEyeHeight
            // 
            comboBoxTargetEyeHeight.BackColor = Color.FromArgb(255, 255, 192);
            comboBoxTargetEyeHeight.Dock = DockStyle.Fill;
            comboBoxTargetEyeHeight.FlatStyle = FlatStyle.Flat;
            comboBoxTargetEyeHeight.FormattingEnabled = true;
            comboBoxTargetEyeHeight.Location = new Point(0, 0);
            comboBoxTargetEyeHeight.Margin = new Padding(3, 2, 3, 2);
            comboBoxTargetEyeHeight.Name = "comboBoxTargetEyeHeight";
            comboBoxTargetEyeHeight.Size = new Size(116, 32);
            comboBoxTargetEyeHeight.TabIndex = 28;
            comboBoxTargetEyeHeight.DropDownClosed += comboBoxEyeHeight_TextChanged;
            comboBoxTargetEyeHeight.KeyDown += comboBoxTargetEyeHeight_KeyDown;
            comboBoxTargetEyeHeight.Leave += comboBoxEyeHeight_TextChanged;
            // 
            // comboBoxIsMultiplier
            // 
            comboBoxIsMultiplier.Dock = DockStyle.Top;
            comboBoxIsMultiplier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIsMultiplier.FormattingEnabled = true;
            comboBoxIsMultiplier.Items.AddRange(new object[] { "公尺", "倍" });
            comboBoxIsMultiplier.Location = new Point(116, 0);
            comboBoxIsMultiplier.Margin = new Padding(0);
            comboBoxIsMultiplier.Name = "comboBoxIsMultiplier";
            comboBoxIsMultiplier.Size = new Size(65, 32);
            comboBoxIsMultiplier.TabIndex = 36;
            comboBoxIsMultiplier.SelectedIndexChanged += comboBoxIsMultiplier_SelectedIndexChanged;
            // 
            // groupBoxScalingTime
            // 
            groupBoxScalingTime.Controls.Add(tableLayoutPanel4);
            groupBoxScalingTime.Dock = DockStyle.Fill;
            groupBoxScalingTime.Location = new Point(3, 74);
            groupBoxScalingTime.Margin = new Padding(3, 2, 3, 2);
            groupBoxScalingTime.Name = "groupBoxScalingTime";
            groupBoxScalingTime.Padding = new Padding(3, 2, 3, 2);
            groupBoxScalingTime.Size = new Size(182, 126);
            groupBoxScalingTime.TabIndex = 29;
            groupBoxScalingTime.TabStop = false;
            groupBoxScalingTime.Text = "Scaling time (s)";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel4.Controls.Add(checkBoxFixedRate, 0, 1);
            tableLayoutPanel4.Controls.Add(panel3, 0, 0);
            tableLayoutPanel4.Controls.Add(checkBoxAutoAbort, 0, 2);
            tableLayoutPanel4.Controls.Add(labelSec, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 28);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Size = new Size(176, 96);
            tableLayoutPanel4.TabIndex = 36;
            // 
            // checkBoxFixedRate
            // 
            tableLayoutPanel4.SetColumnSpan(checkBoxFixedRate, 2);
            checkBoxFixedRate.Dock = DockStyle.Fill;
            checkBoxFixedRate.Location = new Point(3, 34);
            checkBoxFixedRate.Margin = new Padding(3, 2, 3, 2);
            checkBoxFixedRate.Name = "checkBoxFixedRate";
            checkBoxFixedRate.Size = new Size(170, 28);
            checkBoxFixedRate.TabIndex = 37;
            checkBoxFixedRate.Text = "Fixed rate";
            checkBoxFixedRate.UseVisualStyleBackColor = true;
            checkBoxFixedRate.CheckedChanged += checkBoxFixedRate_CheckedChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(comboBoxScalingTime);
            panel3.Controls.Add(comboBoxScalingRate);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(105, 32);
            panel3.TabIndex = 36;
            // 
            // panel4
            // 
            panel4.Controls.Add(buttonComboScalingTime);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(75, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(30, 32);
            panel4.TabIndex = 30;
            // 
            // buttonComboScalingTime
            // 
            buttonComboScalingTime.Dock = DockStyle.Top;
            buttonComboScalingTime.Location = new Point(0, 0);
            buttonComboScalingTime.Margin = new Padding(0);
            buttonComboScalingTime.Name = "buttonComboScalingTime";
            buttonComboScalingTime.Size = new Size(30, 32);
            buttonComboScalingTime.TabIndex = 29;
            buttonComboScalingTime.Text = "▼";
            buttonComboScalingTime.UseVisualStyleBackColor = true;
            buttonComboScalingTime.Click += buttonComboScalingTime_Click;
            // 
            // comboBoxScalingTime
            // 
            comboBoxScalingTime.Dock = DockStyle.Fill;
            comboBoxScalingTime.FlatStyle = FlatStyle.Flat;
            comboBoxScalingTime.FormattingEnabled = true;
            comboBoxScalingTime.Items.AddRange(new object[] { "0", "1", "2", "3", "5", "10", "15", "30", "60", "120", "300", "600", "900", "1800", "3600", "7200", "10800", "14400", "18000", "21600", "25600", "28800" });
            comboBoxScalingTime.Location = new Point(0, 0);
            comboBoxScalingTime.Margin = new Padding(3, 2, 3, 2);
            comboBoxScalingTime.Name = "comboBoxScalingTime";
            comboBoxScalingTime.Size = new Size(105, 32);
            comboBoxScalingTime.TabIndex = 28;
            // 
            // comboBoxScalingRate
            // 
            comboBoxScalingRate.Dock = DockStyle.Fill;
            comboBoxScalingRate.FlatStyle = FlatStyle.Flat;
            comboBoxScalingRate.FormattingEnabled = true;
            comboBoxScalingRate.Location = new Point(0, 0);
            comboBoxScalingRate.Margin = new Padding(3, 2, 3, 2);
            comboBoxScalingRate.Name = "comboBoxScalingRate";
            comboBoxScalingRate.Size = new Size(105, 32);
            comboBoxScalingRate.TabIndex = 37;
            // 
            // checkBoxAutoAbort
            // 
            checkBoxAutoAbort.Checked = true;
            checkBoxAutoAbort.CheckState = CheckState.Checked;
            tableLayoutPanel4.SetColumnSpan(checkBoxAutoAbort, 2);
            checkBoxAutoAbort.Dock = DockStyle.Fill;
            checkBoxAutoAbort.Location = new Point(3, 66);
            checkBoxAutoAbort.Margin = new Padding(3, 2, 3, 2);
            checkBoxAutoAbort.Name = "checkBoxAutoAbort";
            checkBoxAutoAbort.Size = new Size(170, 28);
            checkBoxAutoAbort.TabIndex = 31;
            checkBoxAutoAbort.Text = "Auto-abort";
            checkBoxAutoAbort.UseVisualStyleBackColor = true;
            checkBoxAutoAbort.CheckedChanged += checkBoxAutoAbort_CheckedChanged;
            // 
            // labelSec
            // 
            labelSec.Dock = DockStyle.Fill;
            labelSec.Location = new Point(108, 0);
            labelSec.Name = "labelSec";
            labelSec.Size = new Size(65, 32);
            labelSec.TabIndex = 31;
            labelSec.Text = "s";
            labelSec.TextAlign = ContentAlignment.BottomLeft;
            // 
            // groupBoxOSCConfig
            // 
            groupBoxOSCConfig.Controls.Add(checkBoxOSCRandomReceiverPort);
            groupBoxOSCConfig.Controls.Add(tableLayoutPanel5);
            groupBoxOSCConfig.Dock = DockStyle.Fill;
            groupBoxOSCConfig.Location = new Point(379, 74);
            groupBoxOSCConfig.Margin = new Padding(3, 2, 3, 2);
            groupBoxOSCConfig.Name = "groupBoxOSCConfig";
            groupBoxOSCConfig.Padding = new Padding(3, 2, 3, 2);
            groupBoxOSCConfig.Size = new Size(370, 126);
            groupBoxOSCConfig.TabIndex = 30;
            groupBoxOSCConfig.TabStop = false;
            groupBoxOSCConfig.Text = "OSC Config";
            // 
            // checkBoxOSCRandomReceiverPort
            // 
            checkBoxOSCRandomReceiverPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxOSCRandomReceiverPort.AutoSize = true;
            checkBoxOSCRandomReceiverPort.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            checkBoxOSCRandomReceiverPort.Location = new Point(212, 5);
            checkBoxOSCRandomReceiverPort.Name = "checkBoxOSCRandomReceiverPort";
            checkBoxOSCRandomReceiverPort.Size = new Size(152, 20);
            checkBoxOSCRandomReceiverPort.TabIndex = 37;
            checkBoxOSCRandomReceiverPort.Text = "Random Receiver Port";
            checkBoxOSCRandomReceiverPort.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel5.Controls.Add(buttonOSCSetup, 2, 2);
            tableLayoutPanel5.Controls.Add(buttonOSCStop, 2, 1);
            tableLayoutPanel5.Controls.Add(labelOSCIP, 0, 0);
            tableLayoutPanel5.Controls.Add(textBoxReceivePort, 1, 2);
            tableLayoutPanel5.Controls.Add(textBoxSendPort, 1, 1);
            tableLayoutPanel5.Controls.Add(labelOSCSendPort, 0, 1);
            tableLayoutPanel5.Controls.Add(labelOSCReceivePort, 0, 2);
            tableLayoutPanel5.Controls.Add(textBoxIP, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 28);
            tableLayoutPanel5.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel5.Size = new Size(364, 96);
            tableLayoutPanel5.TabIndex = 36;
            // 
            // buttonOSCStop
            // 
            buttonOSCStop.AutoSize = true;
            buttonOSCStop.Dock = DockStyle.Top;
            buttonOSCStop.ForeColor = Color.Red;
            buttonOSCStop.Location = new Point(254, 32);
            buttonOSCStop.Margin = new Padding(0);
            buttonOSCStop.Name = "buttonOSCStop";
            buttonOSCStop.Size = new Size(110, 32);
            buttonOSCStop.TabIndex = 8;
            buttonOSCStop.Text = "Stop";
            buttonOSCStop.UseVisualStyleBackColor = true;
            buttonOSCStop.Click += buttonOSCStop_Click;
            // 
            // buttonStop
            // 
            buttonStop.Dock = DockStyle.Fill;
            buttonStop.ForeColor = Color.Red;
            buttonStop.Location = new Point(3, 81);
            buttonStop.Margin = new Padding(3, 4, 3, 4);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(182, 45);
            buttonStop.TabIndex = 31;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // progressBarScaling
            // 
            progressBarScaling.Dock = DockStyle.Fill;
            progressBarScaling.Location = new Point(3, 17);
            progressBarScaling.Margin = new Padding(3, 2, 3, 2);
            progressBarScaling.Name = "progressBarScaling";
            progressBarScaling.Size = new Size(182, 6);
            progressBarScaling.Step = 1;
            progressBarScaling.Style = ProgressBarStyle.Continuous;
            progressBarScaling.TabIndex = 32;
            progressBarScaling.Value = 50;
            // 
            // tableLayoutPanelStd
            // 
            tableLayoutPanelStd.ColumnCount = 3;
            tableLayoutPanelStd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelStd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelStd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelStd.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanelStd.Controls.Add(groupBoxHeight, 0, 0);
            tableLayoutPanelStd.Controls.Add(groupBoxScalingTime, 0, 1);
            tableLayoutPanelStd.Controls.Add(groupBoxOSCConfig, 2, 1);
            tableLayoutPanelStd.Controls.Add(groupBoxSetting, 2, 0);
            tableLayoutPanelStd.Controls.Add(groupBoxCustom, 2, 2);
            tableLayoutPanelStd.Controls.Add(groupBoxGesture, 0, 2);
            tableLayoutPanelStd.Dock = DockStyle.Fill;
            tableLayoutPanelStd.Location = new Point(0, 0);
            tableLayoutPanelStd.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanelStd.Name = "tableLayoutPanelStd";
            tableLayoutPanelStd.RowCount = 3;
            tableLayoutPanelStd.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanelStd.RowStyles.Add(new RowStyle(SizeType.Percent, 43F));
            tableLayoutPanelStd.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanelStd.Size = new Size(752, 304);
            tableLayoutPanelStd.TabIndex = 34;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(buttonStop, 0, 3);
            tableLayoutPanel2.Controls.Add(buttonChangeScale, 0, 2);
            tableLayoutPanel2.Controls.Add(progressBarScaling, 0, 1);
            tableLayoutPanel2.Controls.Add(labelSCS, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(188, 72);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Size = new Size(188, 130);
            tableLayoutPanel2.TabIndex = 35;
            // 
            // labelSCS
            // 
            labelSCS.Dock = DockStyle.Fill;
            labelSCS.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            labelSCS.Location = new Point(0, 0);
            labelSCS.Margin = new Padding(0);
            labelSCS.Name = "labelSCS";
            labelSCS.Size = new Size(188, 15);
            labelSCS.TabIndex = 33;
            labelSCS.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBoxSetting
            // 
            groupBoxSetting.Controls.Add(tableLayoutPanel6);
            groupBoxSetting.Dock = DockStyle.Fill;
            groupBoxSetting.Location = new Point(379, 2);
            groupBoxSetting.Margin = new Padding(3, 2, 3, 2);
            groupBoxSetting.Name = "groupBoxSetting";
            groupBoxSetting.Padding = new Padding(3, 2, 3, 2);
            groupBoxSetting.Size = new Size(370, 68);
            groupBoxSetting.TabIndex = 36;
            groupBoxSetting.TabStop = false;
            groupBoxSetting.Text = "Form Settings";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel6.Controls.Add(buttonLanguage, 0, 0);
            tableLayoutPanel6.Controls.Add(buttonFormSize, 1, 0);
            tableLayoutPanel6.Controls.Add(buttonLite, 2, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 28);
            tableLayoutPanel6.Margin = new Padding(0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(364, 38);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // buttonLanguage
            // 
            buttonLanguage.Dock = DockStyle.Fill;
            buttonLanguage.Location = new Point(3, 2);
            buttonLanguage.Margin = new Padding(3, 2, 3, 2);
            buttonLanguage.Name = "buttonLanguage";
            buttonLanguage.Size = new Size(115, 34);
            buttonLanguage.TabIndex = 0;
            buttonLanguage.Text = "Lang.";
            buttonLanguage.UseVisualStyleBackColor = true;
            buttonLanguage.Click += buttonLanguage_Click;
            // 
            // buttonFormSize
            // 
            buttonFormSize.Dock = DockStyle.Fill;
            buttonFormSize.Location = new Point(124, 2);
            buttonFormSize.Margin = new Padding(3, 2, 3, 2);
            buttonFormSize.Name = "buttonFormSize";
            buttonFormSize.Size = new Size(115, 34);
            buttonFormSize.TabIndex = 1;
            buttonFormSize.Text = "Size";
            buttonFormSize.UseVisualStyleBackColor = true;
            buttonFormSize.Click += buttonFormSize_Click;
            // 
            // buttonLite
            // 
            buttonLite.Dock = DockStyle.Fill;
            buttonLite.Location = new Point(245, 2);
            buttonLite.Margin = new Padding(3, 2, 3, 2);
            buttonLite.Name = "buttonLite";
            buttonLite.Size = new Size(116, 34);
            buttonLite.TabIndex = 2;
            buttonLite.Text = "Lite mode";
            buttonLite.UseVisualStyleBackColor = true;
            buttonLite.Click += buttonLite_Click;
            // 
            // groupBoxCustom
            // 
            groupBoxCustom.Controls.Add(tableLayoutPanel7);
            groupBoxCustom.Dock = DockStyle.Fill;
            groupBoxCustom.Location = new Point(379, 205);
            groupBoxCustom.Name = "groupBoxCustom";
            groupBoxCustom.Size = new Size(370, 96);
            groupBoxCustom.TabIndex = 38;
            groupBoxCustom.TabStop = false;
            groupBoxCustom.Text = "Custom Settings";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.Controls.Add(buttonCustomImport, 0, 0);
            tableLayoutPanel7.Controls.Add(buttonCustomExport, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 29);
            tableLayoutPanel7.Margin = new Padding(0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(364, 64);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // buttonCustomImport
            // 
            buttonCustomImport.Dock = DockStyle.Fill;
            buttonCustomImport.Location = new Point(3, 2);
            buttonCustomImport.Margin = new Padding(3, 2, 3, 2);
            buttonCustomImport.Name = "buttonCustomImport";
            buttonCustomImport.Size = new Size(176, 60);
            buttonCustomImport.TabIndex = 0;
            buttonCustomImport.Text = "Import";
            buttonCustomImport.UseVisualStyleBackColor = true;
            buttonCustomImport.Click += buttonCustomImport_Click;
            // 
            // buttonCustomExport
            // 
            buttonCustomExport.Dock = DockStyle.Fill;
            buttonCustomExport.Location = new Point(185, 2);
            buttonCustomExport.Margin = new Padding(3, 2, 3, 2);
            buttonCustomExport.Name = "buttonCustomExport";
            buttonCustomExport.Size = new Size(176, 60);
            buttonCustomExport.TabIndex = 1;
            buttonCustomExport.Text = "Export";
            buttonCustomExport.UseVisualStyleBackColor = true;
            buttonCustomExport.Click += buttonCustomExport_Click;
            // 
            // groupBoxGesture
            // 
            tableLayoutPanelStd.SetColumnSpan(groupBoxGesture, 2);
            groupBoxGesture.Controls.Add(tableLayoutPanel1);
            groupBoxGesture.Dock = DockStyle.Fill;
            groupBoxGesture.Location = new Point(3, 205);
            groupBoxGesture.Name = "groupBoxGesture";
            groupBoxGesture.Size = new Size(370, 96);
            groupBoxGesture.TabIndex = 39;
            groupBoxGesture.TabStop = false;
            groupBoxGesture.Text = "Scaling Gesture";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tableLayoutPanel1.Controls.Add(checkBoxWorldScaling, 1, 0);
            tableLayoutPanel1.Controls.Add(comboBoxGesture, 0, 0);
            tableLayoutPanel1.Controls.Add(checkBoxGestureMuteDoubleClickMode, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 29);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(364, 64);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxWorldScaling
            // 
            checkBoxWorldScaling.Dock = DockStyle.Fill;
            checkBoxWorldScaling.Location = new Point(189, 3);
            checkBoxWorldScaling.Margin = new Padding(0, 3, 0, 3);
            checkBoxWorldScaling.Name = "checkBoxWorldScaling";
            checkBoxWorldScaling.Size = new Size(175, 26);
            checkBoxWorldScaling.TabIndex = 32;
            checkBoxWorldScaling.Text = "World-Scaling";
            checkBoxWorldScaling.UseVisualStyleBackColor = true;
            checkBoxWorldScaling.CheckedChanged += checkBoxWorldScaling_CheckedChanged;
            // 
            // comboBoxGesture
            // 
            comboBoxGesture.Dock = DockStyle.Fill;
            comboBoxGesture.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGesture.Items.AddRange(new object[] { "Disable", "LT + RT", "LG + RG", "LT + RG", "LG + RT", "LT+LG + RT+RG", "LT+LG + RT", "LT+LG + RG", "LT + RT+RG", "LG + RT+RG" });
            comboBoxGesture.Location = new Point(0, 0);
            comboBoxGesture.Margin = new Padding(0, 0, 3, 0);
            comboBoxGesture.Name = "comboBoxGesture";
            comboBoxGesture.Size = new Size(186, 32);
            comboBoxGesture.TabIndex = 0;
            // 
            // checkBoxGestureMuteDoubleClickMode
            // 
            checkBoxGestureMuteDoubleClickMode.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(checkBoxGestureMuteDoubleClickMode, 2);
            checkBoxGestureMuteDoubleClickMode.Dock = DockStyle.Fill;
            checkBoxGestureMuteDoubleClickMode.Location = new Point(3, 35);
            checkBoxGestureMuteDoubleClickMode.Name = "checkBoxGestureMuteDoubleClickMode";
            checkBoxGestureMuteDoubleClickMode.Size = new Size(358, 26);
            checkBoxGestureMuteDoubleClickMode.TabIndex = 33;
            checkBoxGestureMuteDoubleClickMode.Text = "Double-tap Mute to set gestures";
            checkBoxGestureMuteDoubleClickMode.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripFormSize
            // 
            contextMenuStripFormSize.Font = new Font("Microsoft JhengHei", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            contextMenuStripFormSize.Items.AddRange(new ToolStripItem[] { toolStripMenuItemFormSize1x, toolStripMenuItemFormSize2x, toolStripMenuItemFormSize3x, toolStripMenuItemFormSize4x });
            contextMenuStripFormSize.Name = "contextMenuStripFormSize";
            contextMenuStripFormSize.Size = new Size(120, 156);
            // 
            // toolStripMenuItemFormSize1x
            // 
            toolStripMenuItemFormSize1x.Name = "toolStripMenuItemFormSize1x";
            toolStripMenuItemFormSize1x.Size = new Size(119, 38);
            toolStripMenuItemFormSize1x.Text = "1x";
            toolStripMenuItemFormSize1x.Click += formSize_Click;
            // 
            // toolStripMenuItemFormSize2x
            // 
            toolStripMenuItemFormSize2x.Name = "toolStripMenuItemFormSize2x";
            toolStripMenuItemFormSize2x.Size = new Size(119, 38);
            toolStripMenuItemFormSize2x.Text = "2x";
            toolStripMenuItemFormSize2x.Click += formSize_Click;
            // 
            // toolStripMenuItemFormSize3x
            // 
            toolStripMenuItemFormSize3x.Name = "toolStripMenuItemFormSize3x";
            toolStripMenuItemFormSize3x.Size = new Size(119, 38);
            toolStripMenuItemFormSize3x.Text = "3x";
            toolStripMenuItemFormSize3x.Click += formSize_Click;
            // 
            // toolStripMenuItemFormSize4x
            // 
            toolStripMenuItemFormSize4x.Name = "toolStripMenuItemFormSize4x";
            toolStripMenuItemFormSize4x.Size = new Size(119, 38);
            toolStripMenuItemFormSize4x.Text = "4x";
            toolStripMenuItemFormSize4x.Click += formSize_Click;
            // 
            // contextMenuStripLanguage
            // 
            contextMenuStripLanguage.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            contextMenuStripLanguage.Items.AddRange(new ToolStripItem[] { toolStripMenuItemLangEN, toolStripMenuItemLangJP, toolStripMenuItemLangKR, toolStripMenuItemLangCN, toolStripMenuItemLangTW });
            contextMenuStripLanguage.Name = "contextMenuStripLanguage";
            contextMenuStripLanguage.Size = new Size(157, 144);
            // 
            // toolStripMenuItemLangEN
            // 
            toolStripMenuItemLangEN.Name = "toolStripMenuItemLangEN";
            toolStripMenuItemLangEN.Size = new Size(156, 28);
            toolStripMenuItemLangEN.Text = "English";
            toolStripMenuItemLangEN.Click += AutoSelectLanguage;
            // 
            // toolStripMenuItemLangJP
            // 
            toolStripMenuItemLangJP.Name = "toolStripMenuItemLangJP";
            toolStripMenuItemLangJP.Size = new Size(156, 28);
            toolStripMenuItemLangJP.Text = "日本語";
            toolStripMenuItemLangJP.Click += AutoSelectLanguage;
            // 
            // toolStripMenuItemLangKR
            // 
            toolStripMenuItemLangKR.Name = "toolStripMenuItemLangKR";
            toolStripMenuItemLangKR.Size = new Size(156, 28);
            toolStripMenuItemLangKR.Text = "한국어";
            toolStripMenuItemLangKR.Click += AutoSelectLanguage;
            // 
            // toolStripMenuItemLangCN
            // 
            toolStripMenuItemLangCN.Name = "toolStripMenuItemLangCN";
            toolStripMenuItemLangCN.Size = new Size(156, 28);
            toolStripMenuItemLangCN.Text = "简体中文";
            toolStripMenuItemLangCN.Click += AutoSelectLanguage;
            // 
            // toolStripMenuItemLangTW
            // 
            toolStripMenuItemLangTW.Name = "toolStripMenuItemLangTW";
            toolStripMenuItemLangTW.Size = new Size(156, 28);
            toolStripMenuItemLangTW.Text = "繁體中文";
            toolStripMenuItemLangTW.Click += AutoSelectLanguage;
            // 
            // tableLayoutPanelLite
            // 
            tableLayoutPanelLite.ColumnCount = 7;
            tableLayoutPanelLite.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.5F));
            tableLayoutPanelLite.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5F));
            tableLayoutPanelLite.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5F));
            tableLayoutPanelLite.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5F));
            tableLayoutPanelLite.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5F));
            tableLayoutPanelLite.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5F));
            tableLayoutPanelLite.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableLayoutPanelLite.Controls.Add(buttonSet23, 3, 0);
            tableLayoutPanelLite.Controls.Add(buttonSet22, 2, 0);
            tableLayoutPanelLite.Controls.Add(buttonSet21, 1, 0);
            tableLayoutPanelLite.Controls.Add(buttonSet17, 2, 1);
            tableLayoutPanelLite.Controls.Add(buttonSet16, 1, 1);
            tableLayoutPanelLite.Controls.Add(buttonSet15, 5, 2);
            tableLayoutPanelLite.Controls.Add(buttonSet14, 4, 2);
            tableLayoutPanelLite.Controls.Add(buttonSet13, 3, 2);
            tableLayoutPanelLite.Controls.Add(buttonSet25, 5, 0);
            tableLayoutPanelLite.Controls.Add(buttonSet24, 4, 0);
            tableLayoutPanelLite.Controls.Add(buttonSet20, 5, 1);
            tableLayoutPanelLite.Controls.Add(buttonSet19, 4, 1);
            tableLayoutPanelLite.Controls.Add(buttonSet18, 3, 1);
            tableLayoutPanelLite.Controls.Add(checkBoxInstant, 6, 1);
            tableLayoutPanelLite.Controls.Add(buttonResetHeightLite, 6, 4);
            tableLayoutPanelLite.Controls.Add(buttonSet12, 2, 2);
            tableLayoutPanelLite.Controls.Add(buttonSet11, 1, 2);
            tableLayoutPanelLite.Controls.Add(buttonSet10, 5, 3);
            tableLayoutPanelLite.Controls.Add(buttonStop2, 6, 3);
            tableLayoutPanelLite.Controls.Add(buttonSet9, 4, 3);
            tableLayoutPanelLite.Controls.Add(buttonSet8, 3, 3);
            tableLayoutPanelLite.Controls.Add(buttonSet7, 2, 3);
            tableLayoutPanelLite.Controls.Add(buttonSet6, 1, 3);
            tableLayoutPanelLite.Controls.Add(buttonSet5, 5, 4);
            tableLayoutPanelLite.Controls.Add(buttonSet4, 4, 4);
            tableLayoutPanelLite.Controls.Add(buttonStd, 6, 0);
            tableLayoutPanelLite.Controls.Add(buttonSet3, 3, 4);
            tableLayoutPanelLite.Controls.Add(buttonSet2, 2, 4);
            tableLayoutPanelLite.Controls.Add(buttonSet1, 1, 4);
            tableLayoutPanelLite.Controls.Add(checkBoxIsMultiplier, 6, 2);
            tableLayoutPanelLite.Controls.Add(tableLayoutPanelLitePercentage, 0, 0);
            tableLayoutPanelLite.Dock = DockStyle.Fill;
            tableLayoutPanelLite.Location = new Point(0, 0);
            tableLayoutPanelLite.Name = "tableLayoutPanelLite";
            tableLayoutPanelLite.RowCount = 5;
            tableLayoutPanelLite.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelLite.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelLite.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelLite.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelLite.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelLite.Size = new Size(752, 304);
            tableLayoutPanelLite.TabIndex = 35;
            // 
            // buttonSet23
            // 
            buttonSet23.Dock = DockStyle.Fill;
            buttonSet23.Location = new Point(299, 3);
            buttonSet23.Name = "buttonSet23";
            buttonSet23.Size = new Size(103, 54);
            buttonSet23.TabIndex = 45;
            buttonSet23.Text = "3000";
            buttonSet23.UseVisualStyleBackColor = true;
            buttonSet23.Click += buttonLiteScaler_Click;
            // 
            // buttonSet22
            // 
            buttonSet22.Dock = DockStyle.Fill;
            buttonSet22.Location = new Point(190, 3);
            buttonSet22.Name = "buttonSet22";
            buttonSet22.Size = new Size(103, 54);
            buttonSet22.TabIndex = 44;
            buttonSet22.Text = "2000";
            buttonSet22.UseVisualStyleBackColor = true;
            buttonSet22.Click += buttonLiteScaler_Click;
            // 
            // buttonSet21
            // 
            buttonSet21.Dock = DockStyle.Fill;
            buttonSet21.Location = new Point(81, 3);
            buttonSet21.Name = "buttonSet21";
            buttonSet21.Size = new Size(103, 54);
            buttonSet21.TabIndex = 43;
            buttonSet21.Text = "1500";
            buttonSet21.UseVisualStyleBackColor = true;
            buttonSet21.Click += buttonLiteScaler_Click;
            // 
            // buttonSet17
            // 
            buttonSet17.Dock = DockStyle.Fill;
            buttonSet17.Location = new Point(190, 63);
            buttonSet17.Name = "buttonSet17";
            buttonSet17.Size = new Size(103, 54);
            buttonSet17.TabIndex = 42;
            buttonSet17.Text = "200";
            buttonSet17.UseVisualStyleBackColor = true;
            buttonSet17.Click += buttonLiteScaler_Click;
            // 
            // buttonSet16
            // 
            buttonSet16.Dock = DockStyle.Fill;
            buttonSet16.Location = new Point(81, 63);
            buttonSet16.Name = "buttonSet16";
            buttonSet16.Size = new Size(103, 54);
            buttonSet16.TabIndex = 41;
            buttonSet16.Text = "150";
            buttonSet16.UseVisualStyleBackColor = true;
            buttonSet16.Click += buttonLiteScaler_Click;
            // 
            // buttonSet15
            // 
            buttonSet15.Dock = DockStyle.Fill;
            buttonSet15.Location = new Point(517, 123);
            buttonSet15.Name = "buttonSet15";
            buttonSet15.Size = new Size(103, 54);
            buttonSet15.TabIndex = 40;
            buttonSet15.Text = "100";
            buttonSet15.UseVisualStyleBackColor = true;
            buttonSet15.Click += buttonLiteScaler_Click;
            // 
            // buttonSet14
            // 
            buttonSet14.Dock = DockStyle.Fill;
            buttonSet14.Location = new Point(408, 123);
            buttonSet14.Name = "buttonSet14";
            buttonSet14.Size = new Size(103, 54);
            buttonSet14.TabIndex = 39;
            buttonSet14.Text = "50";
            buttonSet14.UseVisualStyleBackColor = true;
            buttonSet14.Click += buttonLiteScaler_Click;
            // 
            // buttonSet13
            // 
            buttonSet13.Dock = DockStyle.Fill;
            buttonSet13.Location = new Point(299, 123);
            buttonSet13.Name = "buttonSet13";
            buttonSet13.Size = new Size(103, 54);
            buttonSet13.TabIndex = 38;
            buttonSet13.Text = "30";
            buttonSet13.UseVisualStyleBackColor = true;
            buttonSet13.Click += buttonLiteScaler_Click;
            // 
            // buttonSet25
            // 
            buttonSet25.Dock = DockStyle.Fill;
            buttonSet25.Location = new Point(517, 3);
            buttonSet25.Name = "buttonSet25";
            buttonSet25.Size = new Size(103, 54);
            buttonSet25.TabIndex = 37;
            buttonSet25.Text = "10000";
            buttonSet25.UseVisualStyleBackColor = true;
            buttonSet25.Click += buttonLiteScaler_Click;
            // 
            // buttonSet24
            // 
            buttonSet24.Dock = DockStyle.Fill;
            buttonSet24.Location = new Point(408, 3);
            buttonSet24.Name = "buttonSet24";
            buttonSet24.Size = new Size(103, 54);
            buttonSet24.TabIndex = 36;
            buttonSet24.Text = "5000";
            buttonSet24.UseVisualStyleBackColor = true;
            buttonSet24.Click += buttonLiteScaler_Click;
            // 
            // buttonSet20
            // 
            buttonSet20.Dock = DockStyle.Fill;
            buttonSet20.Location = new Point(517, 63);
            buttonSet20.Name = "buttonSet20";
            buttonSet20.Size = new Size(103, 54);
            buttonSet20.TabIndex = 35;
            buttonSet20.Text = "1000";
            buttonSet20.UseVisualStyleBackColor = true;
            buttonSet20.Click += buttonLiteScaler_Click;
            // 
            // buttonSet19
            // 
            buttonSet19.Dock = DockStyle.Fill;
            buttonSet19.Location = new Point(408, 63);
            buttonSet19.Name = "buttonSet19";
            buttonSet19.Size = new Size(103, 54);
            buttonSet19.TabIndex = 34;
            buttonSet19.Text = "500";
            buttonSet19.UseVisualStyleBackColor = true;
            buttonSet19.Click += buttonLiteScaler_Click;
            // 
            // buttonSet18
            // 
            buttonSet18.Dock = DockStyle.Fill;
            buttonSet18.Location = new Point(299, 63);
            buttonSet18.Name = "buttonSet18";
            buttonSet18.Size = new Size(103, 54);
            buttonSet18.TabIndex = 33;
            buttonSet18.Text = "300";
            buttonSet18.UseVisualStyleBackColor = true;
            buttonSet18.Click += buttonLiteScaler_Click;
            // 
            // checkBoxInstant
            // 
            checkBoxInstant.Dock = DockStyle.Fill;
            checkBoxInstant.ForeColor = Color.Blue;
            checkBoxInstant.Location = new Point(626, 62);
            checkBoxInstant.Margin = new Padding(3, 2, 3, 2);
            checkBoxInstant.Name = "checkBoxInstant";
            checkBoxInstant.Size = new Size(123, 56);
            checkBoxInstant.TabIndex = 32;
            checkBoxInstant.Text = "Real-time";
            checkBoxInstant.UseVisualStyleBackColor = true;
            // 
            // buttonResetHeightLite
            // 
            buttonResetHeightLite.Dock = DockStyle.Fill;
            buttonResetHeightLite.Location = new Point(626, 243);
            buttonResetHeightLite.Name = "buttonResetHeightLite";
            buttonResetHeightLite.Size = new Size(123, 58);
            buttonResetHeightLite.TabIndex = 15;
            buttonResetHeightLite.Text = "Reset";
            buttonResetHeightLite.UseVisualStyleBackColor = true;
            buttonResetHeightLite.Click += buttonResetHeight_Click;
            // 
            // buttonSet12
            // 
            buttonSet12.Dock = DockStyle.Fill;
            buttonSet12.Location = new Point(190, 123);
            buttonSet12.Name = "buttonSet12";
            buttonSet12.Size = new Size(103, 54);
            buttonSet12.TabIndex = 14;
            buttonSet12.Text = "20";
            buttonSet12.UseVisualStyleBackColor = true;
            buttonSet12.Click += buttonLiteScaler_Click;
            // 
            // buttonSet11
            // 
            buttonSet11.Dock = DockStyle.Fill;
            buttonSet11.Location = new Point(81, 123);
            buttonSet11.Name = "buttonSet11";
            buttonSet11.Size = new Size(103, 54);
            buttonSet11.TabIndex = 13;
            buttonSet11.Text = "15";
            buttonSet11.UseVisualStyleBackColor = true;
            buttonSet11.Click += buttonLiteScaler_Click;
            // 
            // buttonSet10
            // 
            buttonSet10.Dock = DockStyle.Fill;
            buttonSet10.Location = new Point(517, 183);
            buttonSet10.Name = "buttonSet10";
            buttonSet10.Size = new Size(103, 54);
            buttonSet10.TabIndex = 12;
            buttonSet10.Text = "10";
            buttonSet10.UseVisualStyleBackColor = true;
            buttonSet10.Click += buttonLiteScaler_Click;
            // 
            // buttonStop2
            // 
            buttonStop2.Dock = DockStyle.Fill;
            buttonStop2.ForeColor = Color.Red;
            buttonStop2.Location = new Point(626, 183);
            buttonStop2.Name = "buttonStop2";
            buttonStop2.Size = new Size(123, 54);
            buttonStop2.TabIndex = 11;
            buttonStop2.Text = "Stop";
            buttonStop2.UseVisualStyleBackColor = true;
            buttonStop2.Click += buttonStop_Click;
            // 
            // buttonSet9
            // 
            buttonSet9.Dock = DockStyle.Fill;
            buttonSet9.Location = new Point(408, 183);
            buttonSet9.Name = "buttonSet9";
            buttonSet9.Size = new Size(103, 54);
            buttonSet9.TabIndex = 10;
            buttonSet9.Text = "5";
            buttonSet9.UseVisualStyleBackColor = true;
            buttonSet9.Click += buttonLiteScaler_Click;
            // 
            // buttonSet8
            // 
            buttonSet8.Dock = DockStyle.Fill;
            buttonSet8.Location = new Point(299, 183);
            buttonSet8.Name = "buttonSet8";
            buttonSet8.Size = new Size(103, 54);
            buttonSet8.TabIndex = 9;
            buttonSet8.Text = "3";
            buttonSet8.UseVisualStyleBackColor = true;
            buttonSet8.Click += buttonLiteScaler_Click;
            // 
            // buttonSet7
            // 
            buttonSet7.Dock = DockStyle.Fill;
            buttonSet7.Location = new Point(190, 183);
            buttonSet7.Name = "buttonSet7";
            buttonSet7.Size = new Size(103, 54);
            buttonSet7.TabIndex = 8;
            buttonSet7.Text = "2";
            buttonSet7.UseVisualStyleBackColor = true;
            buttonSet7.Click += buttonLiteScaler_Click;
            // 
            // buttonSet6
            // 
            buttonSet6.Dock = DockStyle.Fill;
            buttonSet6.Location = new Point(81, 183);
            buttonSet6.Name = "buttonSet6";
            buttonSet6.Size = new Size(103, 54);
            buttonSet6.TabIndex = 6;
            buttonSet6.Text = "1.5";
            buttonSet6.UseVisualStyleBackColor = true;
            buttonSet6.Click += buttonLiteScaler_Click;
            // 
            // buttonSet5
            // 
            buttonSet5.Dock = DockStyle.Fill;
            buttonSet5.Location = new Point(517, 243);
            buttonSet5.Name = "buttonSet5";
            buttonSet5.Size = new Size(103, 58);
            buttonSet5.TabIndex = 5;
            buttonSet5.Text = "1";
            buttonSet5.UseVisualStyleBackColor = true;
            buttonSet5.Click += buttonLiteScaler_Click;
            // 
            // buttonSet4
            // 
            buttonSet4.Dock = DockStyle.Fill;
            buttonSet4.Location = new Point(408, 243);
            buttonSet4.Name = "buttonSet4";
            buttonSet4.Size = new Size(103, 58);
            buttonSet4.TabIndex = 4;
            buttonSet4.Text = "0.5";
            buttonSet4.UseVisualStyleBackColor = true;
            buttonSet4.Click += buttonLiteScaler_Click;
            // 
            // buttonStd
            // 
            buttonStd.Dock = DockStyle.Fill;
            buttonStd.Location = new Point(626, 3);
            buttonStd.Name = "buttonStd";
            buttonStd.Size = new Size(123, 54);
            buttonStd.TabIndex = 3;
            buttonStd.Text = "back";
            buttonStd.UseVisualStyleBackColor = true;
            buttonStd.Click += buttonStandard_Click;
            // 
            // buttonSet3
            // 
            buttonSet3.Dock = DockStyle.Fill;
            buttonSet3.Location = new Point(299, 243);
            buttonSet3.Name = "buttonSet3";
            buttonSet3.Size = new Size(103, 58);
            buttonSet3.TabIndex = 2;
            buttonSet3.Text = "0.1";
            buttonSet3.UseVisualStyleBackColor = true;
            buttonSet3.Click += buttonLiteScaler_Click;
            // 
            // buttonSet2
            // 
            buttonSet2.Dock = DockStyle.Fill;
            buttonSet2.Location = new Point(190, 243);
            buttonSet2.Name = "buttonSet2";
            buttonSet2.Size = new Size(103, 58);
            buttonSet2.TabIndex = 1;
            buttonSet2.Text = "0.05";
            buttonSet2.UseVisualStyleBackColor = true;
            buttonSet2.Click += buttonLiteScaler_Click;
            // 
            // buttonSet1
            // 
            buttonSet1.Dock = DockStyle.Fill;
            buttonSet1.Location = new Point(81, 243);
            buttonSet1.Name = "buttonSet1";
            buttonSet1.Size = new Size(103, 58);
            buttonSet1.TabIndex = 0;
            buttonSet1.Text = "0.01";
            buttonSet1.UseVisualStyleBackColor = true;
            buttonSet1.Click += buttonLiteScaler_Click;
            // 
            // checkBoxIsMultiplier
            // 
            checkBoxIsMultiplier.Dock = DockStyle.Fill;
            checkBoxIsMultiplier.Location = new Point(626, 122);
            checkBoxIsMultiplier.Margin = new Padding(3, 2, 3, 2);
            checkBoxIsMultiplier.Name = "checkBoxIsMultiplier";
            checkBoxIsMultiplier.Size = new Size(123, 56);
            checkBoxIsMultiplier.TabIndex = 46;
            checkBoxIsMultiplier.Text = "Multiplier";
            checkBoxIsMultiplier.UseVisualStyleBackColor = true;
            checkBoxIsMultiplier.CheckedChanged += checkBoxIsMultiplier_CheckedChanged;
            // 
            // tableLayoutPanelLitePercentage
            // 
            tableLayoutPanelLitePercentage.ColumnCount = 1;
            tableLayoutPanelLitePercentage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelLitePercentage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelLitePercentage.Controls.Add(buttonSet26, 0, 0);
            tableLayoutPanelLitePercentage.Controls.Add(buttonSet27, 0, 1);
            tableLayoutPanelLitePercentage.Controls.Add(buttonSet28, 0, 2);
            tableLayoutPanelLitePercentage.Controls.Add(buttonSet29, 0, 3);
            tableLayoutPanelLitePercentage.Controls.Add(buttonSet30, 0, 4);
            tableLayoutPanelLitePercentage.Controls.Add(buttonSet31, 0, 5);
            tableLayoutPanelLitePercentage.Controls.Add(buttonSet32, 0, 6);
            tableLayoutPanelLitePercentage.Controls.Add(buttonSet33, 0, 7);
            tableLayoutPanelLitePercentage.Dock = DockStyle.Fill;
            tableLayoutPanelLitePercentage.Location = new Point(0, 0);
            tableLayoutPanelLitePercentage.Margin = new Padding(0);
            tableLayoutPanelLitePercentage.Name = "tableLayoutPanelLitePercentage";
            tableLayoutPanelLitePercentage.RowCount = 8;
            tableLayoutPanelLite.SetRowSpan(tableLayoutPanelLitePercentage, 5);
            tableLayoutPanelLitePercentage.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelLitePercentage.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelLitePercentage.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelLitePercentage.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelLitePercentage.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelLitePercentage.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelLitePercentage.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelLitePercentage.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelLitePercentage.Size = new Size(78, 304);
            tableLayoutPanelLitePercentage.TabIndex = 47;
            // 
            // buttonSet26
            // 
            buttonSet26.Dock = DockStyle.Fill;
            buttonSet26.Location = new Point(2, 2);
            buttonSet26.Margin = new Padding(2);
            buttonSet26.Name = "buttonSet26";
            buttonSet26.Size = new Size(74, 34);
            buttonSet26.TabIndex = 0;
            buttonSet26.Text = "+50%";
            buttonSet26.UseVisualStyleBackColor = true;
            buttonSet26.Click += buttonLiteScaler_Click;
            // 
            // buttonSet27
            // 
            buttonSet27.Dock = DockStyle.Fill;
            buttonSet27.Location = new Point(2, 40);
            buttonSet27.Margin = new Padding(2);
            buttonSet27.Name = "buttonSet27";
            buttonSet27.Size = new Size(74, 34);
            buttonSet27.TabIndex = 1;
            buttonSet27.Text = "+25%";
            buttonSet27.UseVisualStyleBackColor = true;
            buttonSet27.Click += buttonLiteScaler_Click;
            // 
            // buttonSet28
            // 
            buttonSet28.Dock = DockStyle.Fill;
            buttonSet28.Location = new Point(2, 78);
            buttonSet28.Margin = new Padding(2);
            buttonSet28.Name = "buttonSet28";
            buttonSet28.Size = new Size(74, 34);
            buttonSet28.TabIndex = 2;
            buttonSet28.Text = "+10%";
            buttonSet28.UseVisualStyleBackColor = true;
            buttonSet28.Click += buttonLiteScaler_Click;
            // 
            // buttonSet29
            // 
            buttonSet29.Dock = DockStyle.Fill;
            buttonSet29.Location = new Point(2, 116);
            buttonSet29.Margin = new Padding(2);
            buttonSet29.Name = "buttonSet29";
            buttonSet29.Size = new Size(74, 34);
            buttonSet29.TabIndex = 3;
            buttonSet29.Text = "+5%";
            buttonSet29.UseVisualStyleBackColor = true;
            buttonSet29.Click += buttonLiteScaler_Click;
            // 
            // buttonSet30
            // 
            buttonSet30.Dock = DockStyle.Fill;
            buttonSet30.Location = new Point(2, 154);
            buttonSet30.Margin = new Padding(2);
            buttonSet30.Name = "buttonSet30";
            buttonSet30.Size = new Size(74, 34);
            buttonSet30.TabIndex = 4;
            buttonSet30.Text = "-5%";
            buttonSet30.UseVisualStyleBackColor = true;
            buttonSet30.Click += buttonLiteScaler_Click;
            // 
            // buttonSet31
            // 
            buttonSet31.Dock = DockStyle.Fill;
            buttonSet31.Location = new Point(2, 192);
            buttonSet31.Margin = new Padding(2);
            buttonSet31.Name = "buttonSet31";
            buttonSet31.Size = new Size(74, 34);
            buttonSet31.TabIndex = 5;
            buttonSet31.Text = "-10%";
            buttonSet31.UseVisualStyleBackColor = true;
            buttonSet31.Click += buttonLiteScaler_Click;
            // 
            // buttonSet32
            // 
            buttonSet32.Dock = DockStyle.Fill;
            buttonSet32.Location = new Point(2, 230);
            buttonSet32.Margin = new Padding(2);
            buttonSet32.Name = "buttonSet32";
            buttonSet32.Size = new Size(74, 34);
            buttonSet32.TabIndex = 6;
            buttonSet32.Text = "-25%";
            buttonSet32.UseVisualStyleBackColor = true;
            buttonSet32.Click += buttonLiteScaler_Click;
            // 
            // buttonSet33
            // 
            buttonSet33.Dock = DockStyle.Fill;
            buttonSet33.Location = new Point(2, 268);
            buttonSet33.Margin = new Padding(2);
            buttonSet33.Name = "buttonSet33";
            buttonSet33.Size = new Size(74, 34);
            buttonSet33.TabIndex = 7;
            buttonSet33.Text = "-50%";
            buttonSet33.UseVisualStyleBackColor = true;
            buttonSet33.Click += buttonLiteScaler_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(6, 6);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanelStd);
            splitContainer1.Panel1.Controls.Add(tableLayoutPanelLite);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanelAvatarHeight);
            splitContainer1.Panel2MinSize = 20;
            splitContainer1.Size = new Size(752, 333);
            splitContainer1.SplitterDistance = 304;
            splitContainer1.TabIndex = 36;
            // 
            // flowLayoutPanelAvatarHeight
            // 
            flowLayoutPanelAvatarHeight.Controls.Add(labelCEH);
            flowLayoutPanelAvatarHeight.Controls.Add(labelCEHV);
            flowLayoutPanelAvatarHeight.Controls.Add(labelDEH);
            flowLayoutPanelAvatarHeight.Controls.Add(labelDEHV);
            flowLayoutPanelAvatarHeight.Controls.Add(labelSF);
            flowLayoutPanelAvatarHeight.Controls.Add(labelSFV);
            flowLayoutPanelAvatarHeight.Controls.Add(labelGetWristInfoFailed);
            flowLayoutPanelAvatarHeight.Controls.Add(labelAvatarScalingDisabled);
            flowLayoutPanelAvatarHeight.Dock = DockStyle.Fill;
            flowLayoutPanelAvatarHeight.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            flowLayoutPanelAvatarHeight.Location = new Point(0, 0);
            flowLayoutPanelAvatarHeight.Margin = new Padding(0);
            flowLayoutPanelAvatarHeight.Name = "flowLayoutPanelAvatarHeight";
            flowLayoutPanelAvatarHeight.Size = new Size(752, 25);
            flowLayoutPanelAvatarHeight.TabIndex = 38;
            // 
            // labelCEH
            // 
            labelCEH.AutoSize = true;
            labelCEH.Location = new Point(3, 0);
            labelCEH.Name = "labelCEH";
            labelCEH.Size = new Size(112, 16);
            labelCEH.TabIndex = 0;
            labelCEH.Text = "Current EyeHeight:";
            // 
            // labelCEHV
            // 
            labelCEHV.AutoSize = true;
            labelCEHV.Location = new Point(121, 0);
            labelCEHV.Name = "labelCEHV";
            labelCEHV.Size = new Size(85, 16);
            labelCEHV.TabIndex = 1;
            labelCEHV.Text = "(wait loading)";
            // 
            // labelDEH
            // 
            labelDEH.AutoSize = true;
            labelDEH.Location = new Point(212, 0);
            labelDEH.Name = "labelDEH";
            labelDEH.Size = new Size(112, 16);
            labelDEH.TabIndex = 2;
            labelDEH.Text = "Default EyeHeight:";
            // 
            // labelDEHV
            // 
            labelDEHV.AutoSize = true;
            labelDEHV.Location = new Point(330, 0);
            labelDEHV.Name = "labelDEHV";
            labelDEHV.Size = new Size(85, 16);
            labelDEHV.TabIndex = 3;
            labelDEHV.Text = "(wait loading)";
            // 
            // labelSF
            // 
            labelSF.AutoSize = true;
            labelSF.Location = new Point(421, 0);
            labelSF.Name = "labelSF";
            labelSF.Size = new Size(75, 16);
            labelSF.TabIndex = 4;
            labelSF.Text = "ScaleFactor:";
            // 
            // labelSFV
            // 
            labelSFV.AutoSize = true;
            labelSFV.Location = new Point(502, 0);
            labelSFV.Name = "labelSFV";
            labelSFV.Size = new Size(85, 16);
            labelSFV.TabIndex = 5;
            labelSFV.Text = "(wait loading)";
            // 
            // labelGetWristInfoFailed
            // 
            labelGetWristInfoFailed.AutoSize = true;
            labelGetWristInfoFailed.ForeColor = Color.Red;
            labelGetWristInfoFailed.Location = new Point(3, 16);
            labelGetWristInfoFailed.Name = "labelGetWristInfoFailed";
            labelGetWristInfoFailed.Size = new Size(214, 16);
            labelGetWristInfoFailed.TabIndex = 6;
            labelGetWristInfoFailed.Text = "Controller coordinate retrieval failed.";
            // 
            // labelAvatarScalingDisabled
            // 
            labelAvatarScalingDisabled.AutoSize = true;
            labelAvatarScalingDisabled.ForeColor = Color.Red;
            labelAvatarScalingDisabled.Location = new Point(223, 16);
            labelAvatarScalingDisabled.Name = "labelAvatarScalingDisabled";
            labelAvatarScalingDisabled.Size = new Size(140, 16);
            labelAvatarScalingDisabled.TabIndex = 7;
            labelAvatarScalingDisabled.Text = "Avatar Scaling Disabled";
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.FileName = "VRCScalerOSC.Setting.txt";
            openFileDialog1.Filter = "Text (*.txt)|*.txt|All File (*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "VRCScalerOSC.Setting.txt";
            saveFileDialog1.Filter = "Text (*.txt)|*.txt|All File (*.*)|*.*";
            // 
            // contextMenuStripHetightRange
            // 
            contextMenuStripHetightRange.Font = new Font("Microsoft JhengHei UI", 14.25F);
            contextMenuStripHetightRange.Items.AddRange(new ToolStripItem[] { toolStripMenuItemHeightRangeVRChatAvatar, toolStripMenuItemHeightRangeVRChatWorld, toolStripMenuItemHeightRangeAdvanced, toolStripMenuItemHeightRangeMaximum, toolStripMenuItemHeightRangeUserSettings, toolStripMenuItemHeightRangeSetUpper, toolStripMenuItemHeightRangeSetLower });
            contextMenuStripHetightRange.Name = "contextMenuStripHetightRange";
            contextMenuStripHetightRange.Size = new Size(349, 200);
            // 
            // toolStripMenuItemHeightRangeVRChatAvatar
            // 
            toolStripMenuItemHeightRangeVRChatAvatar.Name = "toolStripMenuItemHeightRangeVRChatAvatar";
            toolStripMenuItemHeightRangeVRChatAvatar.Size = new Size(348, 28);
            toolStripMenuItemHeightRangeVRChatAvatar.Text = "Avatar Default (0.2 to 5m)";
            toolStripMenuItemHeightRangeVRChatAvatar.Click += toolStripMenuItemHeightRange_Click;
            // 
            // toolStripMenuItemHeightRangeVRChatWorld
            // 
            toolStripMenuItemHeightRangeVRChatWorld.Name = "toolStripMenuItemHeightRangeVRChatWorld";
            toolStripMenuItemHeightRangeVRChatWorld.Size = new Size(348, 28);
            toolStripMenuItemHeightRangeVRChatWorld.Text = "World Default (0.1 to 100m)";
            toolStripMenuItemHeightRangeVRChatWorld.Click += toolStripMenuItemHeightRange_Click;
            // 
            // toolStripMenuItemHeightRangeAdvanced
            // 
            toolStripMenuItemHeightRangeAdvanced.Name = "toolStripMenuItemHeightRangeAdvanced";
            toolStripMenuItemHeightRangeAdvanced.Size = new Size(348, 28);
            toolStripMenuItemHeightRangeAdvanced.Text = "Advanced (0.05 to 1000m)";
            toolStripMenuItemHeightRangeAdvanced.Click += toolStripMenuItemHeightRange_Click;
            // 
            // toolStripMenuItemHeightRangeMaximum
            // 
            toolStripMenuItemHeightRangeMaximum.Name = "toolStripMenuItemHeightRangeMaximum";
            toolStripMenuItemHeightRangeMaximum.Size = new Size(348, 28);
            toolStripMenuItemHeightRangeMaximum.Text = "VRChat limit (0.01 to 10000m)";
            toolStripMenuItemHeightRangeMaximum.Click += toolStripMenuItemHeightRange_Click;
            // 
            // toolStripMenuItemHeightRangeUserSettings
            // 
            toolStripMenuItemHeightRangeUserSettings.Name = "toolStripMenuItemHeightRangeUserSettings";
            toolStripMenuItemHeightRangeUserSettings.Size = new Size(348, 28);
            toolStripMenuItemHeightRangeUserSettings.Text = "User Settings";
            toolStripMenuItemHeightRangeUserSettings.Click += toolStripMenuItemHeightRange_Click;
            // 
            // toolStripMenuItemHeightRangeSetUpper
            // 
            toolStripMenuItemHeightRangeSetUpper.Name = "toolStripMenuItemHeightRangeSetUpper";
            toolStripMenuItemHeightRangeSetUpper.Size = new Size(348, 28);
            toolStripMenuItemHeightRangeSetUpper.Text = "Set Max to Selected Value";
            toolStripMenuItemHeightRangeSetUpper.Click += toolStripMenuItemHeightRange_Click;
            // 
            // toolStripMenuItemHeightRangeSetLower
            // 
            toolStripMenuItemHeightRangeSetLower.Name = "toolStripMenuItemHeightRangeSetLower";
            toolStripMenuItemHeightRangeSetLower.Size = new Size(348, 28);
            toolStripMenuItemHeightRangeSetLower.Text = "Set Min to Selected Value";
            toolStripMenuItemHeightRangeSetLower.Click += toolStripMenuItemHeightRange_Click;
            // 
            // ScalerForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 341);
            Controls.Add(splitContainer1);
            Font = new Font("Microsoft JhengHei", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimumSize = new Size(780, 380);
            Name = "ScalerForm";
            Padding = new Padding(6, 6, 6, 2);
            Text = "VRC Scaler OSC";
            Load += FormMain_Load;
            groupBoxHeight.ResumeLayout(false);
            groupBoxHeight.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBoxScalingTime.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            groupBoxOSCConfig.ResumeLayout(false);
            groupBoxOSCConfig.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanelStd.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBoxSetting.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            groupBoxCustom.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            groupBoxGesture.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            contextMenuStripFormSize.ResumeLayout(false);
            contextMenuStripLanguage.ResumeLayout(false);
            tableLayoutPanelLite.ResumeLayout(false);
            tableLayoutPanelLitePercentage.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanelAvatarHeight.ResumeLayout(false);
            flowLayoutPanelAvatarHeight.PerformLayout();
            contextMenuStripHetightRange.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label labelOSCSendPort;
        private System.Windows.Forms.TextBox textBoxSendPort;
        private System.Windows.Forms.Label labelOSCReceivePort;
        private System.Windows.Forms.TextBox textBoxReceivePort;
        private System.Windows.Forms.Label labelOSCIP;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button buttonOSCSetup;
        private System.Windows.Forms.Button buttonChangeScale;
        private System.Windows.Forms.Button buttonResetHeight;
        private System.Windows.Forms.GroupBox groupBoxHeight;
        private System.Windows.Forms.GroupBox groupBoxScalingTime;
        private System.Windows.Forms.GroupBox groupBoxOSCConfig;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ComboBox comboBoxTargetEyeHeight;
        private System.Windows.Forms.ProgressBar progressBarScaling;
        private System.Windows.Forms.Button buttonOSCStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBoxAutoAbort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button buttonLanguage;
        private System.Windows.Forms.Button buttonFormSize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFormSize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFormSize1x;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFormSize2x;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFormSize3x;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFormSize4x;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLanguage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangEN;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangJP;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangKR;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangCN;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangTW;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonComboScalingTime;
        private System.Windows.Forms.ComboBox comboBoxScalingTime;
        private System.Windows.Forms.Label labelSec;
        private System.Windows.Forms.Button buttonLite;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLite;
        private System.Windows.Forms.Button buttonResetHeightLite;
        private System.Windows.Forms.Button buttonSet12;
        private System.Windows.Forms.Button buttonSet11;
        private System.Windows.Forms.Button buttonSet10;
        private System.Windows.Forms.Button buttonSet9;
        private System.Windows.Forms.Button buttonSet8;
        private System.Windows.Forms.Button buttonSet7;
        private System.Windows.Forms.Button buttonStop2;
        private System.Windows.Forms.Button buttonSet6;
        private System.Windows.Forms.Button buttonSet5;
        private System.Windows.Forms.Button buttonSet4;
        private System.Windows.Forms.Button buttonStd;
        private System.Windows.Forms.Button buttonSet3;
        private System.Windows.Forms.Button buttonSet2;
        private System.Windows.Forms.Button buttonSet1;
        private System.Windows.Forms.CheckBox checkBoxInstant;
        private System.Windows.Forms.CheckBox checkBoxFixedRate;
        private System.Windows.Forms.ComboBox comboBoxScalingRate;
        private Panel panel2;
        private Button buttonComboEyeHeight;
        private GroupBox groupBoxCustom;
        private GroupBox groupBoxGesture;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox comboBoxGesture;
        private TableLayoutPanel tableLayoutPanel7;
        private Button buttonCustomImport;
        private Button buttonCustomExport;
        private CheckBox checkBoxWorldScaling;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowLayoutPanelAvatarHeight;
        private Label labelCEH;
        private Label labelCEHV;
        private Label labelDEH;
        private Label labelDEHV;
        private Label labelSF;
        private Label labelSFV;
        private Button buttonSet23;
        private Button buttonSet22;
        private Button buttonSet21;
        private Button buttonSet17;
        private Button buttonSet16;
        private Button buttonSet15;
        private Button buttonSet14;
        private Button buttonSet13;
        private Button buttonSet25;
        private Button buttonSet24;
        private Button buttonSet20;
        private Button buttonSet19;
        private Button buttonSet18;
        private CheckBox checkBoxIsMultiplier;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ComboBox comboBoxIsMultiplier;
        private Label labelSCS;
        private Label labelGetWristInfoFailed;
        private CheckBox checkBoxOSCRandomReceiverPort;
        private Label labelAvatarScalingDisabled;
        private Label labelHeightRange;
        private Button buttonHeightRange;
        private ContextMenuStrip contextMenuStripHetightRange;
        private ToolStripMenuItem toolStripMenuItemHeightRangeVRChatAvatar;
        private ToolStripMenuItem toolStripMenuItemHeightRangeVRChatWorld;
        private ToolStripMenuItem toolStripMenuItemHeightRangeAdvanced;
        private ToolStripMenuItem toolStripMenuItemHeightRangeMaximum;
        private ToolStripMenuItem toolStripMenuItemHeightRangeSetUpper;
        private ToolStripMenuItem toolStripMenuItemHeightRangeSetLower;
        private ToolStripMenuItem toolStripMenuItemHeightRangeUserSettings;
        private TableLayoutPanel tableLayoutPanelLitePercentage;
        private Button buttonSet26;
        private Button buttonSet27;
        private Button buttonSet28;
        private Button buttonSet29;
        private Button buttonSet30;
        private Button buttonSet31;
        private Button buttonSet32;
        private Button buttonSet33;
        private CheckBox checkBoxGestureMuteDoubleClickMode;
    }
}

