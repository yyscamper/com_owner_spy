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
    public partial class FormSelectPorts : Form
    {
        private SortedSet<uint> m_selectedPorts = new SortedSet<uint>();
        private SortedSet<uint> m_removedPorts = new SortedSet<uint>();

        public FormSelectPorts()
        {
            InitializeComponent();

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
        }

        private void FormInitPorts_Load(object sender, EventArgs e)
        {
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

        private void Save()
        {
            ComHandle.Clear();
            for (int i = 0; i < lboxSelectedPorts.Items.Count; i++ )
            {
                ComHandle.Add(new ComItem(lboxSelectedPorts.Items[i].ToString()));
            }
            AppConfig.SaveGlobalConfig();
            ComHandle.ModifyFlag = true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void FormInitPorts_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
