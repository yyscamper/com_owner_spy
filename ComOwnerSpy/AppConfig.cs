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
        private static string[] _allSuspectProcessNames = new string[] { "SecureCRT", "ttermpro", "Multy-Term" };
        private static bool _flagOwnerWithDomain = true;
        private static string[] _serialDeviceNamePatterns = new string[] { "\\Device\\Serial", "\\Device\\mxuport" };
        private static int _minSerialDeviceNamePatternLength = Math.Min("\\Device\\Serial".Length, "\\Device\\mxuport".Length);
        private static string _deviceMapFilePath;
        private static int _rowHeight = 24;

        static AppConfig()
        {
            _deviceMapFilePath = System.Environment.CurrentDirectory + "\\config\\serial_devices.map";
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
            writer.WriteLine("#End Data#");
            writer.Flush();
            writer.Close();
        }
    }
}
