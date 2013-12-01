using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    public partial class FormMain : Form, IGeneralEvent
    {
        Thread _autoUpdateThread = null;

        public FormMain()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            listPortTable.Columns.Add("Port", 60);
            listPortTable.Columns.Add("Owner", 220);
            listPortTable.Columns.Add("Application", 200);
            listPortTable.Columns.Add("Process", 256);

            listPortTable.View = View.Details;
            listPortTable.MultiSelect = false;
            listPortTable.Visible = true;
            listPortTable.FullRowSelect = true;
            listPortTable.GridLines = true;

            UpdateRowHeight(24);

            Control.CheckForIllegalCrossThreadCalls = false;

            this.Size = new Size(900, 675);

            Version appVer = new Version(Application.ProductVersion);
            this.Text = "COM Owner Spy (" + appVer.Major + "." + appVer.Minor + ")";
        }

        private int GetLastColumnWidth()
        {
            int val = this.Width - listPortTable.Columns[0].Width
                - listPortTable.Columns[1].Width - listPortTable.Columns[2].Width - 64;
            if (val < 180)
                val = 180;
            return val;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            CreateRows();
            checkBoxAutoRefresh.Checked = AppConfig.EnableAutoRefreshAtStartup;

            RefreshAll(); //Always performs a refresh all while boot up
        }

        private void CreateRows()
        {      
            listPortTable.BeginUpdate();
            listPortTable.Items.Clear();
            string[] ports = ComHandle.GetAllPorts();
            comboBoxJumpPort.Items.Clear();
            comboBoxJumpPort.Items.AddRange(ports);
            foreach (string port in ports)
            {
                ListViewItem lvi = new ListViewItem(new string[] { port, string.Empty, string.Empty, string.Empty});
                listPortTable.Items.Add(lvi);
                ComItem item = ComHandle.Get(port);
                if (item != null)
                    item.GuiItem = lvi;
            }
            listPortTable.EndUpdate();
        }

        private void UpdateRowData(ListViewItem lvi, ComItem item)
        {
            if (lvi == null || item == null)
                return;

            //listPortTable.BeginUpdate();
            lvi.SubItems[1].Text = item.OwnerShow;
            lvi.SubItems[2].Text = item.App;
            lvi.SubItems[3].Text = item.ProcessInfo;
            //listPortTable.EndUpdate();
        }

        private void RefreshAll()
        {
            DateTime timeBegin = DateTime.Now;

            string[] allNames = AppConfig.AllSuspectProcessNames;
            ComHandle.ResetDetectedFlag();
            foreach (string procSuspectName in allNames)
            {
                Application.DoEvents();
                Process[] allProcs = Process.GetProcessesByName(procSuspectName);
                foreach (Process proc in allProcs)
                {
                    Application.DoEvents();
                    ArrayList devices = new ProcessFileHandle(proc.Id).GetComFileHandle();
                    foreach (string devName in devices)
                    {
                        Application.DoEvents();

                        string port = DeviceMapTable.GetPort(devName);
                        if (port == null)
                            continue;

                        ComItem item = ComHandle.Get(port);
                        if (item == null)
                            continue;

                        item.DetectedFlag = true;
                        if (item.Update(Utility.GetProcessOwner(proc.Id, AppConfig.OwnerWithDomain),
                            procSuspectName, proc.ProcessName + "(" + proc.Id.ToString() + ")",
                            proc.Id))
                        {
                            UpdateRowData(item.GuiItem, item);
                        }
                    }
                }
            }

            Dictionary<string, ComItem> allComs = ComHandle.AllComs;
            foreach (ComItem item in allComs.Values)
            {
                if (item.GuiItem != null && !item.DetectedFlag)
                {
                    if (item.Update(string.Empty, string.Empty, string.Empty, -1))
                    {
                        item.GuiItem.SubItems[1].Text =
                            item.GuiItem.SubItems[2].Text =
                                item.GuiItem.SubItems[3].Text = string.Empty;
                    }
                }
            }

            DateTime timeEnd = DateTime.Now;
            TimeSpan timeConsume = timeEnd - timeBegin;
            statusLabelRefreshTime.Text = string.Format("{0:D2}/{1:D2} {2:D2}:{3:D2}:{4:D2}", timeEnd.Month, timeEnd.Day, timeEnd.Hour, timeEnd.Minute, timeEnd.Second);
            statusLabelRefreshConsumeTime.Text = timeConsume.TotalSeconds.ToString("0.0") + " Sec";
        }

        private void RunTask()
        {
            TimeSpan tspan;
            while (true)
            {
                Application.DoEvents();

                DateTime tnow = DateTime.Now;
                RefreshAll();

                do
                {
                    tspan = DateTime.Now - tnow;
                    System.Threading.Thread.Sleep(200);
                } while (tspan.TotalSeconds < AppConfig.AutoRefreshInterval);
            }
        }

        private void checkBoxAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            bool chkFlag = ((CheckBox)sender).Checked;
            btnRefresh.Enabled = !checkBoxAutoRefresh.Checked;
            if (chkFlag)
            {
                _autoUpdateThread = new System.Threading.Thread(RunTask);
                _autoUpdateThread.Name = Application.ProductName + "_AutoRefreshThread";
                _autoUpdateThread.Start();
                menuRefresh.Visible = false;
            }
            else
            {
                if (_autoUpdateThread != null)
                {
                    _autoUpdateThread.Abort();
                    _autoUpdateThread = null;
                }
                menuRefresh.Visible = true;
            }

        }

        private void btnPortsSetting_Click(object sender, EventArgs e)
        {
            if (_autoUpdateThread != null)
                _autoUpdateThread.Abort();

            ComHandle.ModifyFlag = false;
            //new FormSelectPorts().ShowDialog(this);
            new FormSetting(this).ShowDialog(this);
            if (ComHandle.ModifyFlag)
                CreateRows();

            _autoUpdateThread = new System.Threading.Thread(RunTask);
            _autoUpdateThread.Name = Application.ProductName + "_AutoRefreshThread";
            _autoUpdateThread.Start();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            groupTitleAction.Width = this.Width - 32;
            listPortTable.Width = this.Width - 32;
            listPortTable.Height = this.Height - 48 - groupTitleAction.Height - theStatusBar.Height;
            listPortTable.Columns[listPortTable.Columns.Count - 1].Width = GetLastColumnWidth();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            new FormOptions().ShowDialog(this);
        }

        private void menuKill_Click(object sender, EventArgs e)
        {
            if (listPortTable.SelectedIndices.Count <= 0)
                return;

            string strPort = listPortTable.SelectedItems[0].SubItems[0].Text;
            ComItem item = ComHandle.Get(strPort);
            if (item == null || item.ProcessId <= 0)
                return;

            Process proc = Process.GetProcessById(item.ProcessId);
            if (proc == null)
                return;

            string msg = "Are you sure want to kill the process (Name=" + proc.ProcessName + ",ID=" + proc.Id + ")?";

            if (DialogResult.Yes == yMessageBox.ShowConfirm(this, msg, "Confirm Kill Process"))
            {
                if (DialogResult.Yes == yMessageBox.ShowConfirm(this, msg, "Confirm Kill Process"))
                {
                    try
                    {
                        proc.Kill();
                    }
                    catch (Exception err)
                    {
                       yMessageBox.ShowError(this, "Kill process error, error message:" + System.Environment.NewLine + err.Message,
                            "Error Kill Process");
                    }
                }
            }
        }

        private void ctxMenuPortsTable_Opening(object sender, CancelEventArgs e)
        {
            if (listPortTable.SelectedIndices.Count < 0)
            {
                e.Cancel = true;
                return;
            }

            string strPort = listPortTable.SelectedItems[0].SubItems[0].Text;
            ComItem item = ComHandle.Get(strPort);
            if (item == null || item.ProcessId <= 0)
            {
                e.Cancel = true;
                return;
            }
        }

        private void bntSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_autoUpdateThread != null)
                _autoUpdateThread.Abort();
        }

        private void btnJumpPort_Click(object sender, EventArgs e)
        {
            string jumpPort = comboBoxJumpPort.Text.Trim();
            if (jumpPort.Length <= 0)
                return;

            for (int i = 0; i < listPortTable.Items.Count; i++)
            {
                ListViewItem item = listPortTable.Items[i];
                if (item.SubItems[0].Text == jumpPort)
                {
                    //listPortTable.SelectedItems.Clear();
                    //listPortTable.FocusedItem.Focused = false;
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    listPortTable.Select();
                    return;
                }
            }
            yMessageBox.ShowError(this, "Cannot find the port " + jumpPort + " to jump.", "Jump Error");
        }

        private void menuRefreshPortInfo_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            RefreshAll();
            this.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            RefreshAll();
            this.Enabled = true;
        }

        private void comboBoxRowHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void UpdateRowHeight(int rowHeight)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, rowHeight);
            listPortTable.SmallImageList = imgList;

            AppConfig.RowHeight = rowHeight;
        }

        private void comboBoxJumpPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnJumpPort.PerformClick();
        }

        public void UpdateOwnerFormat(OwnerShowFormat fmt)
        {
            Dictionary<string, ComItem> allComs = ComHandle.AllComs;
            foreach (ComItem item in allComs.Values)
            {
                if (item.GuiItem != null && item.Owner != string.Empty)
                {
                    item.GuiItem.SubItems[1].Text = item.OwnerShow;
                }
            }
        }
    }
}
