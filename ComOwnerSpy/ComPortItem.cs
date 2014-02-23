using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    public class ComPortItem
    {
        public static readonly int INVALID_PROCESS_ID = -1;

        private readonly string _port; //such as COM1, COM2,..
        private readonly string _deviceName; //such as \Device\Serial0

        private int _ownProcessId = INVALID_PROCESS_ID;
        private string _ownAppName = string.Empty;
        private string _ownProcessDetailInfo = string.Empty;
        private string _ownUser = string.Empty;

        private bool _detectedFlag = true;
        private ListViewItem _guiItem = null;

        public ComPortItem(string port, string devName)
        {
            _port = port;
            _deviceName = devName;
        }

        public string PortName
        {
            get { return _port; }
        }

        public string DeviceName
        {
            get { return _deviceName; }
        }

        public ListViewItem GuiItem
        {
            get { return _guiItem; }
            set { _guiItem = value; }
        }

        public int OwnProcessId
        {
            get { return _ownProcessId; }
            set { _ownProcessId = value; }
        }

        public string OwnDetailProcessInfo
        {
            get { return _ownProcessDetailInfo; }
            set { _ownProcessDetailInfo = value; }
        }

        public string OwnUser
        {
            get { return _ownUser; }
            set { _ownUser = value; }
        }

        public string FormatedOwner
        {
            get { return OwnerTranslate.GetOwnerShow(AppConfig.OwnerFormat, _ownUser); }
        }

        public string OwnAppName
        {
            get { return _ownAppName; }
            set { _ownAppName = value; }
        }

        public bool DetectedFlag
        {
            get { return _detectedFlag; }
            set { _detectedFlag = value; }
        }
        
        /// <summary>
        /// Update COM Port Information
        /// </summary>
        /// <param name="owner">The new own user name</param>
        /// <param name="app">The new own application name</param>
        /// <param name="procInfo">The new process detail information</param>
        /// <param name="procId">The new process ID</param>
        /// <returns>True if the info has changed; Faluse if the info is same as previous</returns>
        public bool Update(string owner, string app, string procInfo, int procId)
        {
            bool hasModify = false;
            if (owner != _ownUser)
            {
                _ownUser = owner;
                hasModify = true;
            }

            if (app != _ownAppName)
            {
                _ownAppName = app;
                hasModify = true;
            }

            if (procInfo != _ownProcessDetailInfo)
            {
                _ownProcessDetailInfo = procInfo;
                hasModify = true;
            }

            _ownProcessId = procId;
            return hasModify;
        }

        public void ClearContent()
        {
            if (_guiItem == null)
                return;

            if (Update(string.Empty, string.Empty, string.Empty, INVALID_PROCESS_ID))
            {
                for (int i = 1; i < _guiItem.SubItems.Count; i++) //ingore the first item as it is the port name
                {
                    _guiItem.SubItems[i].Text = string.Empty;
                }
            }
        }
    }
}
