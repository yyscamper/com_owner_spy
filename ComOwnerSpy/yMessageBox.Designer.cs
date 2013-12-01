namespace ComOwnerSpy
{
    partial class yMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yMessageBox));
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.richBoxMessage = new System.Windows.Forms.RichTextBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn1.Location = new System.Drawing.Point(378, 121);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(81, 34);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "NO";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn2.Location = new System.Drawing.Point(291, 121);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(81, 34);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "YES";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // richBoxMessage
            // 
            this.richBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richBoxMessage.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richBoxMessage.Location = new System.Drawing.Point(85, 12);
            this.richBoxMessage.Name = "richBoxMessage";
            this.richBoxMessage.ReadOnly = true;
            this.richBoxMessage.Size = new System.Drawing.Size(374, 100);
            this.richBoxMessage.TabIndex = 2;
            this.richBoxMessage.Text = "";
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(9, 14);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(64, 64);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // yMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 164);
            this.Controls.Add(this.richBoxMessage);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "yMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.yMessageBox_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.yMessageBox_FormClosed);
            this.Load += new System.EventHandler(this.yMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.RichTextBox richBoxMessage;
    }
}