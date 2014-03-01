using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    public partial class yMessageBox : Form
    {
        static Font regularFont = new Font("Microsoft Yahei", 10.0f, FontStyle.Regular);
        static Font highlightFont = new Font("Microsoft Yahei", 11.0f, FontStyle.Bold);

        private MessageBoxButtons _btnType = MessageBoxButtons.OK;

        private yMessageBox(
                Control parent = null,
                string msg = "",
                string title = "MessageBox",
                MessageBoxButtons btns = MessageBoxButtons.OK,
                MessageBoxIcon icon = MessageBoxIcon.None)
        {
            InitializeComponent();

            richBoxMessage.BorderStyle = BorderStyle.None;

            this.Text = title;
            this.richBoxMessage.Text = msg;
            //this.TopLevel = false;
            //this.Parent = parent;
            this.StartPosition = FormStartPosition.CenterParent;

            _btnType = btns;
            if (btns == MessageBoxButtons.OK)
            {
                btn1.Text = "OK";
                btn2.Visible = false;
                btn2.Enabled = false;
            }
            else if (btns == MessageBoxButtons.YesNo)
            {
                btn1.Text = "No";
                btn2.Text = "Yes";
                btn1.Visible = btn2.Visible = true;
                btn1.Enabled = btn2.Enabled = true;
            }
            else if (btns == MessageBoxButtons.OKCancel)
            {
                btn1.Text = "Cancle";
                btn2.Text = "OK";
                btn1.Visible = btn2.Visible = true;
                btn1.Enabled = btn2.Enabled = true;
            }
            else
            {
                throw new ArgumentException("Invalid MessageBoxButtons \"" + btns.ToString() + "\"");
            }

            picBox.SizeMode = PictureBoxSizeMode.StretchImage;

            if (icon == MessageBoxIcon.Error)
            {
                picBox.Image = Properties.Resources.error;
            }
            else if (icon == MessageBoxIcon.Question)
            {
                picBox.Image = Properties.Resources.confirm;
            }
            else if (icon == MessageBoxIcon.Information)
            {
                picBox.Image = Properties.Resources.info;
            }
            else
            {
                picBox.Visible = false;
            }

        }

        private void yMessageBox_Load(object sender, EventArgs e)
        {

        }

        public static DialogResult Show(
                Control parent = null,
                string msg = "",
                string title = "MessageBox",
                MessageBoxButtons btns = MessageBoxButtons.OK,
                MessageBoxIcon icon = MessageBoxIcon.None
            )
        {
            return new yMessageBox(parent, msg, title, btns, icon).ShowDialog();
        }

        public static DialogResult ShowError(
               Control parent = null,
               string msg = "",
               string title = "Error",
               MessageBoxButtons btns = MessageBoxButtons.OK,
               MessageBoxIcon icon = MessageBoxIcon.Error
           )
        {
            return new yMessageBox(parent, msg, title, btns, icon).ShowDialog();
        }

        public static DialogResult ShowInfo(
               Control parent = null,
               string msg = "",
               string title = "Information",
               MessageBoxButtons btns = MessageBoxButtons.OK,
               MessageBoxIcon icon = MessageBoxIcon.Information
           )
        {
            return new yMessageBox(parent, msg, title, btns, icon).ShowDialog();
        }

        public static DialogResult ShowConfirm(
               Control parent = null,
               string msg = "",
               string title = "Confirm",
               MessageBoxButtons btns = MessageBoxButtons.YesNo,
               MessageBoxIcon icon = MessageBoxIcon.Question
           )
        {
            return new yMessageBox(parent, msg, title, btns, icon).ShowDialog();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (_btnType == MessageBoxButtons.YesNo)
                this.DialogResult = DialogResult.No;
            else if (_btnType == MessageBoxButtons.OKCancel)
                this.DialogResult = DialogResult.Cancel;
            else if (_btnType == MessageBoxButtons.OK)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.None;

            this.Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (_btnType == MessageBoxButtons.YesNo)
                this.DialogResult = DialogResult.Yes;
            else if (_btnType == MessageBoxButtons.OKCancel)
                this.DialogResult = DialogResult.OK;
            else if (_btnType == MessageBoxButtons.OK)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.None;

            this.Close();
        }

        private void yMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void yMessageBox_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        public RichTextBox RichInputControl
        {
            get { return richBoxMessage; }
        }

        public static DialogResult ShowKillProcConfirm(
               int procCount,
               Control parent = null,
               string title = "Confirm",
               MessageBoxButtons btns = MessageBoxButtons.YesNo,
               MessageBoxIcon icon = MessageBoxIcon.Question
           )
        {
            yMessageBox msgBox = new yMessageBox(parent, string.Empty, title, btns, icon);
            msgBox.RichInputControl.ForeColor = Color.Red;
            if (procCount > 1)
            {
                msgBox.RichInputControl.Text = ("Are you sure want to KILL your selected processes?"
                    + System.Environment.NewLine
                    + "All COM ports that opened by the processes will be closed!");
            }
            else
            {
                msgBox.RichInputControl.Text = ("Are you sure want to KILL your selected process?" + System.Environment.NewLine
                    + "All COM ports that opened by the process will be closed!");
            }

            /*msgBox.RichInputControl.SelectionColor = Color.Black;
            msgBox.RichInputControl.SelectionFont = regularFont;
            msgBox.RichInputControl.AppendText("Are you sure want to ");

            msgBox.RichInputControl.SelectionColor = Color.Red;
            msgBox.RichInputControl.SelectionFont = highlightFont;
            msgBox.RichInputControl.AppendText("KILL");

            msgBox.RichInputControl.SelectionColor = Color.Black;
            msgBox.RichInputControl.SelectionFont = regularFont;
            msgBox.RichInputControl.AppendText(" your selected process");

            if (procCount > 1)
            {
                msgBox.RichInputControl.AppendText("es");
            }
            msgBox.RichInputControl.AppendText("?");
            */
            return msgBox.ShowDialog();
        }
    }
}
