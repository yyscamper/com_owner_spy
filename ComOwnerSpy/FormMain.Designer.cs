namespace ComOwnerSpy
{
    partial class bntSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bntSetting));
            this.listPortTable = new System.Windows.Forms.ListView();
            this.ctxMenuPortsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKill = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnPortsSetting = new System.Windows.Forms.Button();
            this.groupTitleAction = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRowHeight = new System.Windows.Forms.ComboBox();
            this.comboBoxJumpPort = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnJumpPort = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.theStatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelRefreshTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelRefreshConsumeTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctxMenuPortsTable.SuspendLayout();
            this.groupTitleAction.SuspendLayout();
            this.theStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPortTable
            // 
            this.listPortTable.ContextMenuStrip = this.ctxMenuPortsTable;
            this.listPortTable.Location = new System.Drawing.Point(7, 60);
            this.listPortTable.Margin = new System.Windows.Forms.Padding(4);
            this.listPortTable.Name = "listPortTable";
            this.listPortTable.Size = new System.Drawing.Size(784, 308);
            this.listPortTable.TabIndex = 0;
            this.listPortTable.UseCompatibleStateImageBehavior = false;
            this.listPortTable.View = System.Windows.Forms.View.Details;
            // 
            // ctxMenuPortsTable
            // 
            this.ctxMenuPortsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRefresh,
            this.menuKill});
            this.ctxMenuPortsTable.Name = "ctxMenuPortsTable";
            this.ctxMenuPortsTable.Size = new System.Drawing.Size(113, 48);
            this.ctxMenuPortsTable.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuPortsTable_Opening);
            // 
            // menuRefresh
            // 
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size = new System.Drawing.Size(112, 22);
            this.menuRefresh.Text = "Refresh";
            this.menuRefresh.Click += new System.EventHandler(this.menuRefreshPortInfo_Click);
            // 
            // menuKill
            // 
            this.menuKill.BackColor = System.Drawing.Color.Red;
            this.menuKill.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuKill.ForeColor = System.Drawing.Color.White;
            this.menuKill.Name = "menuKill";
            this.menuKill.Size = new System.Drawing.Size(112, 22);
            this.menuKill.Text = "Kill";
            this.menuKill.Click += new System.EventHandler(this.menuKill_Click);
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoRefresh.AutoSize = true;
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(607, 19);
            this.checkBoxAutoRefresh.Name = "checkBoxAutoRefresh";
            this.checkBoxAutoRefresh.Size = new System.Drawing.Size(102, 21);
            this.checkBoxAutoRefresh.TabIndex = 4;
            this.checkBoxAutoRefresh.Text = "Auto Refresh";
            this.checkBoxAutoRefresh.UseVisualStyleBackColor = true;
            this.checkBoxAutoRefresh.CheckedChanged += new System.EventHandler(this.checkBoxAutoRefresh_CheckedChanged);
            // 
            // btnPortsSetting
            // 
            this.btnPortsSetting.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortsSetting.Location = new System.Drawing.Point(6, 14);
            this.btnPortsSetting.Name = "btnPortsSetting";
            this.btnPortsSetting.Size = new System.Drawing.Size(64, 32);
            this.btnPortsSetting.TabIndex = 0;
            this.btnPortsSetting.Text = "Ports";
            this.btnPortsSetting.UseVisualStyleBackColor = true;
            this.btnPortsSetting.Click += new System.EventHandler(this.btnPortsSetting_Click);
            // 
            // groupTitleAction
            // 
            this.groupTitleAction.Controls.Add(this.label1);
            this.groupTitleAction.Controls.Add(this.comboBoxRowHeight);
            this.groupTitleAction.Controls.Add(this.comboBoxJumpPort);
            this.groupTitleAction.Controls.Add(this.btnRefresh);
            this.groupTitleAction.Controls.Add(this.btnJumpPort);
            this.groupTitleAction.Controls.Add(this.checkBoxAutoRefresh);
            this.groupTitleAction.Controls.Add(this.btnSetting);
            this.groupTitleAction.Controls.Add(this.btnPortsSetting);
            this.groupTitleAction.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupTitleAction.Location = new System.Drawing.Point(6, 2);
            this.groupTitleAction.Name = "groupTitleAction";
            this.groupTitleAction.Size = new System.Drawing.Size(785, 52);
            this.groupTitleAction.TabIndex = 3;
            this.groupTitleAction.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Row Height:";
            // 
            // comboBoxRowHeight
            // 
            this.comboBoxRowHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRowHeight.FormattingEnabled = true;
            this.comboBoxRowHeight.Items.AddRange(new object[] {
            "Very Low",
            "Low",
            "Normal",
            "High",
            "Very High"});
            this.comboBoxRowHeight.Location = new System.Drawing.Point(410, 18);
            this.comboBoxRowHeight.Name = "comboBoxRowHeight";
            this.comboBoxRowHeight.Size = new System.Drawing.Size(89, 25);
            this.comboBoxRowHeight.TabIndex = 6;
            this.comboBoxRowHeight.SelectedIndexChanged += new System.EventHandler(this.comboBoxRowHeight_SelectedIndexChanged);
            // 
            // comboBoxJumpPort
            // 
            this.comboBoxJumpPort.FormattingEnabled = true;
            this.comboBoxJumpPort.Location = new System.Drawing.Point(167, 17);
            this.comboBoxJumpPort.Name = "comboBoxJumpPort";
            this.comboBoxJumpPort.Size = new System.Drawing.Size(80, 25);
            this.comboBoxJumpPort.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(715, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 32);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnJumpPort
            // 
            this.btnJumpPort.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJumpPort.Location = new System.Drawing.Point(252, 14);
            this.btnJumpPort.Name = "btnJumpPort";
            this.btnJumpPort.Size = new System.Drawing.Size(64, 32);
            this.btnJumpPort.TabIndex = 1;
            this.btnJumpPort.Text = "Jump";
            this.btnJumpPort.UseVisualStyleBackColor = true;
            this.btnJumpPort.Click += new System.EventHandler(this.btnJumpPort_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetting.Location = new System.Drawing.Point(79, 14);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(64, 32);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "Options";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // theStatusBar
            // 
            this.theStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusLabelRefreshTime,
            this.toolStripStatusLabel3,
            this.statusLabelRefreshConsumeTime});
            this.theStatusBar.Location = new System.Drawing.Point(0, 354);
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
            this.statusLabelRefreshTime.Size = new System.Drawing.Size(72, 17);
            this.statusLabelRefreshTime.Text = "??/?? ??:??:??";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(115, 17);
            this.toolStripStatusLabel3.Text = "Refresh Consumes:";
            // 
            // statusLabelRefreshConsumeTime
            // 
            this.statusLabelRefreshConsumeTime.Name = "statusLabelRefreshConsumeTime";
            this.statusLabelRefreshConsumeTime.Size = new System.Drawing.Size(40, 17);
            this.statusLabelRefreshConsumeTime.Text = "?.? sec";
            // 
            // bntSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 376);
            this.Controls.Add(this.theStatusBar);
            this.Controls.Add(this.groupTitleAction);
            this.Controls.Add(this.listPortTable);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "bntSetting";
            this.Text = "COM Owner Spy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bntSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.ctxMenuPortsTable.ResumeLayout(false);
            this.groupTitleAction.ResumeLayout(false);
            this.groupTitleAction.PerformLayout();
            this.theStatusBar.ResumeLayout(false);
            this.theStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listPortTable;
        private System.Windows.Forms.CheckBox checkBoxAutoRefresh;
        private System.Windows.Forms.Button btnPortsSetting;
        private System.Windows.Forms.GroupBox groupTitleAction;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.ContextMenuStrip ctxMenuPortsTable;
        private System.Windows.Forms.ToolStripMenuItem menuKill;
        private System.Windows.Forms.ComboBox comboBoxJumpPort;
        private System.Windows.Forms.Button btnJumpPort;
        private System.Windows.Forms.ToolStripMenuItem menuRefresh;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRowHeight;
        private System.Windows.Forms.StatusStrip theStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelRefreshTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelRefreshConsumeTime;
    }
}

