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
    public partial class FormSetting : Form, IInputOwnerTranslate
    {       
        private IGeneralEvent m_generalEventHandle = null;
        private OwnerEntry m_selectedOwner = null;
 
        //private bool m_hasDoneSave = false;

        #region form_action

        public FormSetting(IGeneralEvent eventHandle)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Icon = Properties.Resources.setting_icon;

            InitTabGeneral();
            InitTabComPort();
            InitTabPatterns();
            InitTabAbout();
            InitTabDeviceNameFileMap();
            InitTabOwnerTranslate();
            InitTabPageTheme();

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
            this.upDownRefreshInterval.ValueChanged += new System.EventHandler(this.upDownRefreshInterval_ValueChanged);
        }

        #endregion

        #region tabCOMPorts

        private void InitTabComPort()
        {
        }

        #region tabPatterns

        private void InitTabPatterns()
        {
            foreach (string s in ComPortControlTable.DeviceNamePatterns)
            {
                lboxPatterns.Items.Add(s);
            }
        }

        private void SaveTabSuspectProc()
        {
            return;
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
            ComPortItem[] allItems = ComPortControlTable.AllItems;
            if (allItems == null || allItems.Length == 0)
                return;

            ListViewItem[] lvis = new ListViewItem[allItems.Length];
            int i = 0;
            foreach (ComPortItem item in allItems)
            {
                lvis[i++] = new ListViewItem(new string[] { item.PortName, item.DeviceName }, item.PortName);
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
            RefreshTabOwnerTranslate();
            picBoxDeleteOwner.Enabled = false;
            picBoxEditOwner.Enabled = false;
            picboxAddOwner.Enabled = true;
        }

        private void RefreshTabOwnerTranslate()
        {
            SortedDictionary<string, OwnerEntry> allOwners = OwnerTranslate.AllOwners;
            listViewOwnerTranslate.Items.Clear();
            foreach (OwnerEntry owner in allOwners.Values)
            {
                ListViewItem litem = new ListViewItem(new string[] { owner.Key, owner.FullName, owner.ShortName, owner.Phone });
                listViewOwnerTranslate.Items.Add(litem);
            }
        }

        private void listViewOwnerTranslate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOwnerTranslate.SelectedItems.Count <= 0)
            {
                picBoxDeleteOwner.Enabled = false;
                picBoxEditOwner.Enabled = false;
                return;
            }

            picBoxDeleteOwner.Enabled = true;
            picBoxEditOwner.Enabled = true;
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
            FormInputOwnerTranslateItem inputTranslateItem = 
                new FormInputOwnerTranslateItem(InputOwnerTranslateMode.Add, this, null);
            inputTranslateItem.ShowDialog();
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
            //m_hasDoneSave = true;
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

        private void EditOwnerTranslate()
        {
            if (listViewOwnerTranslate.SelectedItems.Count <= 0)
                return;

            string key = listViewOwnerTranslate.SelectedItems[0].SubItems[0].Text;
            OwnerEntry own = OwnerTranslate.Get(key);
            m_selectedOwner = own;

            FormInputOwnerTranslateItem formInputTranslate =
                new FormInputOwnerTranslateItem(InputOwnerTranslateMode.Edit, this, own);
            formInputTranslate.ShowDialog();
            m_selectedOwner = null;
        }

        private void listViewOwnerTranslate_DoubleClick(object sender, EventArgs e)
        {
            EditOwnerTranslate();
        }

        public void OnInputOwnerTranslateCompleted(InputOwnerTranslateMode mode, OwnerEntry owner)
        {
            if (mode == InputOwnerTranslateMode.Add)
            {
                OwnerTranslate.Add(owner);
                RefreshTabOwnerTranslate();
                SelectOwnerTranslateVisuable(owner.DomainUser);
            }
            else
            {
                if (m_selectedOwner != null)
                {
                    OwnerTranslate.Remove(m_selectedOwner.DomainUser);
                    OwnerTranslate.Add(owner);
                    RefreshTabOwnerTranslate();
                    SelectOwnerTranslateVisuable(owner.DomainUser);
                }
            }
        }

        private void picboxAddOwner_Click(object sender, EventArgs e)
        {
            FormInputOwnerTranslateItem inputTranslateItem =
                new FormInputOwnerTranslateItem(InputOwnerTranslateMode.Add, this, null);
            inputTranslateItem.ShowDialog();
        }

        private void picBoxDeleteOwner_Click(object sender, EventArgs e)
        {
            DeleteOwnerTranslate();
        }

        private void picBoxEditOwner_Click(object sender, EventArgs e)
        {
            EditOwnerTranslate();
        }

        private void picBoxEditOwner_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            pbox.BorderStyle = BorderStyle.Fixed3D;
        }

        private void picBoxEditOwner_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            pbox.BorderStyle = BorderStyle.None;
        }

        private void picBoxEditOwner_EnabledChanged(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            if (pbox == picboxAddOwner)
                pbox.Image = pbox.Enabled ? Properties.Resources.add_enabled : Properties.Resources.add_disabled;
            else if (pbox == picBoxDeleteOwner)
                pbox.Image = pbox.Enabled ? Properties.Resources.delete_enabled : Properties.Resources.delete_disabled;
            else if (pbox == picBoxEditOwner)
                pbox.Image = pbox.Enabled ? Properties.Resources.edit_enabled : Properties.Resources.edit_disabled;
        }

        private void picboxAddOwner_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            pbox.BorderStyle = BorderStyle.None;
        }

        private void ColorInfoChange()
        {
             tboxColorInfo.Text = string.Format("RBG: A=[{0:D},{1:D},{2:D}], B=[{0:D},{1:D},{2:D}], C=[{3:D},{4:D},{5:D}], D=[{6:D},{7:D},{8:D}], E=[{9:D},{10:D},{11:D}]",
                    previewPanelA.BackColor.R, previewPanelA.BackColor.G, previewPanelA.BackColor.B,
                    previewPanelB.BackColor.R, previewPanelB.BackColor.G, previewPanelB.BackColor.B,
                    previewPanelC.BackColor.R, previewPanelC.BackColor.G, previewPanelC.BackColor.B,
                    previewPanelD.BackColor.R, previewPanelD.BackColor.G, previewPanelD.BackColor.B,
                    previewPanelE.BackColor.R, previewPanelE.BackColor.G, previewPanelE.BackColor.B
                    );
        }

        private void ChangeFontColor(Color color)
        {
            btnSelectColorFont.BackColor = color;
            labelPanelA.ForeColor = color;
            labelPanelB.ForeColor = color;
            labelPanelC.ForeColor = color;
            labelPanelD.ForeColor = color;
            labelPanelE.ForeColor = color;
        }

        private void ChangeBackColor(Color color)
        {
            btnSelectBackColor.BackColor = color;
            panelBackground.BackColor = color;
        }

        private void ChangeTheme(Theme t)
        {
            if (t != null)
            {
                btnSelectColorPanelA.BackColor =
                   previewPanelA.BackColor = t.ColorA;

                btnSelectColorPanelB.BackColor =
                    previewPanelB.BackColor = t.ColorB;

                btnSelectColorPanelC.BackColor =
                    previewPanelC.BackColor = t.ColorC;

                btnSelectColorPanelD.BackColor =
                    previewPanelD.BackColor = t.ColorD;

                btnSelectColorPanelE.BackColor =
                   previewPanelE.BackColor = t.ColorE;

                ChangeFontColor(t.FontColor);
                ChangeBackColor(t.BackColor);
                ColorInfoChange();
            }
        }


        private void InitTabPageTheme()
        {
            comboxThemeList.Items.Clear();
            comboxThemeList.Items.AddRange(ThemeManager.GetAllThemeNames());
            comboxThemeList.Text = ThemeManager.CurrentTheme.Name;
            ChangeTheme(ThemeManager.CurrentTheme);

            btnSelectColorPanelA.Tag = previewPanelA;
            btnSelectColorPanelB.Tag = previewPanelB;
            btnSelectColorPanelC.Tag = previewPanelC;
            btnSelectColorPanelD.Tag = previewPanelD;
            btnSelectColorPanelE.Tag = previewPanelE;

            previewPanelA.Tag = btnSelectColorPanelA;
            previewPanelB.Tag = btnSelectColorPanelB;
            previewPanelC.Tag = btnSelectColorPanelC;
            previewPanelD.Tag = btnSelectColorPanelD;
            previewPanelE.Tag = btnSelectColorPanelE;
        }

        private void btnSelectColorPanelA_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = c.BackColor;
            if (DialogResult.OK == cd.ShowDialog())
            {
                c.BackColor = cd.Color;
                ((Control)(c.Tag)).BackColor = cd.Color;
                ColorInfoChange();
            }
        }

      
        private void comboxThemeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Theme theme = ThemeManager.GetTheme(comboxThemeList.Text);
            ChangeTheme(theme);
            if (m_generalEventHandle != null)
                m_generalEventHandle.OnNotifyChangeTheme(theme);
        }

        private Theme CreateTheme(string name = null)
        {
            Theme theme = new Theme(null);
            theme.ColorA = previewPanelA.BackColor;
            theme.ColorB = previewPanelB.BackColor;
            theme.ColorC = previewPanelC.BackColor;
            theme.ColorD = previewPanelD.BackColor;
            theme.ColorE = previewPanelE.BackColor;
            theme.FontColor = btnSelectColorFont.BackColor;
            theme.BackColor = btnSelectBackColor.BackColor;
            return theme;
        }

        private Theme SaveTheme()
        {
            StringContainer strContainer = new StringContainer();
            DialogResult result = new InputDialog().ShowDialog("Please type the theme name:", strContainer);
            if (result != DialogResult.OK)
                return null;

            Theme theme = CreateTheme(strContainer.Value);
            ThemeManager.AddTheme(theme);

            comboxThemeList.Items.Clear();
            comboxThemeList.Items.AddRange(ThemeManager.GetAllThemeNames());

            return theme;
        }

        private void btnSaveTheme_Click(object sender, EventArgs e)
        {
            SaveTheme();
        }

        private void btnSaveApplyTheme_Click(object sender, EventArgs e)
        {
            Theme t = SaveTheme();
            if (t != null)
            {
                ChangeTheme(t);
                if (m_generalEventHandle != null)
                    m_generalEventHandle.OnNotifyChangeTheme(t);
            }
        }

        private void btnSelectColorFont_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = c.BackColor;
            if (DialogResult.OK == cd.ShowDialog())
            {
                c.BackColor = cd.Color;
                ChangeFontColor(cd.Color);
            }
        }

        private void btnSelectBackColor_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = c.BackColor;
            if (DialogResult.OK == cd.ShowDialog())
            {
                ChangeBackColor(cd.Color);
            }
        }

        private void btnApplyTheme_Click(object sender, EventArgs e)
        {
            Theme theme = CreateTheme(null);
            if (m_generalEventHandle != null)
                m_generalEventHandle.OnNotifyChangeTheme(theme);
        }
    }
}

#endregion