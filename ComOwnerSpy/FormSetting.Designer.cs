namespace ComOwnerSpy
{
    partial class FormSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.tabCtrlSetting = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.groupBoxRefreshSetting = new System.Windows.Forms.GroupBox();
            this.cboxEnableAutoRefreshAtStartup = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.upDownRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.comboxBoxOwnerShowFormat = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBoxRowHeight = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPageComPorts = new System.Windows.Forms.TabPage();
            this.btnClearPorts = new System.Windows.Forms.Button();
            this.btnResumePort = new System.Windows.Forms.Button();
            this.btnRemovePort = new System.Windows.Forms.Button();
            this.lboxRemovedPorts = new System.Windows.Forms.ListBox();
            this.lboxSelectedPorts = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudPortStart = new System.Windows.Forms.NumericUpDown();
            this.nudPortEnd = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.tboxPortSingleAddInput = new System.Windows.Forms.TextBox();
            this.btnPortsSingleAdd = new System.Windows.Forms.Button();
            this.btnPortsRangeAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageSuspectProc = new System.Windows.Forms.TabPage();
            this.btnAddSerialDevicePattern = new System.Windows.Forms.Button();
            this.btnAddProcName = new System.Windows.Forms.Button();
            this.tboxSerialDevicePattern = new System.Windows.Forms.TextBox();
            this.tboxInputProcName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lboxSerialDeviceNamePatterns = new System.Windows.Forms.ListBox();
            this.ctxMenuListBoxSuspectProcNames = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lboxSuspectProcNames = new System.Windows.Forms.ListBox();
            this.tabPageDeviceMap = new System.Windows.Forms.TabPage();
            this.btnBuildDeviceFileNameMap = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancleUpdatePortDeviceMapEntry = new System.Windows.Forms.Button();
            this.btnUpdateOrAdd = new System.Windows.Forms.Button();
            this.tboxDeviceFileName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tboxPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listViewDeviceMapTable = new System.Windows.Forms.ListView();
            this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDeviceFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageOwner = new System.Windows.Forms.TabPage();
            this.btnDeleteOwnerTranslate = new System.Windows.Forms.Button();
            this.btnAddNewOwnerTranslate = new System.Windows.Forms.Button();
            this.groupOwnerTranslateInfo = new System.Windows.Forms.GroupBox();
            this.tboxOwnerPhone = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tboxOwnerShortName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tboxOwnerFullName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tboxDomainUser = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.listViewOwnerTranslate = new System.Windows.Forms.ListView();
            this.columnHeaderDomainUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderShortName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabCtrlSetting.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBoxRefreshSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRefreshInterval)).BeginInit();
            this.tabPageComPorts.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortEnd)).BeginInit();
            this.tabPageSuspectProc.SuspendLayout();
            this.ctxMenuListBoxSuspectProcNames.SuspendLayout();
            this.tabPageDeviceMap.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageOwner.SuspendLayout();
            this.groupOwnerTranslateInfo.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrlSetting
            // 
            this.tabCtrlSetting.Controls.Add(this.tabPageGeneral);
            this.tabCtrlSetting.Controls.Add(this.tabPageComPorts);
            this.tabCtrlSetting.Controls.Add(this.tabPageSuspectProc);
            this.tabCtrlSetting.Controls.Add(this.tabPageDeviceMap);
            this.tabCtrlSetting.Controls.Add(this.tabPageOwner);
            this.tabCtrlSetting.Controls.Add(this.tabPageAbout);
            this.tabCtrlSetting.Location = new System.Drawing.Point(10, 7);
            this.tabCtrlSetting.Name = "tabCtrlSetting";
            this.tabCtrlSetting.SelectedIndex = 0;
            this.tabCtrlSetting.Size = new System.Drawing.Size(521, 371);
            this.tabCtrlSetting.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.groupBoxRefreshSetting);
            this.tabPageGeneral.Controls.Add(this.comboxBoxOwnerShowFormat);
            this.tabPageGeneral.Controls.Add(this.label24);
            this.tabPageGeneral.Controls.Add(this.comboBoxRowHeight);
            this.tabPageGeneral.Controls.Add(this.label17);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 26);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(513, 341);
            this.tabPageGeneral.TabIndex = 3;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxRefreshSetting
            // 
            this.groupBoxRefreshSetting.Controls.Add(this.cboxEnableAutoRefreshAtStartup);
            this.groupBoxRefreshSetting.Controls.Add(this.label19);
            this.groupBoxRefreshSetting.Controls.Add(this.upDownRefreshInterval);
            this.groupBoxRefreshSetting.Controls.Add(this.label18);
            this.groupBoxRefreshSetting.Location = new System.Drawing.Point(6, 1);
            this.groupBoxRefreshSetting.Name = "groupBoxRefreshSetting";
            this.groupBoxRefreshSetting.Size = new System.Drawing.Size(501, 81);
            this.groupBoxRefreshSetting.TabIndex = 11;
            this.groupBoxRefreshSetting.TabStop = false;
            // 
            // cboxEnableAutoRefreshAtStartup
            // 
            this.cboxEnableAutoRefreshAtStartup.AutoSize = true;
            this.cboxEnableAutoRefreshAtStartup.Location = new System.Drawing.Point(13, 17);
            this.cboxEnableAutoRefreshAtStartup.Name = "cboxEnableAutoRefreshAtStartup";
            this.cboxEnableAutoRefreshAtStartup.Size = new System.Drawing.Size(206, 21);
            this.cboxEnableAutoRefreshAtStartup.TabIndex = 0;
            this.cboxEnableAutoRefreshAtStartup.Text = "Enable auto refresh at start-up";
            this.cboxEnableAutoRefreshAtStartup.UseVisualStyleBackColor = true;
            this.cboxEnableAutoRefreshAtStartup.CheckedChanged += new System.EventHandler(this.cboxEnableAutoRefreshAtStartup_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(170, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 17);
            this.label19.TabIndex = 10;
            this.label19.Text = "Seconds";
            // 
            // upDownRefreshInterval
            // 
            this.upDownRefreshInterval.Location = new System.Drawing.Point(117, 44);
            this.upDownRefreshInterval.Name = "upDownRefreshInterval";
            this.upDownRefreshInterval.Size = new System.Drawing.Size(52, 23);
            this.upDownRefreshInterval.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 17);
            this.label18.TabIndex = 10;
            this.label18.Text = "Refresh Interval:";
            // 
            // comboxBoxOwnerShowFormat
            // 
            this.comboxBoxOwnerShowFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxBoxOwnerShowFormat.FormattingEnabled = true;
            this.comboxBoxOwnerShowFormat.Items.AddRange(new object[] {
            "Default",
            "DomainUser",
            "FullName",
            "ShortName",
            "Phone"});
            this.comboxBoxOwnerShowFormat.Location = new System.Drawing.Point(103, 122);
            this.comboxBoxOwnerShowFormat.Name = "comboxBoxOwnerShowFormat";
            this.comboxBoxOwnerShowFormat.Size = new System.Drawing.Size(89, 25);
            this.comboxBoxOwnerShowFormat.TabIndex = 1;
            this.comboxBoxOwnerShowFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxOwnerShowFormat_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 126);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(94, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Owner Format:";
            // 
            // comboBoxRowHeight
            // 
            this.comboBoxRowHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRowHeight.FormattingEnabled = true;
            this.comboBoxRowHeight.Location = new System.Drawing.Point(103, 91);
            this.comboBoxRowHeight.Name = "comboBoxRowHeight";
            this.comboBoxRowHeight.Size = new System.Drawing.Size(89, 25);
            this.comboBoxRowHeight.TabIndex = 0;
            this.comboBoxRowHeight.SelectedIndexChanged += new System.EventHandler(this.comboBoxRowHeight_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "Row Height:";
            // 
            // tabPageComPorts
            // 
            this.tabPageComPorts.Controls.Add(this.btnClearPorts);
            this.tabPageComPorts.Controls.Add(this.btnResumePort);
            this.tabPageComPorts.Controls.Add(this.btnRemovePort);
            this.tabPageComPorts.Controls.Add(this.lboxRemovedPorts);
            this.tabPageComPorts.Controls.Add(this.lboxSelectedPorts);
            this.tabPageComPorts.Controls.Add(this.groupBox5);
            this.tabPageComPorts.Controls.Add(this.label2);
            this.tabPageComPorts.Controls.Add(this.label1);
            this.tabPageComPorts.Location = new System.Drawing.Point(4, 26);
            this.tabPageComPorts.Name = "tabPageComPorts";
            this.tabPageComPorts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageComPorts.Size = new System.Drawing.Size(513, 341);
            this.tabPageComPorts.TabIndex = 0;
            this.tabPageComPorts.Text = "COM Ports";
            this.tabPageComPorts.UseVisualStyleBackColor = true;
            // 
            // btnClearPorts
            // 
            this.btnClearPorts.Location = new System.Drawing.Point(337, 294);
            this.btnClearPorts.Name = "btnClearPorts";
            this.btnClearPorts.Size = new System.Drawing.Size(54, 32);
            this.btnClearPorts.TabIndex = 2;
            this.btnClearPorts.Text = "Clear";
            this.btnClearPorts.UseVisualStyleBackColor = true;
            this.btnClearPorts.Click += new System.EventHandler(this.btnClearPorts_Click_1);
            // 
            // btnResumePort
            // 
            this.btnResumePort.Location = new System.Drawing.Point(337, 136);
            this.btnResumePort.Name = "btnResumePort";
            this.btnResumePort.Size = new System.Drawing.Size(54, 32);
            this.btnResumePort.TabIndex = 1;
            this.btnResumePort.Text = "<<";
            this.btnResumePort.UseVisualStyleBackColor = true;
            this.btnResumePort.Click += new System.EventHandler(this.btnResumePort_Click_1);
            // 
            // btnRemovePort
            // 
            this.btnRemovePort.Location = new System.Drawing.Point(337, 93);
            this.btnRemovePort.Name = "btnRemovePort";
            this.btnRemovePort.Size = new System.Drawing.Size(54, 32);
            this.btnRemovePort.TabIndex = 0;
            this.btnRemovePort.Text = ">>";
            this.btnRemovePort.UseVisualStyleBackColor = true;
            this.btnRemovePort.Click += new System.EventHandler(this.btnRemovePort_Click);
            // 
            // lboxRemovedPorts
            // 
            this.lboxRemovedPorts.FormattingEnabled = true;
            this.lboxRemovedPorts.ItemHeight = 17;
            this.lboxRemovedPorts.Location = new System.Drawing.Point(397, 33);
            this.lboxRemovedPorts.Name = "lboxRemovedPorts";
            this.lboxRemovedPorts.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lboxRemovedPorts.Size = new System.Drawing.Size(90, 293);
            this.lboxRemovedPorts.TabIndex = 23;
            // 
            // lboxSelectedPorts
            // 
            this.lboxSelectedPorts.FormattingEnabled = true;
            this.lboxSelectedPorts.ItemHeight = 17;
            this.lboxSelectedPorts.Location = new System.Drawing.Point(241, 33);
            this.lboxSelectedPorts.Name = "lboxSelectedPorts";
            this.lboxSelectedPorts.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lboxSelectedPorts.Size = new System.Drawing.Size(90, 293);
            this.lboxSelectedPorts.TabIndex = 24;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudPortStart);
            this.groupBox5.Controls.Add(this.nudPortEnd);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.tboxPortSingleAddInput);
            this.groupBox5.Controls.Add(this.btnPortsSingleAdd);
            this.groupBox5.Controls.Add(this.btnPortsRangeAdd);
            this.groupBox5.Location = new System.Drawing.Point(10, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(219, 93);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            // 
            // nudPortStart
            // 
            this.nudPortStart.Location = new System.Drawing.Point(9, 18);
            this.nudPortStart.Name = "nudPortStart";
            this.nudPortStart.Size = new System.Drawing.Size(54, 23);
            this.nudPortStart.TabIndex = 0;
            // 
            // nudPortEnd
            // 
            this.nudPortEnd.Location = new System.Drawing.Point(79, 18);
            this.nudPortEnd.Name = "nudPortEnd";
            this.nudPortEnd.Size = new System.Drawing.Size(54, 23);
            this.nudPortEnd.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(65, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 17);
            this.label16.TabIndex = 5;
            this.label16.Text = "-";
            // 
            // tboxPortSingleAddInput
            // 
            this.tboxPortSingleAddInput.Location = new System.Drawing.Point(9, 59);
            this.tboxPortSingleAddInput.Name = "tboxPortSingleAddInput";
            this.tboxPortSingleAddInput.Size = new System.Drawing.Size(124, 23);
            this.tboxPortSingleAddInput.TabIndex = 3;
            // 
            // btnPortsSingleAdd
            // 
            this.btnPortsSingleAdd.Location = new System.Drawing.Point(139, 54);
            this.btnPortsSingleAdd.Name = "btnPortsSingleAdd";
            this.btnPortsSingleAdd.Size = new System.Drawing.Size(72, 32);
            this.btnPortsSingleAdd.TabIndex = 4;
            this.btnPortsSingleAdd.Text = "Add";
            this.btnPortsSingleAdd.UseVisualStyleBackColor = true;
            this.btnPortsSingleAdd.Click += new System.EventHandler(this.btnPortsSingleAdd_Click);
            // 
            // btnPortsRangeAdd
            // 
            this.btnPortsRangeAdd.Location = new System.Drawing.Point(139, 13);
            this.btnPortsRangeAdd.Name = "btnPortsRangeAdd";
            this.btnPortsRangeAdd.Size = new System.Drawing.Size(72, 32);
            this.btnPortsRangeAdd.TabIndex = 2;
            this.btnPortsRangeAdd.Text = "+Range";
            this.btnPortsRangeAdd.UseVisualStyleBackColor = true;
            this.btnPortsRangeAdd.Click += new System.EventHandler(this.btnPortsRangeAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Removed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Selected:";
            // 
            // tabPageSuspectProc
            // 
            this.tabPageSuspectProc.Controls.Add(this.btnAddSerialDevicePattern);
            this.tabPageSuspectProc.Controls.Add(this.btnAddProcName);
            this.tabPageSuspectProc.Controls.Add(this.tboxSerialDevicePattern);
            this.tabPageSuspectProc.Controls.Add(this.tboxInputProcName);
            this.tabPageSuspectProc.Controls.Add(this.label15);
            this.tabPageSuspectProc.Controls.Add(this.label3);
            this.tabPageSuspectProc.Controls.Add(this.lboxSerialDeviceNamePatterns);
            this.tabPageSuspectProc.Controls.Add(this.lboxSuspectProcNames);
            this.tabPageSuspectProc.Location = new System.Drawing.Point(4, 26);
            this.tabPageSuspectProc.Name = "tabPageSuspectProc";
            this.tabPageSuspectProc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSuspectProc.Size = new System.Drawing.Size(513, 341);
            this.tabPageSuspectProc.TabIndex = 1;
            this.tabPageSuspectProc.Text = "Suspect Proc.";
            this.tabPageSuspectProc.UseVisualStyleBackColor = true;
            // 
            // btnAddSerialDevicePattern
            // 
            this.btnAddSerialDevicePattern.Location = new System.Drawing.Point(429, 283);
            this.btnAddSerialDevicePattern.Name = "btnAddSerialDevicePattern";
            this.btnAddSerialDevicePattern.Size = new System.Drawing.Size(42, 32);
            this.btnAddSerialDevicePattern.TabIndex = 3;
            this.btnAddSerialDevicePattern.Text = "ADD";
            this.btnAddSerialDevicePattern.UseVisualStyleBackColor = true;
            this.btnAddSerialDevicePattern.Click += new System.EventHandler(this.btnAddSerialDevicePattern_Click);
            // 
            // btnAddProcName
            // 
            this.btnAddProcName.Location = new System.Drawing.Point(152, 283);
            this.btnAddProcName.Name = "btnAddProcName";
            this.btnAddProcName.Size = new System.Drawing.Size(42, 32);
            this.btnAddProcName.TabIndex = 1;
            this.btnAddProcName.Text = "ADD";
            this.btnAddProcName.UseVisualStyleBackColor = true;
            this.btnAddProcName.Click += new System.EventHandler(this.btnAddProcName_Click);
            // 
            // tboxSerialDevicePattern
            // 
            this.tboxSerialDevicePattern.Location = new System.Drawing.Point(293, 288);
            this.tboxSerialDevicePattern.Name = "tboxSerialDevicePattern";
            this.tboxSerialDevicePattern.Size = new System.Drawing.Size(130, 23);
            this.tboxSerialDevicePattern.TabIndex = 2;
            // 
            // tboxInputProcName
            // 
            this.tboxInputProcName.Location = new System.Drawing.Point(16, 288);
            this.tboxInputProcName.Name = "tboxInputProcName";
            this.tboxInputProcName.Size = new System.Drawing.Size(130, 23);
            this.tboxInputProcName.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(290, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(177, 34);
            this.label15.TabIndex = 6;
            this.label15.Text = "The patterns of serial device \r\nfile name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "The names of process that may \r\nopen the serial port:";
            // 
            // lboxSerialDeviceNamePatterns
            // 
            this.lboxSerialDeviceNamePatterns.ContextMenuStrip = this.ctxMenuListBoxSuspectProcNames;
            this.lboxSerialDeviceNamePatterns.FormattingEnabled = true;
            this.lboxSerialDeviceNamePatterns.ItemHeight = 17;
            this.lboxSerialDeviceNamePatterns.Location = new System.Drawing.Point(293, 51);
            this.lboxSerialDeviceNamePatterns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lboxSerialDeviceNamePatterns.Name = "lboxSerialDeviceNamePatterns";
            this.lboxSerialDeviceNamePatterns.Size = new System.Drawing.Size(178, 225);
            this.lboxSerialDeviceNamePatterns.TabIndex = 4;
            this.lboxSerialDeviceNamePatterns.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lboxSuspectProcNamesOrPatterns_KeyDown);
            // 
            // ctxMenuListBoxSuspectProcNames
            // 
            this.ctxMenuListBoxSuspectProcNames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.ctxMenuListBoxSuspectProcNames.Name = "ctxMenuListBoxSuspectProcNames";
            this.ctxMenuListBoxSuspectProcNames.Size = new System.Drawing.Size(124, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // lboxSuspectProcNames
            // 
            this.lboxSuspectProcNames.ContextMenuStrip = this.ctxMenuListBoxSuspectProcNames;
            this.lboxSuspectProcNames.FormattingEnabled = true;
            this.lboxSuspectProcNames.ItemHeight = 17;
            this.lboxSuspectProcNames.Location = new System.Drawing.Point(16, 51);
            this.lboxSuspectProcNames.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lboxSuspectProcNames.Name = "lboxSuspectProcNames";
            this.lboxSuspectProcNames.Size = new System.Drawing.Size(178, 225);
            this.lboxSuspectProcNames.TabIndex = 4;
            this.lboxSuspectProcNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lboxSuspectProcNamesOrPatterns_KeyDown);
            // 
            // tabPageDeviceMap
            // 
            this.tabPageDeviceMap.Controls.Add(this.btnBuildDeviceFileNameMap);
            this.tabPageDeviceMap.Controls.Add(this.groupBox1);
            this.tabPageDeviceMap.Controls.Add(this.listViewDeviceMapTable);
            this.tabPageDeviceMap.Location = new System.Drawing.Point(4, 26);
            this.tabPageDeviceMap.Name = "tabPageDeviceMap";
            this.tabPageDeviceMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeviceMap.Size = new System.Drawing.Size(513, 341);
            this.tabPageDeviceMap.TabIndex = 2;
            this.tabPageDeviceMap.Text = "Map Table";
            this.tabPageDeviceMap.UseVisualStyleBackColor = true;
            // 
            // btnBuildDeviceFileNameMap
            // 
            this.btnBuildDeviceFileNameMap.Location = new System.Drawing.Point(310, 152);
            this.btnBuildDeviceFileNameMap.Name = "btnBuildDeviceFileNameMap";
            this.btnBuildDeviceFileNameMap.Size = new System.Drawing.Size(75, 33);
            this.btnBuildDeviceFileNameMap.TabIndex = 0;
            this.btnBuildDeviceFileNameMap.Text = "Build";
            this.btnBuildDeviceFileNameMap.UseVisualStyleBackColor = true;
            this.btnBuildDeviceFileNameMap.Click += new System.EventHandler(this.btnBuildDeviceFileNameMap_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancleUpdatePortDeviceMapEntry);
            this.groupBox1.Controls.Add(this.btnUpdateOrAdd);
            this.groupBox1.Controls.Add(this.tboxDeviceFileName);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tboxPort);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(307, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnCancleUpdatePortDeviceMapEntry
            // 
            this.btnCancleUpdatePortDeviceMapEntry.Location = new System.Drawing.Point(6, 97);
            this.btnCancleUpdatePortDeviceMapEntry.Name = "btnCancleUpdatePortDeviceMapEntry";
            this.btnCancleUpdatePortDeviceMapEntry.Size = new System.Drawing.Size(75, 33);
            this.btnCancleUpdatePortDeviceMapEntry.TabIndex = 2;
            this.btnCancleUpdatePortDeviceMapEntry.Text = "Cancle";
            this.btnCancleUpdatePortDeviceMapEntry.UseVisualStyleBackColor = true;
            this.btnCancleUpdatePortDeviceMapEntry.Click += new System.EventHandler(this.btnCancleUpdatePortDeviceMapEntry_Click);
            // 
            // btnUpdateOrAdd
            // 
            this.btnUpdateOrAdd.Location = new System.Drawing.Point(122, 97);
            this.btnUpdateOrAdd.Name = "btnUpdateOrAdd";
            this.btnUpdateOrAdd.Size = new System.Drawing.Size(75, 33);
            this.btnUpdateOrAdd.TabIndex = 3;
            this.btnUpdateOrAdd.Text = "Update";
            this.btnUpdateOrAdd.UseVisualStyleBackColor = true;
            this.btnUpdateOrAdd.Click += new System.EventHandler(this.btnUpdateOrAdd_Click);
            // 
            // tboxDeviceFileName
            // 
            this.tboxDeviceFileName.Location = new System.Drawing.Point(6, 68);
            this.tboxDeviceFileName.Name = "tboxDeviceFileName";
            this.tboxDeviceFileName.Size = new System.Drawing.Size(191, 23);
            this.tboxDeviceFileName.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Device File Name:";
            // 
            // tboxPort
            // 
            this.tboxPort.Enabled = false;
            this.tboxPort.Location = new System.Drawing.Point(44, 16);
            this.tboxPort.Name = "tboxPort";
            this.tboxPort.Size = new System.Drawing.Size(81, 23);
            this.tboxPort.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Port:";
            // 
            // listViewDeviceMapTable
            // 
            this.listViewDeviceMapTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPort,
            this.columnHeaderDeviceFileName});
            this.listViewDeviceMapTable.Location = new System.Drawing.Point(9, 8);
            this.listViewDeviceMapTable.Name = "listViewDeviceMapTable";
            this.listViewDeviceMapTable.Size = new System.Drawing.Size(292, 325);
            this.listViewDeviceMapTable.TabIndex = 0;
            this.listViewDeviceMapTable.UseCompatibleStateImageBehavior = false;
            this.listViewDeviceMapTable.View = System.Windows.Forms.View.Details;
            this.listViewDeviceMapTable.DoubleClick += new System.EventHandler(this.listViewDeviceMapTable_DoubleClick);
            this.listViewDeviceMapTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewDeviceMapTable_KeyDown);
            // 
            // columnHeaderPort
            // 
            this.columnHeaderPort.Text = "Port";
            // 
            // columnHeaderDeviceFileName
            // 
            this.columnHeaderDeviceFileName.Text = "DeviceFileName";
            this.columnHeaderDeviceFileName.Width = 194;
            // 
            // tabPageOwner
            // 
            this.tabPageOwner.Controls.Add(this.btnDeleteOwnerTranslate);
            this.tabPageOwner.Controls.Add(this.btnAddNewOwnerTranslate);
            this.tabPageOwner.Controls.Add(this.groupOwnerTranslateInfo);
            this.tabPageOwner.Controls.Add(this.listViewOwnerTranslate);
            this.tabPageOwner.Location = new System.Drawing.Point(4, 26);
            this.tabPageOwner.Name = "tabPageOwner";
            this.tabPageOwner.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOwner.Size = new System.Drawing.Size(513, 341);
            this.tabPageOwner.TabIndex = 5;
            this.tabPageOwner.Text = "Owner";
            this.tabPageOwner.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOwnerTranslate
            // 
            this.btnDeleteOwnerTranslate.Location = new System.Drawing.Point(453, 202);
            this.btnDeleteOwnerTranslate.Name = "btnDeleteOwnerTranslate";
            this.btnDeleteOwnerTranslate.Size = new System.Drawing.Size(54, 32);
            this.btnDeleteOwnerTranslate.TabIndex = 1;
            this.btnDeleteOwnerTranslate.Text = "Delete";
            this.btnDeleteOwnerTranslate.UseVisualStyleBackColor = true;
            this.btnDeleteOwnerTranslate.Click += new System.EventHandler(this.btnDeleteOwnerTranslate_Click);
            // 
            // btnAddNewOwnerTranslate
            // 
            this.btnAddNewOwnerTranslate.Location = new System.Drawing.Point(251, 301);
            this.btnAddNewOwnerTranslate.Name = "btnAddNewOwnerTranslate";
            this.btnAddNewOwnerTranslate.Size = new System.Drawing.Size(54, 32);
            this.btnAddNewOwnerTranslate.TabIndex = 0;
            this.btnAddNewOwnerTranslate.Text = "Add";
            this.btnAddNewOwnerTranslate.UseVisualStyleBackColor = true;
            this.btnAddNewOwnerTranslate.Click += new System.EventHandler(this.btnAddNewOwnerTranslate_Click);
            // 
            // groupOwnerTranslateInfo
            // 
            this.groupOwnerTranslateInfo.Controls.Add(this.tboxOwnerPhone);
            this.groupOwnerTranslateInfo.Controls.Add(this.label23);
            this.groupOwnerTranslateInfo.Controls.Add(this.tboxOwnerShortName);
            this.groupOwnerTranslateInfo.Controls.Add(this.label22);
            this.groupOwnerTranslateInfo.Controls.Add(this.tboxOwnerFullName);
            this.groupOwnerTranslateInfo.Controls.Add(this.label21);
            this.groupOwnerTranslateInfo.Controls.Add(this.tboxDomainUser);
            this.groupOwnerTranslateInfo.Controls.Add(this.label20);
            this.groupOwnerTranslateInfo.Location = new System.Drawing.Point(6, 203);
            this.groupOwnerTranslateInfo.Name = "groupOwnerTranslateInfo";
            this.groupOwnerTranslateInfo.Size = new System.Drawing.Size(239, 130);
            this.groupOwnerTranslateInfo.TabIndex = 1;
            this.groupOwnerTranslateInfo.TabStop = false;
            this.groupOwnerTranslateInfo.Text = "Owner";
            // 
            // tboxOwnerPhone
            // 
            this.tboxOwnerPhone.Location = new System.Drawing.Point(94, 100);
            this.tboxOwnerPhone.Name = "tboxOwnerPhone";
            this.tboxOwnerPhone.Size = new System.Drawing.Size(139, 23);
            this.tboxOwnerPhone.TabIndex = 3;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(45, 103);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 17);
            this.label23.TabIndex = 2;
            this.label23.Text = "Phone";
            // 
            // tboxOwnerShortName
            // 
            this.tboxOwnerShortName.Location = new System.Drawing.Point(94, 72);
            this.tboxOwnerShortName.Name = "tboxOwnerShortName";
            this.tboxOwnerShortName.Size = new System.Drawing.Size(139, 23);
            this.tboxOwnerShortName.TabIndex = 2;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 75);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 17);
            this.label22.TabIndex = 2;
            this.label22.Text = "ShortName";
            // 
            // tboxOwnerFullName
            // 
            this.tboxOwnerFullName.Location = new System.Drawing.Point(94, 44);
            this.tboxOwnerFullName.Name = "tboxOwnerFullName";
            this.tboxOwnerFullName.Size = new System.Drawing.Size(139, 23);
            this.tboxOwnerFullName.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(27, 47);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 17);
            this.label21.TabIndex = 2;
            this.label21.Text = "FullName";
            // 
            // tboxDomainUser
            // 
            this.tboxDomainUser.Location = new System.Drawing.Point(94, 15);
            this.tboxDomainUser.Name = "tboxDomainUser";
            this.tboxDomainUser.Size = new System.Drawing.Size(139, 23);
            this.tboxDomainUser.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 17);
            this.label20.TabIndex = 2;
            this.label20.Text = "Domain\\User";
            // 
            // listViewOwnerTranslate
            // 
            this.listViewOwnerTranslate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDomainUser,
            this.columnHeaderFullName,
            this.columnHeaderShortName,
            this.columnHeaderPhone});
            this.listViewOwnerTranslate.Location = new System.Drawing.Point(6, 6);
            this.listViewOwnerTranslate.Name = "listViewOwnerTranslate";
            this.listViewOwnerTranslate.Size = new System.Drawing.Size(501, 192);
            this.listViewOwnerTranslate.TabIndex = 0;
            this.listViewOwnerTranslate.UseCompatibleStateImageBehavior = false;
            this.listViewOwnerTranslate.View = System.Windows.Forms.View.Details;
            this.listViewOwnerTranslate.SelectedIndexChanged += new System.EventHandler(this.listViewOwnerTranslate_SelectedIndexChanged);
            this.listViewOwnerTranslate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewOwnerTranslate_KeyDown);
            // 
            // columnHeaderDomainUser
            // 
            this.columnHeaderDomainUser.Text = "Domain\\User";
            this.columnHeaderDomainUser.Width = 160;
            // 
            // columnHeaderFullName
            // 
            this.columnHeaderFullName.Text = "FullName";
            this.columnHeaderFullName.Width = 135;
            // 
            // columnHeaderShortName
            // 
            this.columnHeaderShortName.Text = "ShortName";
            this.columnHeaderShortName.Width = 115;
            // 
            // columnHeaderPhone
            // 
            this.columnHeaderPhone.Text = "Phone";
            this.columnHeaderPhone.Width = 80;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.label13);
            this.tabPageAbout.Controls.Add(this.label11);
            this.tabPageAbout.Controls.Add(this.label9);
            this.tabPageAbout.Controls.Add(this.labelVersion);
            this.tabPageAbout.Controls.Add(this.label12);
            this.tabPageAbout.Controls.Add(this.label5);
            this.tabPageAbout.Controls.Add(this.label10);
            this.tabPageAbout.Controls.Add(this.pictureBox1);
            this.tabPageAbout.Controls.Add(this.label8);
            this.tabPageAbout.Controls.Add(this.label6);
            this.tabPageAbout.Controls.Add(this.label4);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 26);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(513, 341);
            this.tabPageAbout.TabIndex = 4;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(223, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(278, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "https://github.com/yyscamper/com_owner_spy";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(223, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "yyscamper@gmail.com";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "yyscamper";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(223, 40);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(31, 17);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "v1.1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(135, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Source Code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "COM Owner Spy";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(177, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Email:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ComOwnerSpy.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(16, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(168, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Author:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(164, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(100, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Application Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(477, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Default";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 421);
            this.Controls.Add(this.tabCtrlSetting);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormSetting";
            this.Text = "COMOwnerSpy Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.tabCtrlSetting.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.groupBoxRefreshSetting.ResumeLayout(false);
            this.groupBoxRefreshSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRefreshInterval)).EndInit();
            this.tabPageComPorts.ResumeLayout(false);
            this.tabPageComPorts.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortEnd)).EndInit();
            this.tabPageSuspectProc.ResumeLayout(false);
            this.tabPageSuspectProc.PerformLayout();
            this.ctxMenuListBoxSuspectProcNames.ResumeLayout(false);
            this.tabPageDeviceMap.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageOwner.ResumeLayout(false);
            this.groupOwnerTranslateInfo.ResumeLayout(false);
            this.groupOwnerTranslateInfo.PerformLayout();
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlSetting;
        private System.Windows.Forms.TabPage tabPageComPorts;
        private System.Windows.Forms.TabPage tabPageSuspectProc;
        private System.Windows.Forms.TabPage tabPageDeviceMap;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.Button btnClearPorts;
        private System.Windows.Forms.Button btnResumePort;
        private System.Windows.Forms.Button btnRemovePort;
        private System.Windows.Forms.ListBox lboxRemovedPorts;
        private System.Windows.Forms.ListBox lboxSelectedPorts;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown nudPortStart;
        private System.Windows.Forms.NumericUpDown nudPortEnd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tboxPortSingleAddInput;
        private System.Windows.Forms.Button btnPortsSingleAdd;
        private System.Windows.Forms.Button btnPortsRangeAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddProcName;
        private System.Windows.Forms.TextBox tboxInputProcName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lboxSuspectProcNames;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView listViewDeviceMapTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tboxDeviceFileName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tboxPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdateOrAdd;
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderDeviceFileName;
        private System.Windows.Forms.Button btnBuildDeviceFileNameMap;
        private System.Windows.Forms.Button btnCancleUpdatePortDeviceMapEntry;
        private System.Windows.Forms.Button btnAddSerialDevicePattern;
        private System.Windows.Forms.TextBox tboxSerialDevicePattern;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox lboxSerialDeviceNamePatterns;
        private System.Windows.Forms.ContextMenuStrip ctxMenuListBoxSuspectProcNames;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxRowHeight;
        private System.Windows.Forms.CheckBox cboxEnableAutoRefreshAtStartup;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown upDownRefreshInterval;
        private System.Windows.Forms.GroupBox groupBoxRefreshSetting;
        private System.Windows.Forms.TabPage tabPageOwner;
        private System.Windows.Forms.ListView listViewOwnerTranslate;
        private System.Windows.Forms.GroupBox groupOwnerTranslateInfo;
        private System.Windows.Forms.TextBox tboxDomainUser;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tboxOwnerFullName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ColumnHeader columnHeaderDomainUser;
        private System.Windows.Forms.ColumnHeader columnHeaderFullName;
        private System.Windows.Forms.ColumnHeader columnHeaderShortName;
        private System.Windows.Forms.ColumnHeader columnHeaderPhone;
        private System.Windows.Forms.TextBox tboxOwnerPhone;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tboxOwnerShortName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnAddNewOwnerTranslate;
        private System.Windows.Forms.Button btnDeleteOwnerTranslate;
        private System.Windows.Forms.ComboBox comboxBoxOwnerShowFormat;
        private System.Windows.Forms.Label label24;
    }
}