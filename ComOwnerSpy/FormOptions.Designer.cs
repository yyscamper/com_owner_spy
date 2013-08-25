namespace ComOwnerSpy
{
    partial class FormOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.lboxSuspectProcNames = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tboxInputProcName = new System.Windows.Forms.TextBox();
            this.btnAddProcName = new System.Windows.Forms.Button();
            this.btnRemoveProcName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lboxSuspectProcNames
            // 
            this.lboxSuspectProcNames.FormattingEnabled = true;
            this.lboxSuspectProcNames.ItemHeight = 17;
            this.lboxSuspectProcNames.Location = new System.Drawing.Point(12, 83);
            this.lboxSuspectProcNames.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lboxSuspectProcNames.Name = "lboxSuspectProcNames";
            this.lboxSuspectProcNames.Size = new System.Drawing.Size(337, 208);
            this.lboxSuspectProcNames.TabIndex = 0;
            this.lboxSuspectProcNames.SelectedIndexChanged += new System.EventHandler(this.lboxSuspectProcNames_SelectedIndexChanged);
            this.lboxSuspectProcNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lboxSuspectProcNames_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "The process name may open the COM port:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(288, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tboxInputProcName
            // 
            this.tboxInputProcName.Location = new System.Drawing.Point(12, 43);
            this.tboxInputProcName.Name = "tboxInputProcName";
            this.tboxInputProcName.Size = new System.Drawing.Size(126, 23);
            this.tboxInputProcName.TabIndex = 1;
            // 
            // btnAddProcName
            // 
            this.btnAddProcName.Location = new System.Drawing.Point(144, 43);
            this.btnAddProcName.Name = "btnAddProcName";
            this.btnAddProcName.Size = new System.Drawing.Size(42, 33);
            this.btnAddProcName.TabIndex = 2;
            this.btnAddProcName.Text = "ADD";
            this.btnAddProcName.UseVisualStyleBackColor = true;
            this.btnAddProcName.Click += new System.EventHandler(this.btnAddProcName_Click);
            // 
            // btnRemoveProcName
            // 
            this.btnRemoveProcName.Location = new System.Drawing.Point(306, 43);
            this.btnRemoveProcName.Name = "btnRemoveProcName";
            this.btnRemoveProcName.Size = new System.Drawing.Size(43, 33);
            this.btnRemoveProcName.TabIndex = 3;
            this.btnRemoveProcName.Text = "DEL";
            this.btnRemoveProcName.UseVisualStyleBackColor = true;
            this.btnRemoveProcName.Click += new System.EventHandler(this.btnRemoveProcName_Click);
            // 
            // FormOptions
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 339);
            this.Controls.Add(this.btnRemoveProcName);
            this.Controls.Add(this.btnAddProcName);
            this.Controls.Add(this.tboxInputProcName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lboxSuspectProcNames);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormOptions";
            this.Text = "COMOwnerSpy - Options";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboxSuspectProcNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tboxInputProcName;
        private System.Windows.Forms.Button btnAddProcName;
        private System.Windows.Forms.Button btnRemoveProcName;
    }
}