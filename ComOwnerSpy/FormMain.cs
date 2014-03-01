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
using OptProgressControl;

namespace ComOwnerSpy
{
    public partial class FormMain : Form, IGeneralEvent
    {
        /// <summary>
        /// The thread that do the auto refresh task
        /// </summary>
        private Thread _autoRefreshThread = null;
        private Thread _launchRefreshOnceThread = null;
        private OptimizedCircularProgressControl _refreshProgressCtrl = null;
        private bool _enableMouseWheelChangeRowHeight = false;
        private bool _originAutoRefreshEnable = false;
        private int _originRefreshInterval = 10;
        private OwnerShowFormat _originOwnerShowFmt = AppConfig.OwnerFormat;
        /// <summary>
        /// Create row for each COM port and initialize it to empty except port name.
        /// </summary>
        private void CreateRows()
        {
            listPortTable.BeginUpdate();
            listPortTable.Items.Clear();
            string[] ports = ComPortControlTable.AllPortNames;
            comboBoxGotoPort.Items.Clear();
            comboBoxGotoPort.Items.AddRange(ports);
            foreach (string port in ports)
            {
                ListViewItem lvi = new ListViewItem(new string[] { port, string.Empty, string.Empty, string.Empty });
                listPortTable.Items.Add(lvi);
                ComPortItem item = ComPortControlTable.GetItemByPortName(port);
                if (item != null)
                    item.GuiItem = lvi;
            }
            listPortTable.EndUpdate();
        }

        /// <summary>
        /// Constructor function
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            theStatusBar.Items.Add(statusLabelRefreshTime);
            theStatusBar.Items.Add(statusLabelRefreshConsumeTime);

            //set to double buffer mode to enhance the performance.
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            Version appVer = new Version(Application.ProductVersion);
            this.Text = "COM Owner Spy (" + appVer.Major + "." + appVer.Minor + ")";
            numUpDownInterval.Value = AppConfig.AutoRefreshInterval;

            _originAutoRefreshEnable = AppConfig.EnableAutoRefresh;
            _originRefreshInterval = AppConfig.AutoRefreshInterval;

            //initiate the COM port table
            listPortTable.Columns.Add("Port", 100);
            listPortTable.Columns.Add("Owner", 200);
            listPortTable.Columns.Add("Application", 180);
            listPortTable.Columns.Add("Process", 256);
            listPortTable.View = View.Details;
            listPortTable.MultiSelect = false;
            listPortTable.Visible = true;
            listPortTable.FullRowSelect = true;
            listPortTable.GridLines = true;
            UpdateRowHeight(24);
            CreateRows();
            UpdateOwnerFormat(AppConfig.OwnerFormat);

            picBoxRefresh.Enabled = labelManulRefresh.Enabled = AppConfig.EnableAutoRefresh;
            picBoxRefresh.Enabled = labelManulRefresh.Enabled = !AppConfig.EnableAutoRefresh; //trigger the callback

            //the size should be set after the listPortTable initialization, because this will
            //trigger the callback of Form_Resize and cause crash.
            this.Size = new Size(800, 640);
            OnNotifyChangeTheme(ThemeManager.CurrentTheme);

            Control.CheckForIllegalCrossThreadCalls = false; //avoid multi-threads warning

            listPortTable.MouseWheel += listPortTable_MouseWheel;
        }

        private void StartRefreshProgressView(string statusMessage)
        {
            statusLabelRefreshTime.Text = statusMessage;
            statusLabelRefreshConsumeTime.Text = string.Empty;

            if (_refreshProgressCtrl != null)
                return;

            //add the progress info while first loading.
            _refreshProgressCtrl = new OptimizedCircularProgressControl();
            _refreshProgressCtrl.Dock = DockStyle.Fill;
            _refreshProgressCtrl.StartAngle = 30;
            _refreshProgressCtrl.BackColor = Color.Transparent;
            listPortTable.Controls.Add(_refreshProgressCtrl);
            _refreshProgressCtrl.TickColor = this.ForeColor;
            _refreshProgressCtrl.Start();

            this.Enabled = false;
            //picBoxSetting.Enabled = picBoxRefresh.Enabled = comboBoxGotoPort.Enabled = false;
        }

        private void StopRefreshProgressView()
        {
            if (_refreshProgressCtrl != null)
            {
                _refreshProgressCtrl.Stop();
                _refreshProgressCtrl.Visible = false;
                listPortTable.Controls.Remove(_refreshProgressCtrl);
                _refreshProgressCtrl = null;
            }
            this.Enabled = true;
            //picBoxSetting.Enabled = picBoxRefresh.Enabled = comboBoxGotoPort.Enabled = true;
        }

