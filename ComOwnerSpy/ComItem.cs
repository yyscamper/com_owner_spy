using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    public class ComItem
    {
        private string _port;
        private int _procId;
        private string _app;
        private string _procInfo;
        private string _owner;
        private bool _detectedFlag;
        private ListViewItem _guiItem;

        public ComItem()
        {
            _port = string.Empty;
            _procId = -1;
            _app = string.Empty;
            _procInfo = string.Empty;
            _owner = string.Empty;
            _detectedFlag = true;
        }

        public ComItem(string port)
        {
            _port = port;
            _procId = -1;
            _app = string.Empty;
            _procInfo = string.Empty;
            _owner = string.Empty;
            _detectedFlag = true;
        }

        public ListViewItem GuiItem
        {
            get { return _guiItem; }
            set { _guiItem = value; }
        }

        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public int ProcessId
        {
            get { return _procId; }
            set { _procId = value; }
        }

        public string ProcessInfo
        {
            get { return _procInfo; }
            set { _procInfo = value; }
        }

        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public string App
        {
            get { return _app; }
            set { _app = value; }
        }

        public bool DetectedFlag
        {
            get { return _detectedFlag; }
            set { _detectedFlag = value; }
        }

        public bool Update(string owner, string app, string procInfo, int procId)
        {
            bool hasModify = false;
            if (owner != _owner)
            {
                _owner = owner;
                hasModify = true;
            }

            if (app != _app)
            {
                _app = app;
                hasModify = true;
            }

            if (procInfo != _procInfo)
            {
                _procInfo = procInfo;
                hasModify = true;
            }

            _procId = procId;
            return hasModify;
        }
    }

    public static class ComHandle
    {
        static Dictionary<string, ComItem> _allComs = new Dictionary<string, ComItem>();
        static public bool ModifyFlag = false;

        public static Dictionary<string, ComItem> AllComs
        {
            get { return _allComs; }
        }

        public static void Add(ComItem item)
        {
            if (_allComs.ContainsKey(item.Port))
                return;
            _allComs.Add(item.Port, item);
        }

        public static ComItem Get(string port)
        {
            if (_allComs.ContainsKey(port))
                return _allComs[port];
            return null;
        }

        public static void Remove(string port)
        {
            if (_allComs.ContainsKey(port))
                _allComs.Remove(port);
        }

        public static void Clear()
        {
            _allComs.Clear();
        }

        public static void ResetDetectedFlag()
        {
            foreach (string port in _allComs.Keys)
            {
                ComItem item = _allComs[port];
                item.DetectedFlag = false;
            }
        }

        public static string[] GetAllPorts()
        {
            string[] allPorts = new string[_allComs.Keys.Count];
            _allComs.Keys.CopyTo(allPorts, 0);
            return allPorts;
        }
    }
}
