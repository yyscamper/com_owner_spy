namespace ComOwnerSpy
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listPortTable = new System.Windows.Forms.ListView();
            this.ctxMenuPortsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuKill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEnableAutoRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOwnerFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOwnerFormatDomainUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOwnerFormatFullName = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOwnerFormatShortName = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOwnerFormatPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetRowHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowHeightVeryLow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowHeightLow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowHeightNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowHeightHigh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowHeightVeryHigh = new System.Windows.Forms.ToolStripMenuItem();
            this.picBoxSelectAutoRefreshEnable = new System.Windows.Forms.PictureBox();
            this.picBoxSetting = new System.Windows.Forms.PictureBox();
            this.picBoxGotoPort = new System.Windows.Forms.PictureBox();
            this.picBoxRefresh = new System.Windows.Forms.PictureBox();
            this.comboBoxGotoPort = new System.Windows.Forms.ComboBox();
            this.theStatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelRefreshTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelRefreshConsumeTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelA = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelB = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelC = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelD = new System.Windows.Forms.Panel();
            this.ctxMenuPortsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSelectAutoRefreshEnable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGotoPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRefresh)).BeginInit();
            this.panelA.SuspendLayout();
            this.panelB.SuspendLayout();
            this.panelC.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPortTable
            // 
            this.listPortTable.BackColor = System.Drawing.Color.LightBlue;
            this.listPortTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listPortTable.ContextMenuStrip = this.ctxMenuPortsTable;
            this.listPortTable.Location = new System.Drawing.Point(7, 92);
            this.listPortTable.Margin = new System.Windows.Forms.Padding(4);
            this.listPortTable.Name = "listPortTable";
            this.listPortTable.Size = new System.Drawing.Size(784, 454);
            this.listPortTable.TabIndex = 0;
            this.listPortTable.UseCompatibleStateImageBehavior = false;
            this.listPortTable.View = System.Windows.Forms.View.Details;
            // 
            // ctxMenuPortsTable
            // 
            this.ctxMenuPortsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuKill,
            this.menuEnableAutoRefresh,
            this.menuOwnerFormat,
            this.menuSetRowHeight});
            this.ctxMenuPortsTable.Name = "ctxMenuPortsTable";
            this.ctxMenuPortsTable.Size = new System.Drawing.Size(160, 92);
            this.ctxMenuPortsTable.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuPortsTable_Opening);
            this.ctxMenuPortsTable.Click += new System.EventHandler(this.ctxMenuPortsTable_Click);
            // 
            // menuKill
            // 
            this.menuKill.BackColor = System.Drawing.Color.Red;
            this.menuKill.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuKill.ForeColor = System.Drawing.Color.White;
            this.menuKill.Name = "menuKill";
            this.menuKill.Size = new System.Drawing.Size(159, 22);
            this.menuKill.Text = "Kill";
            this.menuKill.Click += new System.EventHandler(this.menuKill_Click);
            // 
            // menuEnableAutoRefresh
            // 
            this.menuEnableAutoRefresh.Name = "menuEnableAutoRefresh";
            this.menuEnableAutoRefresh.Size = new System.Drawing.Size(159, 22);
            this.menuEnableAutoRefresh.Text = "Auto Refresh";
            this.menuEnableAutoRefresh.Click += new System.EventHandler(this.menuEnableAutoRefresh_Click);
            // 
            // menuOwnerFormat
            // 
            this.menuOwnerFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOwnerFormatDomainUser,
            this.menuOwnerFormatFullName,
            this.menuOwnerFormatShortName,
            this.menuOwnerFormatPhone});
            this.menuOwnerFormat.Name = "menuOwnerFormat";
            this.menuOwnerFormat.Size = new System.Drawing.Size(159, 22);
            this.menuOwnerFormat.Text = "Owner Format";
            // 
            // menuOwnerFormatDomainUser
            // 
            this.menuOwnerFormatDomainUser.Name = "menuOwnerFormatDomainUser";
            this.menuOwnerFormatDomainUser.Size = new System.Drawing.Size(152, 22);
            this.menuOwnerFormatDomainUser.Text = "Domain User";
            this.menuOwnerFormatDomainUser.Click += new System.EventHandler(this.menuEnableAutoRefresh_Click);
            // 
            // menuOwnerFormatFullName
            // 
            this.menuOwnerFormatFullName.Name = "menuOwnerFormatFullName";
            this.menuOwnerFormatFullName.Size = new System.Drawing.Size(152, 22);
            this.menuOwnerFormatFullName.Text = "Full Name";
            this.menuOwnerFormatFullName.Click += new System.EventHandler(this.menuEnableAutoRefresh_Click);
            // 
            // menuOwnerFormatShortName
            // 
            this.menuOwnerFormatShortName.Name = "menuOwnerFormatShortName";
            this.menuOwnerFormatShortName.Size = new System.Drawing.Size(152, 22);
            this.menuOwnerFormatShortName.Text = "Short Name";
            this.menuOwnerFormatShortName.Click += new System.EventHandler(this.menuEnableAutoRefresh_Click);
            // 
            // menuOwnerFormatPhone
            // 
            this.menuOwnerFormatPhone.Name = "menuOwnerFormatPhone";
            this.menuOwnerFormatPhone.Size = new System.Drawing.Size(152, 22);
            this.menuOwnerFormatPhone.Text = "Phone";
            this.menuOwnerFormatPhone.Click += new System.EventHandler(this.menuEnableAutoRefresh_Click);
            // 
            // menuSetRowHeight
            // 
            this.menuSetRowHeight.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRowHeightVeryLow,
            this.menuRowHeightLow,
            this.menuRowHeightNormal,
            this.menuRowHeightHigh,
            this.menuRowHeightVeryHigh});
            this.menuSetRowHeight.Name = "menuSetRowHeight";
            this.menuSetRowHeight.Size = new System.Drawing.Size(159, 22);
            this.menuSetRowHeight.Text = "Row Height";
            // 
            // menuRowHeightVeryLow
            // 
            this.menuRowHeightVeryLow.Name = "menuRowHeightVeryLow";
            this.menuRowHeightVeryLow.Size = new System.Drawing.Size(133, 22);
            this.menuRowHeightVeryLow.Text = "Very Low";
            this.menuRowHeightVeryLow.Click += new System.EventHandler(this.ctxMenuPortsTable_Click);
            // 
            // menuRowHeightLow
            // 
            this.menuRowHeightLow.Name = "menuRowHeightLow";
            this.menuRowHeightLow.Size = new System.Drawing.Size(133, 22);
            this.menuRowHeightLow.Text = "Low";
            this.menuRowHeightLow.Click += new System.EventHandler(this.ctxMenuPortsTable_Click);
            // 
            // menuRowHeightNormal
            // 
            this.menuRowHeightNormal.Name = "menuRowHeightNormal";
            this.menuRowHeightNormal.Size = new System.Drawing.Size(133, 22);
            this.menuRowHeightNormal.Text = "Normal";
            this.menuRowHeightNormal.Click += new System.EventHandler(this.ctxMenuPortsTable_Click);
            // 
            // menuRowHeightHigh
            // 
            this.menuRowHeightHigh.Name = "menuRowHeightHigh";
            this.menuRowHeightHigh.Size = new System.Drawing.Size(133, 22);
            this.menuRowHeightHigh.Text = "High";
            this.menuRowHeightHigh.Click += new System.EventHandler(this.ctxMenuPortsTable_Click);
            // 
            // menuRowHeightVeryHigh
            // 
            this.menuRowHeightVeryHigh.Name = "menuRowHeightVeryHigh";
            this.menuRowHeightVeryHigh.Size = new System.Drawing.Size(133, 22);
            this.menuRowHeightVeryHigh.Text = "Very High";
            this.menuRowHeightVeryHigh.Click += new System.EventHandler(this.ctxMenuPortsTable_Click);
            // 
            // picBoxSelectAutoRefreshEnable
            // 
            this.picBoxSelectAutoRefreshEnable.Image = global::ComOwnerSpy.Properties.Resources.switch_on;
            this.picBoxSelectAutoRefreshEnable.Location = new System.Drawing.Point(12, 21);
            this.picBoxSelectAutoRefreshEnable.Name = "picBoxSelectAutoRefreshEnable";
            this.picBoxSelectAutoRefreshEnable.Size = new System.Drawing.Size(70, 32);
            this.picBoxSelectAutoRefreshEnable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxSelectAutoRefreshEnable.TabIndex = 6;
            this.picBoxSelectAutoRefreshEnable.TabStop = false;
            this.picBoxSelectAutoRefreshEnable.EnabledChanged += new System.EventHandler(this.picBoxSelectAutoRefreshEnable_EnabledChanged);
            this.picBoxSelectAutoRefreshEnable.Click += new System.EventHandler(this.picBoxSelectAutoRefreshEnable_Click);
            // 
            // picBoxSetting
            // 
            this.picBoxSetting.Image = global::ComOwnerSpy.Properties.Resources.setting;
            this.picBoxSetting.Location = new System.Drawing.Point(7, 1);
            this.picBoxSetting.Name = "picBoxSetting";
            this.picBoxSetting.Size = new System.Drawing.Size(54, 54);
            this.picBoxSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxSetting.TabIndex = 5;
            this.picBoxSetting.TabStop = false;
            this.picBoxSetting.EnabledChanged += new System.EventHandler(this.picBoxSetting_EnabledChanged);
            this.picBoxSetting.Click += new System.EventHandler(this.picBoxSetting_Click);
            this.picBoxSetting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxRefresh_MouseDown);
            this.picBoxSetting.MouseLeave += new System.EventHandler(this.picBoxSetting_MouseLeave);
            this.picBoxSetting.MouseHover += new System.EventHandler(this.picBoxRefresh_MouseHover);
            this.picBoxSetting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxRefresh_MouseMove);
            this.picBoxSetting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBoxRefresh_MouseUp);
            // 
            // picBoxGotoPort
            // 
            this.picBoxGotoPort.Image = global::ComOwnerSpy.Properties.Resources._goto;
            this.picBoxGotoPort.Location = new System.Drawing.Point(101, 10);
            this.picBoxGotoPort.Name = "picBoxGotoPort";
            this.picBoxGotoPort.Size = new System.Drawing.Size(54, 54);
            this.picBoxGotoPort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxGotoPort.TabIndex = 5;
            this.picBoxGotoPort.TabStop = false;
            this.picBoxGotoPort.EnabledChanged += new System.EventHandler(this.picBoxGotoPort_EnabledChanged);
            this.picBoxGotoPort.Click += new System.EventHandler(this.picBoxGotoPort_Click);
            this.picBoxGotoPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxRefresh_MouseDown);
            this.picBoxGotoPort.MouseLeave += new System.EventHandler(this.picBoxSetting_MouseLeave);
            this.picBoxGotoPort.MouseHover += new System.EventHandler(this.picBoxRefresh_MouseHover);
            this.picBoxGotoPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxRefresh_MouseMove);
            this.picBoxGotoPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBoxRefresh_MouseUp);
            // 
            // picBoxRefresh
            // 
            this.picBoxRefresh.Image = global::ComOwnerSpy.Properties.Resources.refresh_enabled;
            this.picBoxRefresh.Location = new System.Drawing.Point(89, 10);
            this.picBoxRefresh.Name = "picBoxRefresh";
            this.picBoxRefresh.Size = new System.Drawing.Size(54, 54);
            this.picBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxRefresh.TabIndex = 5;
            this.picBoxRefresh.TabStop = false;
            this.picBoxRefresh.EnabledChanged += new System.EventHandler(this.picBoxRefresh_EnabledChanged);
            this.picBoxRefresh.Click += new System.EventHandler(this.picBoxRefresh_Click);
            this.picBoxRefresh.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxRefresh_MouseDown);
            this.picBoxRefresh.MouseLeave += new System.EventHandler(this.picBoxSetting_MouseLeave);
            this.picBoxRefresh.MouseHover += new System.EventHandler(this.picBoxRefresh_MouseHover);
            this.picBoxRefresh.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxRefresh_MouseMove);
            this.picBoxRefresh.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBoxRefresh_MouseUp);
            // 
            // comboBoxGotoPort
            // 
            this.comboBoxGotoPort.FormattingEnabled = true;
            this.comboBoxGotoPort.Location = new System.Drawing.Point(5, 25);
            this.comboBoxGotoPort.Name = "comboBoxGotoPort";
            this.comboBoxGotoPort.Size = new System.Drawing.Size(92, 25);
            this.comboBoxGotoPort.TabIndex = 2;
            this.comboBoxGotoPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxJumpPort_SelectedIndexChanged);
            // 
            // theStatusBar
            // 
            this.theStatusBar.Location = new System.Drawing.Point(0, 550);
            this.theStatusBar.Name = "theStatusBar";
            this.theStatusBar.Size = new System.Drawing.Size(796, 22);
            this.theStatusBar.TabIndex = 4;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel1.Text = "Last Refresh Time:";
            // 
            // statusLabelRefreshTime
            // 
            this.statusLabelRefreshTime.Name = "statusLabelRefreshTime";
            this.statusLabelRefreshTime.Size = new System.Drawing.Size(83, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(115, 17);
            // 
            // statusLabelRefreshConsumeTime
            // 
            this.statusLabelRefreshConsumeTime.Name = "statusLabelRefreshConsumeTime";
            this.statusLabelRefreshConsumeTime.Size = new System.Drawing.Size(46, 17);
            // 
            // panelA
            // 
            this.panelA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelA.Controls.Add(this.label2);
            this.panelA.Controls.Add(this.picBoxSelectAutoRefreshEnable);
            this.panelA.Controls.Add(this.picBoxRefresh);
            this.panelA.Location = new System.Drawing.Point(7, 5);
            this.panelA.Name = "panelA";
            this.panelA.Size = new System.Drawing.Size(149, 75);
            this.panelA.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Auto Refresh";
            // 
            // panelB
            // 
            this.panelB.BackColor = System.Drawing.Color.PaleGreen;
            this.panelB.Controls.Add(this.label4);
            this.panelB.Controls.Add(this.picBoxGotoPort);
            this.panelB.Controls.Add(this.comboBoxGotoPort);
            this.panelB.Location = new System.Drawing.Point(166, 5);
            this.panelB.Name = "panelB";
            this.panelB.Size = new System.Drawing.Size(161, 75);
            this.panelB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Go to Port";
            // 
            // panelC
            // 
            this.panelC.BackColor = System.Drawing.Color.Orange;
            this.panelC.Controls.Add(this.label3);
            this.panelC.Controls.Add(this.picBoxSetting);
            this.panelC.Location = new System.Drawing.Point(337, 5);
            this.panelC.Name = "panelC";
            this.panelC.Size = new System.Drawing.Size(66, 75);
            this.panelC.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Setting";
            // 
            // panelD
            // 
            this.panelD.BackColor = System.Drawing.Color.Khaki;
            this.panelD.Location = new System.Drawing.Point(415, 5);
            this.panelD.Name = "panelD";
            this.panelD.Size = new System.Drawing.Size(376, 75);
            this.panelD.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(796, 572);
            this.Controls.Add(this.panelD);
            this.Controls.Add(this.panelC);
            this.Controls.Add(this.panelB);
            this.Controls.Add(this.panelA);
            this.Controls.Add(this.theStatusBar);
            this.Controls.Add(this.listPortTable);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "COM Owner Spy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.ctxMenuPortsTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSelectAutoRefreshEnable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGotoPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRefresh)).EndInit();
            this.panelA.ResumeLayout(false);
            this.panelA.PerformLayout();
            this.panelB.ResumeLayout(false);
            this.panelB.PerformLayout();
            this.panelC.ResumeLayout(false);
            this.panelC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listPortTable;
        private System.Windows.Forms.ContextMenuStrip ctxMenuPortsTable;
        private System.Windows.Forms.ToolStripMenuItem menuKill;
        private System.Windows.Forms.ComboBox comboBoxGotoPort;
        private System.Windows.Forms.StatusStrip theStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelRefreshTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelRefreshConsumeTime;
        private System.Windows.Forms.PictureBox picBoxRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuEnableAutoRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuSetRowHeight;
        private System.Windows.Forms.ToolStripMenuItem menuRowHeightVeryLow;
        private System.Windows.Forms.ToolStripMenuItem menuRowHeightLow;
        private System.Windows.Forms.ToolStripMenuItem menuRowHeightNormal;
        private System.Windows.Forms.ToolStripMenuItem menuRowHeightHigh;
        private System.Windows.Forms.ToolStripMenuItem menuRowHeightVeryHigh;
        private System.Windows.Forms.ToolStripMenuItem menuOwnerFormat;
        private System.Windows.Forms.ToolStripMenuItem menuOwnerFormatDomainUser;
        private System.Windows.Forms.ToolStripMenuItem menuOwnerFormatFullName;
        private System.Windows.Forms.ToolStripMenuItem menuOwnerFormatShortName;
        private System.Windows.Forms.ToolStripMenuItem menuOwnerFormatPhone;
        private System.Windows.Forms.PictureBox picBoxSetting;
        private System.Windows.Forms.PictureBox picBoxGotoPort;
        private System.Windows.Forms.PictureBox picBoxSelectAutoRefreshEnable;
        private System.Windows.Forms.Panel panelA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelB;
        private System.Windows.Forms.Panel panelC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelD;
    }
}

