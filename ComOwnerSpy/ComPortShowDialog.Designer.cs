namespace ComOwnerSpy
{
    partial class ComPortShowDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComPortShowDialog));
            this.labelOwnerName = new System.Windows.Forms.Label();
            this.labelSelectPortName = new System.Windows.Forms.Label();
            this.panelUp = new System.Windows.Forms.Panel();
            this.panelDown = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewAllOwnProcs = new System.Windows.Forms.ListView();
            this.colPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAppName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpenedPorts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picBoxKill = new System.Windows.Forms.PictureBox();
            this.panelUp.SuspendLayout();
            this.panelDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxKill)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOwnerName
            // 
            this.labelOwnerName.AutoSize = true;
            this.labelOwnerName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOwnerName.Location = new System.Drawing.Point(7, 47);
            this.labelOwnerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOwnerName.Name = "labelOwnerName";
            this.labelOwnerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelOwnerName.Size = new System.Drawing.Size(114, 21);
            this.labelOwnerName.TabIndex = 0;
            this.labelOwnerName.Text = "Owner_Name";
            this.labelOwnerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSelectPortName
            // 
            this.labelSelectPortName.AutoSize = true;
            this.labelSelectPortName.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSelectPortName.Location = new System.Drawing.Point(4, 4);
            this.labelSelectPortName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectPortName.Name = "labelSelectPortName";
            this.labelSelectPortName.Size = new System.Drawing.Size(145, 39);
            this.labelSelectPortName.TabIndex = 0;
            this.labelSelectPortName.Text = "COM100";
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.SkyBlue;
            this.panelUp.Controls.Add(this.labelSelectPortName);
            this.panelUp.Controls.Add(this.labelOwnerName);
            this.panelUp.Location = new System.Drawing.Point(7, 6);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(342, 77);
            this.panelUp.TabIndex = 1;
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.label1);
            this.panelDown.Controls.Add(this.listViewAllOwnProcs);
            this.panelDown.Location = new System.Drawing.Point(8, 89);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(433, 228);
            this.panelDown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "All Owner\'s Processes:";
            // 
            // listViewAllOwnProcs
            // 
            this.listViewAllOwnProcs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewAllOwnProcs.CheckBoxes = true;
            this.listViewAllOwnProcs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPID,
            this.colAppName,
            this.colOpenedPorts});
            this.listViewAllOwnProcs.FullRowSelect = true;
            this.listViewAllOwnProcs.GridLines = true;
            this.listViewAllOwnProcs.Location = new System.Drawing.Point(0, 30);
            this.listViewAllOwnProcs.Name = "listViewAllOwnProcs";
            this.listViewAllOwnProcs.Size = new System.Drawing.Size(433, 198);
            this.listViewAllOwnProcs.TabIndex = 3;
            this.listViewAllOwnProcs.UseCompatibleStateImageBehavior = false;
            this.listViewAllOwnProcs.View = System.Windows.Forms.View.Details;
            this.listViewAllOwnProcs.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewAllOwnProcs_ItemCheck);
            this.listViewAllOwnProcs.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewAllOwnProcs_ItemChecked);
            this.listViewAllOwnProcs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewAllOwnProcs_KeyDown);
            // 
            // colPID
            // 
            this.colPID.Text = "PID";
            this.colPID.Width = 70;
            // 
            // colAppName
            // 
            this.colAppName.Text = "App Name";
            this.colAppName.Width = 120;
            // 
            // colOpenedPorts
            // 
            this.colOpenedPorts.Text = "Opened Ports";
            this.colOpenedPorts.Width = 238;
            // 
            // picBoxKill
            // 
            this.picBoxKill.Image = global::ComOwnerSpy.Properties.Resources.kill_enabled;
            this.picBoxKill.Location = new System.Drawing.Point(355, 6);
            this.picBoxKill.Name = "picBoxKill";
            this.picBoxKill.Size = new System.Drawing.Size(86, 77);
            this.picBoxKill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxKill.TabIndex = 5;
            this.picBoxKill.TabStop = false;
            this.picBoxKill.Click += new System.EventHandler(this.picBoxKill_Click);
            this.picBoxKill.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxKill_MouseDown);
            this.picBoxKill.MouseLeave += new System.EventHandler(this.picBoxKill_MouseLeave);
            this.picBoxKill.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBoxKill_MouseUp);
            // 
            // ComPortShowDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 323);
            this.Controls.Add(this.picBoxKill);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComPortShowDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kill Process";
            this.Load += new System.EventHandler(this.ComPortShowDialog_Load);
            this.panelUp.ResumeLayout(false);
            this.panelUp.PerformLayout();
            this.panelDown.ResumeLayout(false);
            this.panelDown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxKill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelOwnerName;
        private System.Windows.Forms.Label labelSelectPortName;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.ListView listViewAllOwnProcs;
        private System.Windows.Forms.ColumnHeader colPID;
        private System.Windows.Forms.ColumnHeader colAppName;
        private System.Windows.Forms.ColumnHeader colOpenedPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBoxKill;
    }
}