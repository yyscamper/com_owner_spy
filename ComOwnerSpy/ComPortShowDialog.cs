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

        public ComPortShowDialog(ComPortItem selPort)
        {
            InitializeComponent();

            Theme theme = ThemeManager.CurrentTheme;
            this.BackColor = theme.BackColor;
            panelUp.BackColor = theme.ColorA;
            panelDown.BackColor = theme.BackColor;
            listViewAllOwnProcs.BackColor = theme.ColorC;
            foreach (Control c in this.Controls)
                c.ForeColor = theme.FontColor;
            listViewAllOwnProcs.ForeColor = theme.FontColor;

            _selPort = selPort;

            RefreshUIData();
        }

        private void RefreshUIData()
        {
            labelSelectPortName.Text = _selPort.PortName;
            labelOwnerName.Text = _selPort.FormatedOwner;

            Dictionary<int, List<ComPortItem>> allOwnerProcs = new Dictionary<int, List<ComPortItem>>();
            ComPortItem[] allItems = ComPortControlTable.AllItems;
            foreach (ComPortItem item in allItems)
            {
                if (item.OwnProcessId < 0 || item.OwnUser == null || item.OwnUser.Length <= 0)
                    continue;

                if (item.OwnUser == _selPort.OwnUser)
                {
                    if (allOwnerProcs.ContainsKey(item.OwnProcessId))
                    {
                        List<ComPortItem> lst = allOwnerProcs[item.OwnProcessId];
                        lst.Add(item);
                    }
                    else
                    {
                        List<ComPortItem> lst = new List<ComPortItem>();
                        lst.Add(item);
                        allOwnerProcs.Add(item.OwnProcessId, lst);
                    }
                }
            }

            listViewAllOwnProcs.Items.Clear();
            foreach (int key in allOwnerProcs.Keys)
            {
                List<ComPortItem> lst = allOwnerProcs[key];
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
            StringBuilder stext = new StringBuilder();
            stext.Append("Are you sure want to kill your selected processes?");
            if (DialogResult.Yes == yMessageBox.ShowConfirm(this, stext.ToString(), "Confirm Kill Processes"))
            {
                 if (DialogResult.Yes == yMessageBox.ShowConfirm(this, stext.ToString(), "Confirm Kill Processes"))
                 {
                     foreach (ListViewItem lvi in listViewAllOwnProcs.CheckedItems)
                     {
                         try
                         {
                             Process proc = Process.GetProcessById((int)lvi.Tag);
                             if (proc != null)
                             {
                                 proc.Kill();
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

    }
}
