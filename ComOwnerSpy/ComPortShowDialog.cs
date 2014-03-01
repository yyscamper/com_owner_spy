using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    public partial class ComPortShowDialog : Form
    {
        private ComPortItem _selPort = null;

        Dictionary<int, List<ComPortItem>> _allOwnerProcess = null;

        public ComPortShowDialog(ComPortItem selPort)
        {
            InitializeComponent();

            Theme theme = ThemeManager.CurrentTheme;
            this.BackColor = theme.BackColor;
            panelUp.BackColor = theme.ColorA;
            listViewAllOwnProcs.BackColor = theme.ColorE;
            foreach (Control c in this.Controls)
                c.ForeColor = theme.FontColor;
            listViewAllOwnProcs.ForeColor = theme.FontColor;

            _selPort = selPort;
            AutoSizeUIComponent();

            RefreshUIData();
        }

        private void RefreshUIData()
        {
            labelSelectPortName.Text = _selPort.PortName;
            labelOwnerName.Text = OwnerTranslate.GetOwnerShow(OwnerShowFormat.FullName, _selPort.OwnUser)
                        + " (" + _selPort.OwnUser + ", Phone:"
                        + OwnerTranslate.GetOwnerShow(OwnerShowFormat.Phone, _selPort.OwnUser)
                        + ")";

            _allOwnerProcess = new Dictionary<int, List<ComPortItem>>();
            ComPortItem[] allItems = ComPortControlTable.AllItems;
            foreach (ComPortItem item in allItems)
            {
                if (item.OwnProcessId < 0 || item.OwnUser == null || item.OwnUser.Length <= 0)
                    continue;

                if (item.OwnUser == _selPort.OwnUser)
                {
                    if (_allOwnerProcess.ContainsKey(item.OwnProcessId))
                    {
                        List<ComPortItem> lst = _allOwnerProcess[item.OwnProcessId];
                        lst.Add(item);
                    }
                    else
                    {
                        List<ComPortItem> lst = new List<ComPortItem>();
                        lst.Add(item);
                        _allOwnerProcess.Add(item.OwnProcessId, lst);
                    }
                }
            }

            listViewAllOwnProcs.Items.Clear();
            foreach (int key in _allOwnerProcess.Keys)
            {
                List<ComPortItem> lst = _allOwnerProcess[key];
                StringBuilder stext = new StringBuilder();
                string appName = null;
                bool fst = true;
                foreach (ComPortItem item in lst)
                {
                    if (fst)
                    {
                        appName = item.OwnAppName;
                        fst = false;
                    }
                    else
                    {
                        stext.Append(", ");
                    }
                    stext.Append(item.PortName);
                }

                AutoSizeLastColumnWidth();

                ListViewItem lvi = new ListViewItem(new string[] { key.ToString(), appName, stext.ToString() });
                lvi.Tag = key;
                listViewAllOwnProcs.Items.Add(lvi);
                if (key == _selPort.OwnProcessId)
                {
                    lvi.Checked = true;
                    lvi.BackColor = ThemeManager.CurrentTheme.ColorD;
                }
            }
        }

        private void ComPortShowDialog_Load(object sender, EventArgs e)
        {

        }

        private void picBoxKill_MouseDown(object sender, MouseEventArgs e)
        {
            picBoxKill.BorderStyle = BorderStyle.Fixed3D;
        }

        private void picBoxKill_MouseUp(object sender, MouseEventArgs e)
        {
            picBoxKill.BorderStyle = BorderStyle.None;
        }

        private void picBoxKill_MouseLeave(object sender, EventArgs e)
        {
            picBoxKill.BorderStyle = BorderStyle.None;
        }

        private void picBoxKill_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == yMessageBox.ShowKillProcConfirm(listViewAllOwnProcs.CheckedItems.Count, this, "Confirm Kill Process"))
            {
                if (DialogResult.Yes == yMessageBox.ShowKillProcConfirm(listViewAllOwnProcs.CheckedItems.Count, this, "Confirm Kill Process"))
                 {
                     foreach (ListViewItem lvi in listViewAllOwnProcs.CheckedItems)
                     {
                         try
                         {
                             Process proc = Process.GetProcessById((int)lvi.Tag);
                             if (proc != null)
                             {
                                 proc.Kill();

                                 List<ComPortItem> lstItem = _allOwnerProcess[(int)lvi.Tag];
                                 foreach (ComPortItem comItem in lstItem)
                                 {
                                     comItem.Update(string.Empty, string.Empty, string.Empty, ComPortItem.INVALID_PROCESS_ID);
                                     if (comItem.GuiItem != null)
                                     {
                                         for (int i = 1; i < comItem.GuiItem.SubItems.Count; i++)
                                             comItem.GuiItem.SubItems[i].Text = string.Empty;
                                     }
                                 }
                             }
                         }
                         catch (Exception err)
                         {
                             yMessageBox.ShowError(this, "Kill processes error:" + err.Message, "Kill Processes Error");
                             return;
                         }
                     }

                     this.Close();
                 }
            }
        }

        private void listViewAllOwnProcs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem lvi in listViewAllOwnProcs.Items)
                {
                    lvi.Checked = true;
                }
            }
        }

        private void listViewAllOwnProcs_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listViewAllOwnProcs.CheckedItems.Count > 0)
            {
                picBoxKill.Enabled = true;
                picBoxKill.Image = Properties.Resources.kill_enabled;
            }
            else
            {
                picBoxKill.Enabled = false;
                picBoxKill.Image = Properties.Resources.kill_disabled;
            }
        }

        private void listViewAllOwnProcs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                if ((int)listViewAllOwnProcs.Items[e.Index].Tag == _selPort.OwnProcessId)
                    e.NewValue = e.CurrentValue;
            }
        }

        private void AutoSizeUIComponent()
        {
            listViewAllOwnProcs.Width = this.Width - 29;
            listViewAllOwnProcs.Height = this.Height - panelUp.Height - 77;
            panelUp.Width = picBoxKill.Location.X - 13;

            AutoSizeLastColumnWidth();
        }

        private void AutoSizeLastColumnWidth()
        {           
            Graphics gf = this.CreateGraphics();
            int maxFontWidth = 0;
            foreach (ListViewItem lvi in listViewAllOwnProcs.Items)
            {
                int w = (int)gf.MeasureString(lvi.SubItems[2].Text, listViewAllOwnProcs.Font).Width;
                if (w > maxFontWidth)
                    maxFontWidth = w;
            }
            maxFontWidth += 6;
            int calWidth = listViewAllOwnProcs.Width - colPID.Width - colAppName.Width - 8;
            colOpenedPorts.Width = maxFontWidth > calWidth ? maxFontWidth : calWidth;
        }

        private void ComPortShowDialog_Resize(object sender, EventArgs e)
        {
            AutoSizeUIComponent();
        }

    }
}
