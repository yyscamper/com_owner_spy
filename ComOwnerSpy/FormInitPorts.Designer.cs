namespace ComOwnerSpy
{
    partial class FormSelectPorts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectPorts));
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClearPorts
            // 
            this.btnClearPorts.Location = new System.Drawing.Point(492, 146);
            this.btnClearPorts.Name = "btnClearPorts";
            this.btnClearPorts.Size = new System.Drawing.Size(54, 32);
            this.btnClearPorts.TabIndex = 3;
            this.btnClearPorts.Text = "Clear";
            this.btnClearPorts.UseVisualStyleBackColor = true;
            this.btnClearPorts.Click += new System.EventHandler(this.btnClearPorts_Click_1);
            // 
            // btnResumePort
            // 
            this.btnResumePort.Location = new System.Drawing.Point(142, 133);
            this.btnResumePort.Name = "btnResumePort";
            this.btnResumePort.Size = new System.Drawing.Size(54, 32);
            this.btnResumePort.TabIndex = 2;
            this.btnResumePort.Text = "<<";
            this.btnResumePort.UseVisualStyleBackColor = true;
            this.btnResumePort.Click += new System.EventHandler(this.btnResumePort_Click_1);
            // 
            // btnRemovePort
            // 
            this.btnRemovePort.Location = new System.Drawing.Point(142, 90);
            this.btnRemovePort.Name = "btnRemovePort";
            this.btnRemovePort.Size = new System.Drawing.Size(54, 32);
            this.btnRemovePort.TabIndex = 1;
            this.btnRemovePort.Text = ">>";
            this.btnRemovePort.UseVisualStyleBackColor = true;
            this.btnRemovePort.Click += new System.EventHandler(this.btnRemovePort_Click);
            // 
            // lboxRemovedPorts
            // 
            this.lboxRemovedPorts.FormattingEnabled = true;
            this.lboxRemovedPorts.ItemHeight = 17;
            this.lboxRemovedPorts.Location = new System.Drawing.Point(207, 37);
            this.lboxRemovedPorts.Name = "lboxRemovedPorts";
            this.lboxRemovedPorts.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lboxRemovedPorts.Size = new System.Drawing.Size(108, 310);
            this.lboxRemovedPorts.TabIndex = 12;
            // 
            // lboxSelectedPorts
            // 
            this.lboxSelectedPorts.FormattingEnabled = true;
            this.lboxSelectedPorts.ItemHeight = 17;
            this.lboxSelectedPorts.Location = new System.Drawing.Point(21, 37);
            this.lboxSelectedPorts.Name = "lboxSelectedPorts";
            this.lboxSelectedPorts.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lboxSelectedPorts.Size = new System.Drawing.Size(108, 310);
            this.lboxSelectedPorts.TabIndex = 13;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudPortStart);
            this.groupBox5.Controls.Add(this.nudPortEnd);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.tboxPortSingleAddInput);
            this.groupBox5.Controls.Add(this.btnPortsSingleAdd);
            this.groupBox5.Controls.Add(this.btnPortsRangeAdd);
            this.groupBox5.Location = new System.Drawing.Point(335, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(219, 155);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            // 
            // nudPortStart
            // 
            this.nudPortStart.Location = new System.Drawing.Point(9, 17);
            this.nudPortStart.Name = "nudPortStart";
            this.nudPortStart.Size = new System.Drawing.Size(65, 23);
            this.nudPortStart.TabIndex = 1;
            // 
            // nudPortEnd
            // 
            this.nudPortEnd.Location = new System.Drawing.Point(86, 17);
            this.nudPortEnd.Name = "nudPortEnd";
            this.nudPortEnd.Size = new System.Drawing.Size(65, 23);
            this.nudPortEnd.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(75, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 17);
            this.label16.TabIndex = 5;
            this.label16.Text = "-";
            // 
            // tboxPortSingleAddInput
            // 
            this.tboxPortSingleAddInput.Location = new System.Drawing.Point(9, 67);
            this.tboxPortSingleAddInput.Name = "tboxPortSingleAddInput";
            this.tboxPortSingleAddInput.Size = new System.Drawing.Size(142, 23);
            this.tboxPortSingleAddInput.TabIndex = 9;
            // 
            // btnPortsSingleAdd
            // 
            this.btnPortsSingleAdd.Location = new System.Drawing.Point(157, 64);
            this.btnPortsSingleAdd.Name = "btnPortsSingleAdd";
            this.btnPortsSingleAdd.Size = new System.Drawing.Size(54, 32);
            this.btnPortsSingleAdd.TabIndex = 1;
            this.btnPortsSingleAdd.Text = "Add";
            this.btnPortsSingleAdd.UseVisualStyleBackColor = true;
            this.btnPortsSingleAdd.Click += new System.EventHandler(this.btnPortsSingleAdd_Click);
            // 
            // btnPortsRangeAdd
            // 
            this.btnPortsRangeAdd.Location = new System.Drawing.Point(157, 15);
            this.btnPortsRangeAdd.Name = "btnPortsRangeAdd";
            this.btnPortsRangeAdd.Size = new System.Drawing.Size(54, 32);
            this.btnPortsRangeAdd.TabIndex = 0;
            this.btnPortsRangeAdd.Text = "Init";
            this.btnPortsRangeAdd.UseVisualStyleBackColor = true;
            this.btnPortsRangeAdd.Click += new System.EventHandler(this.btnPortsRangeAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Selected:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Removed:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(500, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormSelectPorts
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 359);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearPorts);
            this.Controls.Add(this.btnResumePort);
            this.Controls.Add(this.btnRemovePort);
            this.Controls.Add(this.lboxRemovedPorts);
            this.Controls.Add(this.lboxSelectedPorts);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormSelectPorts";
            this.Text = "COMOwnerSpy - Init Ports";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInitPorts_FormClosing);
            this.Load += new System.EventHandler(this.FormInitPorts_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;

    }
}