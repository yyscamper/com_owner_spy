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
            this.tabPageSuspectProc = new System.Windows.Forms.TabPage();
            this.btnAddProcName = new System.Windows.Forms.Button();
            this.tboxInputProcName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lboxSuspectProcNames = new System.Windows.Forms.ListBox();
            this.ctxMenuListBoxSuspectProcNames = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageDeviceMap = new System.Windows.Forms.TabPage();
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
            this.tabPageSuspectProc.SuspendLayout();
            this.ctxMenuListBoxSuspectProcNames.SuspendLayout();
            this.tabPageDeviceMap.SuspendLayout();
            this.tabPageOwner.SuspendLayout();
            this.groupOwnerTranslateInfo.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrlSetting
            // 
            this.tabCtrlSetting.Controls.Add(this.tabPageGeneral);
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
            this.upDownRefreshInterval.ValueChanged += new System.EventHandler(this.upDownRefreshInterval_ValueChanged);
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
            this.comboxBoxOwnerShowFormat.Size = new System.Drawing.Size(130, 25);
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
            this.comboBoxRowHeight.Size = new System.Drawing.Size(130, 25);
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
            // tabPageSuspectProc
            // 
            this.tabPageSuspectProc.Controls.Add(this.btnAddProcName);
            this.tabPageSuspectProc.Controls.Add(this.tboxInputProcName);
            this.tabPageSuspectProc.Controls.Add(this.label3);
            this.tabPageSuspectProc.Controls.Add(this.lboxSuspectProcNames);
            this.tabPageSuspectProc.Location = new System.Drawing.Point(4, 26);
            this.tabPageSuspectProc.Name = "tabPageSuspectProc";
            this.tabPageSuspectProc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSuspectProc.Size = new System.Drawing.Size(513, 341);
            this.tabPageSuspectProc.TabIndex = 1;
            this.tabPageSuspectProc.Text = "Suspect Proc.";
            this.tabPageSuspectProc.UseVisualStyleBackColor = true;
            // 
            // btnAddProcName
            // 
            this.btnAddProcName.Location = new System.Drawing.Point(288, 80);
            this.btnAddProcName.Name = "btnAddProcName";
            this.btnAddProcName.Size = new System.Drawing.Size(42, 32);
            this.btnAddProcName.TabIndex = 1;
            this.btnAddProcName.Text = "ADD";
            this.btnAddProcName.UseVisualStyleBackColor = true;
            this.btnAddProcName.Click += new System.EventHandler(this.btnAddProcName_Click);
            // 
            // tboxInputProcName
            // 
            this.tboxInputProcName.Location = new System.Drawing.Point(200, 51);
            this.tboxInputProcName.Name = "tboxInputProcName";
            this.tboxInputProcName.Size = new System.Drawing.Size(130, 23);
            this.tboxInputProcName.TabIndex = 0;
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
            // lboxSuspectProcNames
            // 
            this.lboxSuspectProcNames.ContextMenuStrip = this.ctxMenuListBoxSuspectProcNames;
            this.lboxSuspectProcNames.FormattingEnabled = true;
            this.lboxSuspectProcNames.ItemHeight = 17;
            this.lboxSuspectProcNames.Location = new System.Drawing.Point(16, 51);
            this.lboxSuspectProcNames.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lboxSuspectProcNames.Name = "lboxSuspectProcNames";
            this.lboxSuspectProcNames.Size = new System.Drawing.Size(178, 276);
            this.lboxSuspectProcNames.TabIndex = 4;
            this.lboxSuspectProcNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lboxSuspectProcNamesOrPatterns_KeyDown);
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
            // tabPageDeviceMap
            // 
            this.tabPageDeviceMap.Controls.Add(this.listViewDeviceMapTable);
            this.tabPageDeviceMap.Location = new System.Drawing.Point(4, 26);
            this.tabPageDeviceMap.Name = "tabPageDeviceMap";
            this.tabPageDeviceMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeviceMap.Size = new System.Drawing.Size(513, 341);
            this.tabPageDeviceMap.TabIndex = 2;
            this.tabPageDeviceMap.Text = "Map Table";
            this.tabPageDeviceMap.UseVisualStyleBackColor = true;
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
            this.listViewOwnerTranslate.DoubleClick += new System.EventHandler(this.listViewOwnerTranslate_DoubleClick);
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
            this.tabPageSuspectProc.ResumeLayout(false);
            this.tabPageSuspectProc.PerformLayout();
            this.ctxMenuListBoxSuspectProcNames.ResumeLayout(false);
            this.tabPageDeviceMap.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPageSuspectProc;
        private System.Windows.Forms.TabPage tabPageDeviceMap;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.Button btnSave;
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
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderDeviceFileName;
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