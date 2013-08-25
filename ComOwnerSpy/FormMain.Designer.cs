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
            this.checkBoxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnPortsSetting = new System.Windows.Forms.Button();
            this.groupTitleAction = new System.Windows.Forms.GroupBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.ctxMenuPortsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuKill = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxJumpPort = new System.Windows.Forms.ComboBox();
            this.btnJumpPort = new System.Windows.Forms.Button();
            this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupTitleAction.SuspendLayout();
            this.ctxMenuPortsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPortTable
            // 
            this.listPortTable.ContextMenuStrip = this.ctxMenuPortsTable;
            this.listPortTable.Location = new System.Drawing.Point(7, 63);
            this.listPortTable.Margin = new System.Windows.Forms.Padding(4);
            this.listPortTable.Name = "listPortTable";
            this.listPortTable.Size = new System.Drawing.Size(596, 308);
            this.listPortTable.TabIndex = 0;
            this.listPortTable.UseCompatibleStateImageBehavior = false;
            this.listPortTable.View = System.Windows.Forms.View.Details;
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoRefresh.AutoSize = true;
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(424, 19);
            this.checkBoxAutoRefresh.Name = "checkBoxAutoRefresh";
            this.checkBoxAutoRefresh.Size = new System.Drawing.Size(102, 21);
            this.checkBoxAutoRefresh.TabIndex = 4;
            this.checkBoxAutoRefresh.Text = "Auto Refresh";
            this.checkBoxAutoRefresh.UseVisualStyleBackColor = true;
            this.checkBoxAutoRefresh.CheckedChanged += new System.EventHandler(this.checkBoxAutoRefresh_CheckedChanged);
            // 
            // btnPortsSetting
            // 
            this.btnPortsSetting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.groupTitleAction.Controls.Add(this.comboBoxJumpPort);
            this.groupTitleAction.Controls.Add(this.btnRefresh);
            this.groupTitleAction.Controls.Add(this.btnJumpPort);
            this.groupTitleAction.Controls.Add(this.checkBoxAutoRefresh);
            this.groupTitleAction.Controls.Add(this.btnSetting);
            this.groupTitleAction.Controls.Add(this.btnPortsSetting);
            this.groupTitleAction.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupTitleAction.Location = new System.Drawing.Point(6, 4);
            this.groupTitleAction.Name = "groupTitleAction";
            this.groupTitleAction.Size = new System.Drawing.Size(602, 52);
            this.groupTitleAction.TabIndex = 3;
            this.groupTitleAction.TabStop = false;
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetting.Location = new System.Drawing.Point(79, 14);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(64, 32);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "Options";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // ctxMenuPortsTable
            // 
            this.ctxMenuPortsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRefresh,
            this.menuKill});
            this.ctxMenuPortsTable.Name = "ctxMenuPortsTable";
            this.ctxMenuPortsTable.Size = new System.Drawing.Size(121, 48);
            this.ctxMenuPortsTable.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuPortsTable_Opening);
            // 
            // menuKill
            // 
            this.menuKill.Name = "menuKill";
            this.menuKill.Size = new System.Drawing.Size(120, 22);
            this.menuKill.Text = "Kill";
            this.menuKill.Click += new System.EventHandler(this.menuKill_Click);
            // 
            // comboBoxJumpPort
            // 
            this.comboBoxJumpPort.FormattingEnabled = true;
            this.comboBoxJumpPort.Location = new System.Drawing.Point(182, 17);
            this.comboBoxJumpPort.Name = "comboBoxJumpPort";
            this.comboBoxJumpPort.Size = new System.Drawing.Size(65, 25);
            this.comboBoxJumpPort.TabIndex = 5;
            // 
            // btnJumpPort
            // 
            this.btnJumpPort.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJumpPort.Location = new System.Drawing.Point(253, 14);
            this.btnJumpPort.Name = "btnJumpPort";
            this.btnJumpPort.Size = new System.Drawing.Size(64, 32);
            this.btnJumpPort.TabIndex = 1;
            this.btnJumpPort.Text = "Jump";
            this.btnJumpPort.UseVisualStyleBackColor = true;
            this.btnJumpPort.Click += new System.EventHandler(this.btnJumpPort_Click);
            // 
            // menuRefresh
            // 
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size = new System.Drawing.Size(120, 22);
            this.menuRefresh.Text = "Refresh";
            this.menuRefresh.Click += new System.EventHandler(this.menuRefreshPortInfo_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(532, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 32);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // bntSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 376);
            this.Controls.Add(this.groupTitleAction);
            this.Controls.Add(this.listPortTable);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "bntSetting";
            this.Text = "COM Owner Spy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bntSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupTitleAction.ResumeLayout(false);
            this.groupTitleAction.PerformLayout();
            this.ctxMenuPortsTable.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}