        private void StartBackgroundRefreshOnceTask(string statusMessage)
        {
            StartRefreshProgressView(statusMessage);

            if (_autoRefreshThread == null)
            {
                _launchRefreshOnceThread = new System.Threading.Thread(RefreshAllComPorts);
                _launchRefreshOnceThread.Name = Application.ProductName + "_LaunchRefreshOnceThread";
                _launchRefreshOnceThread.Start();
            }
        }

        private void WaitBackgroundRefreshOnceTaskStopped()
        {
            //wait the launch refresh thread finished.
            if (_launchRefreshOnceThread != null)
            {
                while (_launchRefreshOnceThread.IsAlive)
                {
                    Application.DoEvents();
                }
                _launchRefreshOnceThread.Abort();
                _launchRefreshOnceThread = null;
            }

            StopRefreshProgressView();
        }

        /// <summary>
        /// Callback function while loading Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {      
            menuEnableAutoRefresh.Checked = AppConfig.EnableAutoRefresh;
            StartBackgroundRefreshOnceTask("First scanning");
            AutoRefreshChanged(true);
        }

        private void AutoRefreshChanged(bool newState)
        {
            bool isAutoRefreshSelected = newState;
            picBoxRefresh.Enabled = !isAutoRefreshSelected;
            labelManulRefresh.Enabled = picBoxRefresh.Enabled;

            if (isAutoRefreshSelected) //if auto refresh task is enabled
            {
                if (_autoRefreshThread == null)
                {
                    //create and start the background auto refresh task
                    _autoRefreshThread = new System.Threading.Thread(RunAutoRefreshTask);
                    _autoRefreshThread.Name = Application.ProductName + "_AutoRefreshThread";
                    _autoRefreshThread.Start();
                }
            }
            else
            {
                //abort the thread as the auto refresh task is disabled.
                if (_autoRefreshThread != null)
                {
                    _autoRefreshThread.Abort();
                    _autoRefreshThread = null;
                }
            }
        }
        private void checkBoxAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            AutoRefreshChanged(((CheckBox)sender).Checked);
        }

        /// <summary>
        /// Refresh all serial port information and update it to GUI.
        /// </summary>
        private void RefreshAllComPorts()
        {
            DateTime timeBegin = DateTime.Now;
            ComPortControlTable.RefreshAll();
            DateTime timeEnd = DateTime.Now;
            TimeSpan timeConsume = DateTime.Now - timeBegin;
            statusLabelRefreshTime.Text = string.Format("Last Refresh @{0:D2}:{1:D2}:{2:D2},", timeEnd.Hour, timeEnd.Minute, timeEnd.Second);
            statusLabelRefreshConsumeTime.Text = string.Format(" Consumes {0:F1}", timeConsume.TotalSeconds);
        }

        /// <summary>
        /// Run the background thread to auto refresh the serial port info
        /// </summary>
        private void RunAutoRefreshTask()
        {
            WaitBackgroundRefreshOnceTaskStopped();
            picBoxRefresh.Enabled = !AppConfig.EnableAutoRefresh;
            labelManulRefresh.Enabled = picBoxRefresh.Enabled;

            TimeSpan tspan;
            while (true)
            {
                if (!AppConfig.EnableAutoRefresh)
                    return;

                Application.DoEvents();

                DateTime tnow = DateTime.Now;
                RefreshAllComPorts();

                do
                {
                    if (!AppConfig.EnableAutoRefresh)
                        return;

                    tspan = DateTime.Now - tnow;
                    System.Threading.Thread.Sleep(500);
                } while (tspan.TotalSeconds < AppConfig.AutoRefreshInterval);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            listPortTable.Width = this.Width - 30;
            listPortTable.Height = this.Height - panelD.Height - 52 - theStatusBar.Height;
            panelD.Width = listPortTable.Width - panelD.Location.X + 7;

            //set the width of the last column
            int tmp = this.Width - listPortTable.Columns[0].Width
               - listPortTable.Columns[1].Width - listPortTable.Columns[2].Width - 41;
            if (tmp < 180)
                tmp = 180;
            listPortTable.Columns[listPortTable.Columns.Count - 1].Width = tmp;
        }

        private void menuKill_Click(object sender, EventArgs e)
        {
            if (listPortTable.SelectedIndices.Count <= 0)
                return;
            string portName = listPortTable.SelectedItems[0].Text;
            ComPortItem item = ComPortControlTable.GetItemByPortName(portName);
            if (item == null || item.OwnProcessId < 0 || item.OwnUser == null)
                return;

            new ComPortShowDialog(item).ShowDialog(); 
        }

        private void ctxMenuPortsTable_Opening(object sender, CancelEventArgs e)
        {
            //Don't show the "KILL" menu if the serial port is not opened.
            if (listPortTable.SelectedIndices.Count < 0)
            {
                menuKill.Visible = false;
                return;
            }

            string strPort = listPortTable.SelectedItems[0].SubItems[0].Text;
            ComPortItem item = ComPortControlTable.GetItemByPortName(strPort);
            if (item == null || item.OwnProcessId <= 0)
            {
                menuKill.Visible = false;
                return;
            }

            menuKill.Visible = true;

            menuEnableAutoRefresh.Checked = AppConfig.EnableAutoRefresh;
            menuOwnerFormatDomainUser.Checked = (AppConfig.OwnerFormat == OwnerShowFormat.DomainUser);
            menuOwnerFormatFullName.Checked = (AppConfig.OwnerFormat == OwnerShowFormat.FullName);
            menuOwnerFormatShortName.Checked = (AppConfig.OwnerFormat == OwnerShowFormat.ShortName 
                            || AppConfig.OwnerFormat == OwnerShowFormat.Default);
            menuOwnerFormatPhone.Checked = (AppConfig.OwnerFormat == OwnerShowFormat.Phone);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //abort the background thread before closing this program.
            if (_autoRefreshThread != null && _autoRefreshThread.IsAlive)
                _autoRefreshThread.Abort();

            if (_originRefreshInterval != AppConfig.AutoRefreshInterval
                || _originAutoRefreshEnable != AppConfig.EnableAutoRefresh
                || _originOwnerShowFmt != AppConfig.OwnerFormat)
            {
                AppConfig.SaveGlobalConfig();
            }
        }

        private void btnGotoPort_Click(object sender, EventArgs e)
        {
            
        }
        private void comboBoxJumpPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            picBoxGotoPort_Click(picBoxGotoPort, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            RefreshAllComPorts();
            this.Enabled = true;
        }

        public void UpdateRowHeight(int rowHeight)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, rowHeight);
            listPortTable.SmallImageList = imgList;
            AppConfig.RowHeight = rowHeight;
        }

        public void UpdateOwnerFormat(OwnerShowFormat fmt)
        {
            AppConfig.OwnerFormat = fmt;
            ComPortItem[] allItems = ComPortControlTable.AllItems;
            foreach (ComPortItem item in allItems)
            {
                if (item.GuiItem != null && item.OwnUser != string.Empty)
                {
                    item.GuiItem.SubItems[1].Text = item.FormatedOwner;
                }
            }

            menuOwnerFormatDomainUser.Checked = (fmt == OwnerShowFormat.DomainUser);
            menuOwnerFormatFullName.Checked = (fmt == OwnerShowFormat.FullName);
            menuOwnerFormatPhone.Checked = (fmt == OwnerShowFormat.Phone);
            menuOwnerFormatShortName.Checked = (fmt == OwnerShowFormat.ShortName || fmt == OwnerShowFormat.Default);
        }

        private void btnPortsSetting_Click(object sender, EventArgs e)
        {
            new FormSetting(this).ShowDialog(this);
        }

        private void picBoxRefresh_Click(object sender, EventArgs e)
        {
            StartBackgroundRefreshOnceTask("Refresh...");
            WaitBackgroundRefreshOnceTaskStopped();
        }

        private void ctxMenuPortsTable_Click(object sender, EventArgs e)
        {
            if (sender == menuEnableAutoRefresh)
            {
                menuEnableAutoRefresh.Checked = !menuEnableAutoRefresh.Checked;
                AutoRefreshChanged(menuEnableAutoRefresh.Checked);
            }
        }

        private void menuEnableAutoRefresh_Click(object sender, EventArgs e)
        {
            if (sender == menuEnableAutoRefresh)
            {
                menuEnableAutoRefresh.Checked = !menuEnableAutoRefresh.Checked;
                AutoRefreshChanged(menuEnableAutoRefresh.Checked);
            }
            else if (sender == menuOwnerFormatDomainUser)
            {
                UpdateOwnerFormat(OwnerShowFormat.DomainUser);
            }
            else if (sender == menuOwnerFormatFullName)
            {
                UpdateOwnerFormat(OwnerShowFormat.FullName);
            }
            else if (sender == menuOwnerFormatPhone)
            {
                UpdateOwnerFormat(OwnerShowFormat.Phone);
            }
            else if (sender == menuOwnerFormatShortName)
            {
                UpdateOwnerFormat(OwnerShowFormat.ShortName);
            }
        }

        private void picBoxRefresh_EnabledChanged(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            if (pbox.Enabled)
                pbox.Image = Properties.Resources.refresh_enabled;
            else
                pbox.Image = Properties.Resources.refresh_disabled;
        }

        private void picBoxSetting_Click(object sender, EventArgs e)
        {
            new FormSetting(this).ShowDialog(this);
        }

        private void picBoxSetting_EnabledChanged(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            if (pbox.Enabled)
                pbox.Image = Properties.Resources.setting;
            else
                pbox.Image = Properties.Resources.setting_disabled;
        }

        private void picBoxRefresh_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            if (sender == picBoxRefresh)
                tt.SetToolTip((Control)sender, "Refresh");
            else if (sender == picBoxSetting)
                tt.SetToolTip((Control)sender, "Open Setting Menu");
            else if (sender == picBoxGotoPort)
                tt.SetToolTip((Control)sender, "Goto Selected Port");
        }

        private void picBoxGotoPort_Click(object sender, EventArgs e)
        {
            string jumpPort = comboBoxGotoPort.Text.Trim();
            if (jumpPort.Length <= 0)
                return;

            for (int i = 0; i < listPortTable.Items.Count; i++)
            {
                ListViewItem item = listPortTable.Items[i];
                if (item.SubItems[0].Text == jumpPort) //match the port name
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    listPortTable.Select();
                    return;
                }
            }
            yMessageBox.ShowError(this, "Cannot find the port " + jumpPort + " to goto.", "Goto Error");
        }

        private void picBoxGotoPort_EnabledChanged(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            if (pbox.Enabled)
                pbox.Image = Properties.Resources._goto;
            else
                pbox.Image = Properties.Resources.goto_disabled;
        }

        private void picBoxSelectAutoRefreshEnable_Click(object sender, EventArgs e)
        {
            AppConfig.EnableAutoRefresh = !AppConfig.EnableAutoRefresh;
            AutoRefreshChanged(AppConfig.EnableAutoRefresh);
            if (AppConfig.EnableAutoRefresh)
                picBoxSelectAutoRefreshEnable.Image = Properties.Resources.switch_on;
            else
                picBoxSelectAutoRefreshEnable.Image = Properties.Resources.switch_off;
        }

        private void picBoxSelectAutoRefreshEnable_EnabledChanged(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            if (pbox.Enabled)
            {
                pbox.Image = (AppConfig.EnableAutoRefresh ? 
                    Properties.Resources.switch_on : Properties.Resources.switch_off);
            }
            else
            {
                pbox.Image = (AppConfig.EnableAutoRefresh ?
                    Properties.Resources.switch_on_disabled : Properties.Resources.switch_off_disabled);
            }
        }

        private void picBoxRefresh_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            pbox.BorderStyle = BorderStyle.Fixed3D;
        }

        private void picBoxRefresh_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            pbox.BorderStyle = BorderStyle.None;
        }

        private void picBoxRefresh_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void picBoxSetting_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            pbox.BorderStyle = BorderStyle.None;
        }


        public void OnNotifyChangeTheme(Theme newTheme)
        {
            if (newTheme != null)
            {
                ThemeManager.CurrentTheme = newTheme;

                this.BackColor = newTheme.BackColor;
                panelA.BackColor = newTheme.ColorA;
                panelB.BackColor = newTheme.ColorB;
                panelC.BackColor = newTheme.ColorC;
                panelD.BackColor = newTheme.ColorD;
                listPortTable.BackColor = newTheme.ColorE;

                foreach (Control c in this.Controls)
                {
                    c.ForeColor = newTheme.FontColor;
                }

                this.ForeColor = newTheme.FontColor;
            }
        }

        void listPortTable_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_enableMouseWheelChangeRowHeight)
                return;

            int val = listPortTable.SmallImageList.ImageSize.Height;
            if (e.Delta > 0 && val < listPortTable.Height)
                val++;
            else if (e.Delta < 0 && val > 1)
                val--;
            else
                return;
            UpdateRowHeight(val);
        }

        private void listPortTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                _enableMouseWheelChangeRowHeight = true;
        }

        private void listPortTable_KeyUp(object sender, KeyEventArgs e)
        {
            _enableMouseWheelChangeRowHeight = false;
        }

        private void listPortTable_DoubleClick(object sender, EventArgs e)
        {
            if (listPortTable.SelectedIndices.Count <= 0)
                return;
            string portName = listPortTable.SelectedItems[0].Text;
            ComPortItem item = ComPortControlTable.GetItemByPortName(portName);
            if (item == null || item.OwnProcessId < 0 || item.OwnUser == null)
                return;

            new ComPortShowDialog(item).ShowDialog();
        }

        private void numUpDownInterval_ValueChanged(object sender, EventArgs e)
        {
            AppConfig.AutoRefreshInterval = (int)numUpDownInterval.Value;
        }
    }
}
