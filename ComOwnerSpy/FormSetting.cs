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
    public partial class FormSetting : Form
    {       
        private SortedSet<uint> m_selectedPorts = new SortedSet<uint>();
        private SortedSet<uint> m_removedPorts = new SortedSet<uint>();
        private IGeneralEvent m_generalEventHandle = null;
        private bool m_hasDoneSave = false;

        #region form_action

        public FormSetting(IGeneralEvent eventHandle)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            InitTabGeneral();
            InitTabComPort();
            InitTabSuspectProc();
            InitTabAbout();
            InitTabDeviceNameFileMap();
            InitTabOwnerTranslate();

            m_generalEventHandle = eventHandle;
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region tabGeneral

        private void InitTabGeneral()
        {
            comboBoxRowHeight.Items.Clear();
            for (uint val = 10; val <= 48; val++)
            {
                comboBoxRowHeight.Items.Add(val.ToString());
            }
            comboBoxRowHeight.Text = AppConfig.RowHeight.ToString();

            upDownRefreshInterval.Minimum = 1;
            upDownRefreshInterval.Maximum = 300;
            upDownRefreshInterval.Value = AppConfig.AutoRefreshInterval;
            cboxEnableAutoRefreshAtStartup.Checked = AppConfig.EnableAutoRefreshAtStartup;
            upDownRefreshInterval.Enabled = cboxEnableAutoRefreshAtStartup.Checked;
            comboxBoxOwnerShowFormat.SelectedIndex = (int)AppConfig.OwnerFormat;
        }

        #endregion

        #region tabCOMPorts

        private void InitTabComPort()
        {
            m_selectedPorts.Clear();
            m_removedPorts.Clear();

            string[] allports = ComHandle.GetAllPorts();
            foreach (string p in allports)
            {
                m_selectedPorts.Add(uint.Parse(p));
            }
        }

        #region tabSuspectProcs

        private void InitTabSuspectProc()
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

        private void DoRemoveProcNameOrPattern(ListBox lbox)
        {
            int idx = lbox.SelectedIndex;
            if (idx < 0)
                return;
            if (DialogResult.Yes == MessageBox.Show(this, "Are you sure want to delete process name \"" + lbox.Items[idx].ToString() + "\"?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                lbox.Items.RemoveAt(idx);
            }
        }

        private void SaveTabSuspectProc()
        {
            string[] arr = new string[lboxSuspectProcNames.Items.Count];
            lboxSuspectProcNames.Items.CopyTo(arr, 0);
            AppConfig.AllSuspectProcessNames = arr;

            AppConfig.SaveGlobalConfig();
        }

        private void lboxSuspectProcNamesOrPatterns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DoRemoveProcNameOrPattern((ListBox)sender);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoRemoveProcNameOrPattern(lboxSuspectProcNames);
        }

        #endregion

        #region tabAbout

        private void InitTabAbout()
        {
            Version ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            labelVersion.Text = "v" + ver.Major + "." + ver.Minor;
        }

        #endregion

        #region tabMapFileTable

        private void RefreshDevieNameMapTable()
        {
            Dictionary<string, string> rawTable = DeviceMapTable.RawTable;
            if (rawTable == null || rawTable.Count == 0)
                return;

            ListViewItem[] lvis = new ListViewItem[rawTable.Keys.Count];
            int i = 0;
            foreach (string port in rawTable.Keys)
            {
                string devFileName = rawTable[port];
                lvis[i++] = new ListViewItem(new string[] { port, devFileName }, port);
            }
            listViewDeviceMapTable.Items.Clear();
            listViewDeviceMapTable.Items.AddRange(lvis);
        }

        private void InitTabDeviceNameFileMap()
        {
            listViewDeviceMapTable.FullRowSelect = true;
            RefreshDevieNameMapTable();

        }

        #endregion


        #region tabOwner

        private void InitTabOwnerTranslate()
        {
            listViewOwnerTranslate.FullRowSelect = true;
            tboxDomainUser.Text = tboxOwnerFullName.Text = tboxOwnerShortName.Text = tboxOwnerPhone.Text = string.Empty;
            btnDeleteOwnerTranslate.Enabled = false;
            RefreshTabOwnerTranslate();
        }

        private void RefreshTabOwnerTranslate()
        {
            SortedDictionary<string, Owner> allOwners = OwnerTranslate.AllOwners;
            listViewOwnerTranslate.Items.Clear();
            foreach (Owner owner in allOwners.Values)
            {
                ListViewItem litem = new ListViewItem(new string[] { owner.Key, owner.FullName, owner.ShortName, owner.Phone });
                listViewOwnerTranslate.Items.Add(litem);
            }
        }

        private void listViewOwnerTranslate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOwnerTranslate.SelectedItems.Count <= 0)
            {
                btnDeleteOwnerTranslate.Enabled = false;
                return;
            }

            btnDeleteOwnerTranslate.Enabled = true;
        }
        
        private void SelectOwnerTranslateVisuable(string domainuser)
        {
            foreach (ListViewItem item in listViewOwnerTranslate.Items)
            {
                if (item.SubItems[0].Text == domainuser)
                {
                    item.Selected = true;
                    listViewOwnerTranslate.Select();
                    item.EnsureVisible();
                }
            }
        }

        private void btnAddNewOwnerTranslate_Click(object sender, EventArgs e)
        {
            string domainUser = tboxDomainUser.Text.Trim().ToLower();
            if (!Utility.ValidateDomainUser(domainUser))
            {
                yMessageBox.ShowError(this, "Your input 'Domain\\User' format is not correct, it should be like corp\\abcd or my/bcd.");
                return;
            }

            if (OwnerTranslate.Contains(domainUser))
            {
                yMessageBox.ShowConfirm(this, "Your input 'Domain\\User' has been contained! If you want to edit it, you should first delete then add a new one.");
                return;
            }

            string fullName = tboxOwnerFullName.Text.Trim();
            if (fullName.Length == 0)
            {
                yMessageBox.ShowError(this, "The 'FullName' should not be empty!");
                return;
            }

            string shortName = tboxOwnerShortName.Text.Trim();
            if (shortName.Length == 0)
            {
                yMessageBox.ShowError(this, "The 'ShortName' should not be empty!");
                return;
            }

            Owner owner = new Owner(domainUser);
            owner.FullName = fullName;
            owner.ShortName = shortName;
            owner.Phone = tboxOwnerPhone.Text.Trim();

            OwnerTranslate.Add(owner);

            RefreshTabOwnerTranslate();

            SelectOwnerTranslateVisuable(domainUser);

            tboxDomainUser.Text = tboxOwnerFullName.Text = tboxOwnerShortName.Text
                = tboxOwnerPhone.Text = string.Empty;

            tboxDomainUser.Focus();
        }

        private void DeleteOwnerTranslate()
        {
            if (listViewOwnerTranslate.SelectedItems.Count <= 0)
                return;

            if (DialogResult.No == yMessageBox.ShowConfirm(this, "Are your sure want to delete the '" + listViewOwnerTranslate.SelectedItems[0].SubItems[0].Text + "'?", "Delete Owner Translate Confirm", MessageBoxButtons.YesNo))
            {
                return;
            }
            string key = listViewOwnerTranslate.SelectedItems[0].SubItems[0].Text;
            OwnerTranslate.Remove(key);

            RefreshTabOwnerTranslate();
        }

        private void btnDeleteOwnerTranslate_Click(object sender, EventArgs e)
        {
            DeleteOwnerTranslate();
        }

        private void listViewOwnerTranslate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteOwnerTranslate();
            }
        }

        private void SaveOwnerTranslate()
        {
            OwnerTranslate.SaveToFile("config\\owner_translate.dat");
        }

        #endregion

        #region save_default_action

        private void Save()
        {
            AppConfig.EnableAutoRefreshAtStartup = cboxEnableAutoRefreshAtStartup.Enabled;
            AppConfig.AutoRefreshInterval = (int)upDownRefreshInterval.Value;
            SaveTabSuspectProc();
            SaveOwnerTranslate();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            m_hasDoneSave = true;
            this.Close();
        }

        #endregion

        private void comboBoxRowHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_generalEventHandle != null)
                m_generalEventHandle.UpdateRowHeight(int.Parse(comboBoxRowHeight.Text));
        }

        private void comboBoxOwnerShowFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.OwnerFormat = (OwnerShowFormat)comboxBoxOwnerShowFormat.SelectedIndex;
            if (m_generalEventHandle != null)
                m_generalEventHandle.UpdateOwnerFormat(AppConfig.OwnerFormat);
        }

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!m_hasDoneSave && DialogResult.No == yMessageBox.ShowConfirm(this, "Are you sure want to close? If so, all modification will be discared."))
            //{
            //    e.Cancel = true;
            //}

            Save();
        }

        private void cboxEnableAutoRefreshAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            upDownRefreshInterval.Enabled = cboxEnableAutoRefreshAtStartup.Checked;
            AppConfig.EnableAutoRefreshAtStartup = cboxEnableAutoRefreshAtStartup.Checked;
        }

        private void upDownRefreshInterval_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int val = int.Parse(upDownRefreshInterval.Value.ToString());
                AppConfig.AutoRefreshInterval = val;
            }
            catch
            {
            }
        }

        private void listViewOwnerTranslate_DoubleClick(object sender, EventArgs e)
        {
            if (listViewOwnerTranslate.SelectedItems.Count <= 0)
                return;

            string key = listViewOwnerTranslate.SelectedItems[0].SubItems[0].Text;
            Owner own = OwnerTranslate.AllOwners[key];

            tboxDomainUser.Text = own.Domain + "\\" + own.User;
            tboxOwnerFullName.Text = own.FullName;
            tboxOwnerShortName.Text = own.ShortName;
            tboxOwnerPhone.Text = own.Phone;

            RefreshTabOwnerTranslate();


        }
    }
}

#endregion