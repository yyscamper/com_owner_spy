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
    public partial  class yMessageBox : Form
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

        public static DialogResult Show (
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

        public static DialogResult ShowKillProcConfirm(
               ComPortItem item,
               List<ComPortItem> otherPortsInProcess,
               Control parent = null,
               string title = "Confirm",
               MessageBoxButtons btns = MessageBoxButtons.YesNo,
               MessageBoxIcon icon = MessageBoxIcon.Question
           )
        {
            yMessageBox msgBox = new yMessageBox(parent, string.Empty, title, btns, icon);

            if (otherPortsInProcess == null || otherPortsInProcess.Count == 0)
            {
                msgBox.richBoxMessage.SelectionColor = Color.Black;
                msgBox.richBoxMessage.SelectionFont = regularFont;
                msgBox.richBoxMessage.AppendText("Are you sure want to ");

                msgBox.richBoxMessage.SelectionColor = Color.Red;
                msgBox.richBoxMessage.SelectionFont = highlightFont;
                msgBox.richBoxMessage.AppendText("KILL");

                msgBox.richBoxMessage.SelectionColor = Color.Black;
                msgBox.richBoxMessage.SelectionFont = regularFont;
                msgBox.richBoxMessage.AppendText(" the port ");

                msgBox.richBoxMessage.SelectionColor = Color.Red;
                msgBox.richBoxMessage.SelectionFont = highlightFont;
                msgBox.richBoxMessage.AppendText(item.PortName);

                msgBox.richBoxMessage.SelectionColor = Color.Black;
                msgBox.richBoxMessage.SelectionFont = regularFont;
                msgBox.richBoxMessage.AppendText("?");
            }
            else
            {
                msgBox.richBoxMessage.SelectionColor = Color.Black;
                msgBox.richBoxMessage.SelectionFont = regularFont;
                msgBox.richBoxMessage.AppendText("Are you sure want to ");

                msgBox.richBoxMessage.SelectionColor = Color.Red;
                msgBox.richBoxMessage.SelectionFont = highlightFont;
                msgBox.richBoxMessage.AppendText("KILL");

                msgBox.richBoxMessage.SelectionColor = Color.Black;
                msgBox.richBoxMessage.SelectionFont = regularFont;
                msgBox.richBoxMessage.AppendText(" the port ");

                msgBox.richBoxMessage.SelectionColor = Color.Red;
                msgBox.richBoxMessage.SelectionFont = highlightFont;
                msgBox.richBoxMessage.AppendText(item.PortName);

                msgBox.richBoxMessage.SelectionColor = Color.Black;
                msgBox.richBoxMessage.SelectionFont = regularFont;
                msgBox.richBoxMessage.AppendText("?" + System.Environment.NewLine);
                msgBox.richBoxMessage.AppendText("The following port" + (otherPortsInProcess.Count > 1 ? "s" : string.Empty) + " will also be ");

                msgBox.richBoxMessage.SelectionColor = Color.Red;
                msgBox.richBoxMessage.SelectionFont = highlightFont;
                msgBox.richBoxMessage.AppendText("KILLED");

                msgBox.richBoxMessage.SelectionColor = Color.Black;
                msgBox.richBoxMessage.SelectionFont = regularFont;
                msgBox.richBoxMessage.AppendText(" as they are opened in the same process:"
                    + System.Environment.NewLine);


                msgBox.richBoxMessage.SelectionFont = highlightFont;
                for (int i = 0; i < otherPortsInProcess.Count; i++ )
                {
                    msgBox.richBoxMessage.SelectionColor = Color.Red;
                    msgBox.richBoxMessage.AppendText(((ComPortItem)otherPortsInProcess[i]).PortName);

                    msgBox.richBoxMessage.SelectionColor = Color.Black;
                    if (i != otherPortsInProcess.Count - 1)
                    {
                        msgBox.richBoxMessage.AppendText(",");
                    }
                    else
                    {
                        msgBox.richBoxMessage.AppendText("!");
                    }
                }
            }

            return msgBox.ShowDialog();
        }
    }
}
