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
        private string m_originCurThemeName = null;
        //private bool m_hasDoneSave = false;

        #region form_action

        public FormSetting(IGeneralEvent eventHandle)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Icon = Properties.Resources.setting_icon;
            m_originCurThemeName = AppConfig.CurrentThemeName;

            InitTabComPort();
            InitTabPatterns();
            InitTabAbout();
            InitTabDeviceNameFileMap();
            InitTabOwnerTranslate();
            InitTabPageTheme();

            m_generalEventHandle = eventHandle;
        }

        private void SetTheme(Theme theme)
        {

        }

        private void FormSetting_Load(object sender, EventArgs e)
        {

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
            OwnerTranslate.SaveToFile();
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
        }

        #endregion

        #region save_default_action

        private void Save()
        {
            if (m_originCurThemeName != comboxThemeList.Text)
                AppConfig.SaveGlobalConfig();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            //m_hasDoneSave = true;
            this.Close();
        }

        #endregion

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
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

                OwnerTranslate.SaveToFile();
            }
            else
            {
                if (m_selectedOwner != null)
                {
                    OwnerTranslate.Remove(m_selectedOwner.DomainUser);
                    OwnerTranslate.Add(owner);
                    RefreshTabOwnerTranslate();
                    SelectOwnerTranslateVisuable(owner.DomainUser);

                    OwnerTranslate.SaveToFile();
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
            }
        }

      
        private void comboxThemeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Theme theme = ThemeManager.GetTheme(comboxThemeList.Text);
            ChangeTheme(theme);
            if (m_generalEventHandle != null)
                m_generalEventHandle.OnNotifyChangeTheme(theme);

            SetTheme(theme);
        }

        private Theme CreateTheme(string name = null)
        {
            Theme theme = new Theme(name);
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

            if (ThemeManager.Contains(strContainer.Value))
            {
                yMessageBox.ShowError(this, "Your input theme name is already existed, please type another one!", "Error");
                return null;
            }

            Theme theme = CreateTheme(strContainer.Value);
            ThemeManager.AddTheme(theme);
            ThemeManager.SaveThemeToFile();

            comboxThemeList.Items.Clear();
            comboxThemeList.Items.AddRange(ThemeManager.GetAllThemeNames());
            comboxThemeList.Text = AppConfig.CurrentThemeName;

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
            Theme theme = SaveTheme();
            if (theme == null)
                return;
            comboxThemeList.Text = theme.Name;
            comboxThemeList_SelectedIndexChanged(comboxThemeList, null);
            SetTheme(theme);
        }

        private void btnDeleteCurrentTheme_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != yMessageBox.ShowConfirm(this, "Are you sure want to remove this theme?", "Remove Theme"))
            {
                return;
            }
            ThemeManager.RemoveTheme(comboxThemeList.Text);
            ThemeManager.CurrentTheme = ThemeManager.GetDefaultTheme();

            comboxThemeList.Items.Clear();
            comboxThemeList.Items.AddRange(ThemeManager.GetAllThemeNames());

            comboxThemeList.Text = ThemeManager.CurrentTheme.Name;
        }

        private void comboxThemeList_TextChanged(object sender, EventArgs e)
        {
            comboxThemeList_SelectedIndexChanged(comboxThemeList, null);
        }
    }
}

#endregion