using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    public static class AppConfig
    {
        private static string[] _allSuspectProcessNames;
        private static bool _flagOwnerWithDomain;
        private static string[] _serialDeviceNamePatterns;
        private static int _minSerialDeviceNamePatternLength;
        private static string _deviceMapFilePath;
        private static int _rowHeight;
        private static bool _enableAutoRefreshAtStartup;
        private static int _autoRefreshInternval;
        private static OwnerShowFormat _ownerShowFmt;

        static AppConfig()
        {
            ResetDefault();
        }

        public static void ResetDefault()
        {
            _allSuspectProcessNames = new string[] { "SecureCRT", "ttermpro", "Multy-Term" };
            _deviceMapFilePath = System.Environment.CurrentDirectory + "\\config\\serial_devices.map";
            _flagOwnerWithDomain = true;
            _serialDeviceNamePatterns = new string[] { "\\Device\\Serial", "\\Device\\mxuport" };
            _minSerialDeviceNamePatternLength = Math.Min("\\Device\\Serial".Length, "\\Device\\mxuport".Length);
            _rowHeight = 24;
            _enableAutoRefreshAtStartup = true;
            _autoRefreshInternval = 5;
            _ownerShowFmt = OwnerShowFormat.Default;
        }

        public static OwnerShowFormat OwnerFormat
        {
            get {return _ownerShowFmt; }
            set { _ownerShowFmt = value; }
        }

        public static int AutoRefreshInterval
        {
            get { return _autoRefreshInternval; }
            set { _autoRefreshInternval = value; }
        }

        public static bool EnableAutoRefreshAtStartup
        {
            get { return _enableAutoRefreshAtStartup; }
            set { _enableAutoRefreshAtStartup = value; }
        }

        public static int RowHeight
        {
            get { return _rowHeight; }
            set { _rowHeight = value; }
        }

        public static string DeviceMapFilePath
        {
            get { return _deviceMapFilePath; }
        }

        public static string[] SerialDeviceNamePatterns
        {
            get { return _serialDeviceNamePatterns; }
            set 
            {
                if (value == null)
                    return;
                _serialDeviceNamePatterns = value;
                int minLen = 0xffffff;
                foreach (string name in _serialDeviceNamePatterns)
                {
                    if (name.Length < minLen)
                        minLen = name.Length;
                }
                _minSerialDeviceNamePatternLength = minLen;
            }
        }

        public static int MinSerialDeviceNamePatternLength
        {
            get { return _minSerialDeviceNamePatternLength; }
        }

        public static bool OwnerWithDomain
        {
            get { return _flagOwnerWithDomain; }
            set { _flagOwnerWithDomain = value; }
        }

        public static string[] AllSuspectProcessNames
        {
            get { return _allSuspectProcessNames; }
            set { _allSuspectProcessNames = value; }
        }

        public static void AddSuspectProcessName(string name)
        {
            if (_allSuspectProcessNames.Contains(name))
                return;

            string[] newArr = new string[_allSuspectProcessNames.Length + 1];
            Array.Copy(_allSuspectProcessNames, newArr, _allSuspectProcessNames.Length);
            newArr[newArr.Length - 1] = name;
        }

        public static void RemoveSuspectProcessName(string name)
        {
            if (!_allSuspectProcessNames.Contains(name))
                return;

            string[] newArr = new string[_allSuspectProcessNames.Length - 1];
            int j = 0;
            for (int i = 0; i < _allSuspectProcessNames.Length; i++)
            {
                if (_allSuspectProcessNames[i] != name)
                    newArr[j++] = _allSuspectProcessNames[i];
            }
            return;
        }

        public static void LoadGlobalConfig()
        {
            string path = "config\\com_owner_spy_global.dat";
            StreamReader reader = null;
            try
            {
                reader = File.OpenText(path);
            }
            catch
            {
                return;
            }

            string line;
            ComHandle.Clear();
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (line.StartsWith("Ports:"))
                {
                    string[] ports = line.Substring("Ports:".Length).Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string p in ports)
                    {
                        ComHandle.Add(new ComItem(p));
                    }
                }
                else if (line.StartsWith("SuspectProcessNames:"))
                {
                    string[] names = line.Substring("SuspectProcessNames:".Length).Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    _allSuspectProcessNames = names;
                }
                else if (line.StartsWith("SerialDeviceNamePatterns:"))
                {
                    string[] names = line.Substring("SerialDeviceNamePatterns:".Length).Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    _serialDeviceNamePatterns = names;
                }
                else if (line.StartsWith("RowHeight:"))
                {
                    try
                    {
                        _rowHeight = int.Parse(line.Substring("RowHeight".Length));
                        if (_rowHeight < 10 || _rowHeight > 48)
                            _rowHeight = 24;
                    }
                    catch
                    {
                        _rowHeight = 24;
                    }
                }
                else if (line.StartsWith("EnableAutoRefreshAtStartup:"))
                {
                    bool val = false;
                    try
                    {
                        val = bool.Parse(line.Substring("EnableAutoRefreshAtStartup:".Length));
                    }
                    catch
                    {
                        val = false;
                    }
                    _enableAutoRefreshAtStartup = val;
                }
                else if (line.StartsWith("AutoRefreshInternval:"))
                {

                    int val = 30;
                    try
                    {
                        val = int.Parse(line.Substring("AutoRefreshInternval:".Length));
                    }
                    catch
                    {
                        val = 30;
                    }
                    _autoRefreshInternval = val; ;
                }
                else if (line.StartsWith("OwnerShowFormat:"))
                {
                    string str = line.Substring("OwnerShowFormat:".Length);
                    _ownerShowFmt = Utility.ParseOwnerShowFormat(str);
                }
                else if (line.StartsWith("#End Data#"))
                    break; //end of config file
            }

            reader.Close();
        }

        public static void SaveGlobalConfig()
        {
            string path = "config\\com_owner_spy_global.dat";
            if (!Directory.Exists(".\\config"))
            {
                Directory.CreateDirectory(".\\config");
            }
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine("Version:" + Application.ProductVersion);
            writer.WriteLine("Ports:" + string.Join(",", ComHandle.GetAllPorts()));
            writer.WriteLine("SuspectProcessNames:" + string.Join(",", _allSuspectProcessNames));
            writer.WriteLine("SerialDeviceNamePatterns:" + string.Join(",", _serialDeviceNamePatterns));
            writer.WriteLine("RowHeight:" + _rowHeight.ToString());
            writer.WriteLine("EnableAutoRefreshAtStartup:" + _enableAutoRefreshAtStartup.ToString());
            writer.WriteLine("AutoRefreshInternval:" + _autoRefreshInternval.ToString());
            writer.WriteLine("OwnerShowFormat:" + _ownerShowFmt.ToString().ToLower());
            writer.WriteLine("#End Data#");
            writer.Flush();
            writer.Close();
        }
    }
}
