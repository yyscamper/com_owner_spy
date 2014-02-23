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
    public enum InputOwnerTranslateMode : int
    {
        Add = 0,
        Edit = 1
    }

    public partial class FormInputOwnerTranslateItem : Form
    {
        private InputOwnerTranslateMode _mode = InputOwnerTranslateMode.Add;
        private IInputOwnerTranslate _listen = null;

        public FormInputOwnerTranslateItem(InputOwnerTranslateMode mode, IInputOwnerTranslate listen, OwnerEntry owner)
        {
            InitializeComponent();
            
            if (mode == InputOwnerTranslateMode.Add)
            {
                this.Text = "Add New Owner Translate";
                this.Icon = Properties.Resources.add_icon;
            }
            else
            {
                this.Text = "Edit Owner Translate";
                tboxDomainUser.Text = owner.DomainUser;
                tboxOwnerFullName.Text = owner.FullName;
                tboxOwnerPhone.Text = owner.Phone;
                tboxOwnerShortName.Text = owner.ShortName;
                this.Icon = Properties.Resources.edit_icon;
            }
            _mode = mode;
            _listen = listen;
        }

        private void FormInputOwnerTranslateItem_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string domainUser = tboxDomainUser.Text.Trim();
            if (!OwnerEntry.VerifyDomainUser(domainUser))
            {
                yMessageBox.ShowError(this, "Your input Domain\\User is not correct!", "Error Domain\\User");
                return;
            }

            if (OwnerTranslate.Contains(domainUser))
            {
                yMessageBox.ShowError(this, "Your input Domain\\User has existed! Please input different one.");
                return;
            }

            string fullName = tboxOwnerFullName.Text.Trim();
            if (fullName.Length == 0)
            {
                yMessageBox.ShowError(this, "The full name fields should not be empty!");
                return;
            } 
            
            string shortName = tboxOwnerShortName.Text.Trim();
            if (shortName.Length == 0)
            {
                yMessageBox.ShowError(this, "The shot name fields should not be empty!");
                return;
            }

            string phone = tboxOwnerPhone.Text.Trim();
            if (phone.Length == 0)
            {
                yMessageBox.ShowError(this, "The phone fields should not be empty!");
                return;
            }

            OwnerEntry entry = new OwnerEntry(domainUser);
            entry.FullName = fullName;
            entry.ShortName = shortName;
            entry.Phone = phone;

            if (_listen != null)
                _listen.OnInputOwnerTranslateCompleted(_mode, entry);

            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tboxOwnerFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tboxOwnerPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void tboxDomainUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void tboxOwnerShortName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
