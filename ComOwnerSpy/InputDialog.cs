using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    public partial class InputDialog : Form
    {
        StringContainer _strContainer = null;

        public InputDialog()
        {
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {

        }

        public DialogResult ShowDialog(string title, StringContainer strCon)
        {
            this.Text = title;
            this.StartPosition = FormStartPosition.CenterParent;
            _strContainer = strCon;
            return ShowDialog();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            _strContainer.Value = tboxInput.Text.Trim();
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            _strContainer.Value = string.Empty;
            this.Close();
        }
    }
}
