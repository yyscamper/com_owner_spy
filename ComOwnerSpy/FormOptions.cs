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
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            lboxSuspectProcNames.Items.AddRange(AppConfig.AllSuspectProcessNames);
        }

        private void btnAddProcName_Click(object sender, EventArgs e)
        {
            string name = tboxInputProcName.Text.Trim();
            if (name.Length <= 0)
                return;

            if (!lboxSuspectProcNames.Items.Contains(name))
            {
                lboxSuspectProcNames.Items.Add(name);
            }
            else
            {
                MessageBox.Show(this, "The \"" + name + "\"has already be contained.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tboxInputProcName.Text = string.Empty;

        }

        private void DoRemoveProcName()
        {
            int idx = lboxSuspectProcNames.SelectedIndex;
            if (idx < 0)
                return;
            if (DialogResult.Yes == MessageBox.Show(this, "Are you sure want to delete \"" + lboxSuspectProcNames.Items[idx].ToString() + "\"?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                lboxSuspectProcNames.Items.RemoveAt(idx);
            }
        }

        private void btnRemoveProcName_Click(object sender, EventArgs e)
        {
            DoRemoveProcName();
        }

        private void lboxSuspectProcNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveProcName.Enabled = (lboxSuspectProcNames.SelectedIndex >= 0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] arr = new string[lboxSuspectProcNames.Items.Count];
            lboxSuspectProcNames.Items.CopyTo(arr, 0);
            AppConfig.AllSuspectProcessNames = arr;
            AppConfig.SaveGlobalConfig();
            this.Close();
        }

        private void lboxSuspectProcNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DoRemoveProcName();
            }
        }
    }
}
