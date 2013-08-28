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
    public partial class FormSetting : Form, IProgressEvent
    {       
        private SortedSet<uint> m_selectedPorts = new SortedSet<uint>();
        private SortedSet<uint> m_removedPorts = new SortedSet<uint>();

        private string[] m_preSuspectProcNames = null;
        private string[] m_preSerialDeviceNamePatterns = null;

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
        }

        #endregion

        #region tabCOMPorts

        private void InitTabComPort()
        {
            nudPortStart.Minimum = 1;
            nudPortStart.Maximum = 1000;
            nudPortStart.Value = 1;
            nudPortEnd.Minimum = 1;
            nudPortEnd.Maximum = 1000;
            nudPortEnd.Value = 100;

            m_selectedPorts.Clear();
            m_removedPorts.Clear();

            string[] allports = ComHandle.GetAllPorts();
            foreach (string p in allports)
            {
                m_selectedPorts.Add(uint.Parse(p));
            }
            lboxSelectedPorts.Items.AddRange(allports);
            lboxSelectedPorts.SelectionMode = SelectionMode.MultiSimple;
            lboxRemovedPorts.SelectionMode = SelectionMode.MultiSimple;
        }

        private void RefreshRemovedPortsView()
        {
            lboxRemovedPorts.Items.Clear();
            foreach (uint i in m_removedPorts)
            {
                lboxRemovedPorts.Items.Add(i.ToString());
            }
        }

        private void RefreshSelectedPortsView()
        {
            lboxSelectedPorts.Items.Clear();
            foreach (uint i in m_selectedPorts)
            {
                lboxSelectedPorts.Items.Add(i.ToString());
            }
        }

        private void btnRemovePort_Click(object sender, EventArgs e)
        {
            int cnt = lboxSelectedPorts.SelectedIndices.Count;
            for (int i = cnt - 1; i >= 0; i--)
            {
                int idx = lboxSelectedPorts.SelectedIndices[i];
                uint port = m_selectedPorts.ElementAt(idx);
                m_removedPorts.Add(port);
                m_selectedPorts.Remove(port);
                lboxSelectedPorts.Items.RemoveAt(idx);
            }

            if (cnt > 0)
            {
                RefreshRemovedPortsView();
            }
        }

        private void btnResumePort_Click_1(object sender, EventArgs e)
        {
            int cnt = lboxRemovedPorts.SelectedIndices.Count;
            for (int i = cnt - 1; i >= 0; i--)
            {
                int idx = lboxRemovedPorts.SelectedIndices[i];
                uint port = m_removedPorts.ElementAt(idx);
                m_selectedPorts.Add(port);
                m_removedPorts.Remove(port);
                lboxRemovedPorts.Items.RemoveAt(idx);
            }

            if (cnt > 0)
            {
                RefreshSelectedPortsView();
            }
        }

        private void btnClearPorts_Click_1(object sender, EventArgs e)
        {
            m_selectedPorts.Clear();
            m_removedPorts.Clear();
            lboxSelectedPorts.Items.Clear();
            lboxRemovedPorts.Items.Clear();
        }

        private void btnPortsRangeAdd_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != yMessageBox.ShowConfirm(this,
                "Are you sure want to initialize the COM ports? The removed ports list will be cleared!",
                "Confirm Init Ports"))
            {
                return;
            }

            m_selectedPorts.Clear();
            m_removedPorts.Clear();
            lboxRemovedPorts.Items.Clear();

            for (uint i = (uint)nudPortStart.Value; i <= (uint)nudPortEnd.Value; i++)
            {
                m_selectedPorts.Add(i);
            }
            RefreshSelectedPortsView();
        }

        private void btnPortsSingleAdd_Click(object sender, EventArgs e)
        {
            uint port = 0xffffff;
            try
            {
                port = uint.Parse(tboxPortSingleAddInput.Text);
            }
            catch
            {
                yMessageBox.ShowError(this, "Invalid port number!", "Error");
                return;
            }

            if (m_selectedPorts.Contains(port))
            {
                yMessageBox.ShowInfo(this, "The port " + port + " has already in the list!", "Add Port Information");
                return;
            }

            m_selectedPorts.Add(port);
            RefreshSelectedPortsView();
        }

        private void SaveTabComPorts()
        {
            ComHandle.Clear();
            for (int i = 0; i < lboxSelectedPorts.Items.Count; i++)
            {
                ComHandle.Add(new ComItem(lboxSelectedPorts.Items[i].ToString()));
            }
            AppConfig.SaveGlobalConfig();
            ComHandle.ModifyFlag = true;
        }
        #endregion

        #region tabSuspectProcs

        private void InitTabSuspectProc()
        {
            m_preSerialDeviceNamePatterns = AppConfig.SerialDeviceNamePatterns;
            m_preSuspectProcNames = AppConfig.AllSuspectProcessNames;

            lboxSuspectProcNames.Items.AddRange(AppConfig.AllSuspectProcessNames);
            lboxSerialDeviceNamePatterns.Items.AddRange(AppConfig.SerialDeviceNamePatterns);
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
            if (DialogResult.Yes == MessageBox.Show(this, "Are you sure want to delete "
                + ((lbox == lboxSuspectProcNames) ? "process name " : (lbox == lboxSerialDeviceNamePatterns ? "pattern " : ""))
                + "\"" + lbox.Items[idx].ToString() + "\"?",
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

            string[] arrPatterns = new string[lboxSerialDeviceNamePatterns.Items.Count];
            lboxSerialDeviceNamePatterns.Items.CopyTo(arrPatterns, 0);
            AppConfig.SerialDeviceNamePatterns = arrPatterns;

            AppConfig.SaveGlobalConfig();
        }

        private void lboxSuspectProcNamesOrPatterns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DoRemoveProcNameOrPattern((ListBox)sender);
            }
        }

        private void btnAddSerialDevicePattern_Click(object sender, EventArgs e)
        {
            string name = tboxSerialDevicePattern.Text.Trim();
            if (name.Length <= 0)
                return;

            if (!lboxSerialDeviceNamePatterns.Items.Contains(name))
            {
                lboxSerialDeviceNamePatterns.Items.Add(name);
            }
            else
            {
                MessageBox.Show(this, "The pattern \"" + name + "\"has already be contained.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tboxSerialDevicePattern.Text = string.Empty;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoRemoveProcNameOrPattern((lboxSerialDeviceNamePatterns.Focused ? lboxSerialDeviceNamePatterns : lboxSuspectProcNames));
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
            tboxPort.Enabled = true;
            btnUpdateOrAdd.Text = "Add";
            btnCancleUpdatePortDeviceMapEntry.Enabled = false;

            RefreshDevieNameMapTable();

        }


        private void listViewDeviceMapTable_DoubleClick(object sender, EventArgs e)
        {
            if (listViewDeviceMapTable.SelectedIndices.Count == 0)
                return;

            ListViewItem selItem = listViewDeviceMapTable.SelectedItems[0];
            tboxPort.Enabled = false;
            tboxPort.Text = selItem.SubItems[0].Text;
            tboxDeviceFileName.Text = selItem.SubItems[1].Text;
            btnUpdateOrAdd.Text = "Update";
            btnCancleUpdatePortDeviceMapEntry.Enabled = true;
        }

        private void btnUpdateOrAdd_Click(object sender, EventArgs e)
        {
            string devName = tboxDeviceFileName.Text.Trim();
            if (devName.Length == 0)
            {
                yMessageBox.ShowError(this, "The device file name should not be empty!");
                tboxDeviceFileName.Focus();
                return;
            }

            if (DeviceMapTable.ContainsDeviceName(devName))
            {
                yMessageBox.ShowError(this, "The device file name has already existed, it should not be same with others!");
                tboxDeviceFileName.Focus();
                return;
            }

            if (btnUpdateOrAdd.Text == "Update")
            {
                DeviceMapTable.Remove(tboxPort.Text);
                DeviceMapTable.Add(tboxPort.Text, devName);
                RefreshDevieNameMapTable();
                btnCancleUpdatePortDeviceMapEntry.Enabled = false;
                btnUpdateOrAdd.Text = "Add";
            }
            else
            {
                string strPort = tboxPort.Text.Trim();
                if (DeviceMapTable.ContainsPort(strPort))
                {
                    yMessageBox.ShowError(this, "The port number has already existed, it should not be same with others!");
                    tboxPort.Focus();
                    return;
                }

                try
                {
                    uint.Parse(strPort);
                }
                catch
                {
                    yMessageBox.ShowError(this, "The port number should be an integer!");
                    tboxPort.Focus();
                    return;
                }
                DeviceMapTable.Add(strPort, devName);
                RefreshDevieNameMapTable();
            }

            tboxPort.Text = string.Empty;
            tboxDeviceFileName.Text = string.Empty;
        }

        private void btnCancleUpdatePortDeviceMapEntry_Click(object sender, EventArgs e)
        {
            tboxDeviceFileName.Text = string.Empty;
            tboxPort.Text = string.Empty;
            tboxPort.Enabled = true;
            btnCancleUpdatePortDeviceMapEntry.Enabled = false;
            btnUpdateOrAdd.Text = "Add";
        }

        #endregion


        #region save_default_action

        private void Save()
        {
            SaveTabComPorts();
            SaveTabSuspectProc();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            m_hasDoneSave = true;
            this.Close();
        }

        #endregion

        private void listViewDeviceMapTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listViewDeviceMapTable.SelectedItems.Count == 0)
                    return;

                if (DialogResult.No == yMessageBox.ShowConfirm(this, "Are you sure want to delete the selected entry (port=" + 
                    listViewDeviceMapTable.SelectedItems[0].SubItems[0].Text + ", device_file_name=" + 
                    listViewDeviceMapTable.SelectedItems[0].SubItems[1].Text + ")?"))
                {
                    return;
                }

                DeviceMapTable.Remove(listViewDeviceMapTable.SelectedItems[0].SubItems[0].Text);
                RefreshDevieNameMapTable();
            }
        }

        private void btnBuildDeviceFileNameMap_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == yMessageBox.ShowConfirm(this, "Before building, please let all the ports are released."
                + System.Environment.NewLine + System.Environment.NewLine 
                + "Are you sure want to rebuild the Port-DeviceFileName map table?"))
            {
                return;
            }
            this.Enabled = false;

            new System.Threading.Thread(threadBuild).Start();
        }

        public void threadBuild()
        {
            ArrayList errorPortList = null;
            DeviceMapTable.ProgressEvent = this;
            DeviceMapTable.BuildTableFile(AppConfig.DeviceMapFilePath, ComHandle.GetAllPorts(), ref errorPortList);
            btnBuildDeviceFileNameMap.Text = "Build";
            string[] arrErrorPorts = new string[errorPortList.Count];
            errorPortList.CopyTo(arrErrorPorts, 0);
            if (errorPortList != null && errorPortList.Count > 0)
            {
                yMessageBox.ShowError(this, "I cannot find the mapped device file name of the following ports, maybe these ports are not released."
                    + System.Environment.NewLine + string.Join(",", arrErrorPorts));
            }
            RefreshDevieNameMapTable();
            this.Enabled = true;
            listViewDeviceMapTable.Focus();
        }

        private string lastProgressIndicator = " -- ";
        public void ProgressUpdate(string msg)
        {
            btnBuildDeviceFileNameMap.Text = lastProgressIndicator + msg + lastProgressIndicator;
            if (lastProgressIndicator == " - ")
                lastProgressIndicator = " / ";
            else if (lastProgressIndicator == " / ")
                lastProgressIndicator = " | ";
            else if (lastProgressIndicator == " | ")
                lastProgressIndicator = " \\ ";
            else
                lastProgressIndicator = " - ";
        }

        private void comboBoxRowHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_generalEventHandle != null)
                m_generalEventHandle.UpdateRowHeight(int.Parse(comboBoxRowHeight.Text));
        }

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_hasDoneSave && DialogResult.No == yMessageBox.ShowConfirm(this, "Are you sure want to close? If so, all modification will be discared."))
            {
                e.Cancel = true;
            }
        }
    }
}
