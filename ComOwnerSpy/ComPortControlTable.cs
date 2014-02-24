using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    static public class  ComPortControlTable
    {
        private static Dictionary<string, ComPortItem> _tableByDeviceName = null; //key: Device Name
        private static Dictionary<string, ComPortItem> _tableByPortName = null; //Key: Port Name
        private static List<string> _deviceNamePatterns; //Patterns list

        static ComPortControlTable()
        {
            _tableByDeviceName = new Dictionary<string, ComPortItem>();
            _tableByPortName = new Dictionary<string, ComPortItem>();
        }

        public static int Count
        {
            get { return (_tableByDeviceName != null ? _tableByDeviceName.Count : 0); }
        }

        public static string[] AllPortNames
        {
            get { return (_tableByPortName != null ? _tableByPortName.Keys.ToArray() : null); }
        }

        public static string[] AllDeviceNames
        {
            get { return (_tableByDeviceName != null ? _tableByDeviceName.Keys.ToArray() : null); }
        }

        public static ComPortItem[] AllItems
        {
            get { return (_tableByPortName != null ? _tableByPortName.Values.ToArray() : null); }
        }

        public static List<string> DeviceNamePatterns
        {
            get { return _deviceNamePatterns; }
        }

        public static string GetPortName(string deviceName)
        {
            if (_tableByDeviceName.ContainsKey(deviceName))
                return _tableByDeviceName[deviceName].PortName;
            else
                return null;
        }

        public static string GetDeviceName(string port)
        {
            if (_tableByPortName.ContainsKey(port))
                return _tableByPortName[port].DeviceName;
            else
                return null;
        }

        public static ComPortItem GetItemByPortName(string portName)
        {
            return (_tableByPortName.ContainsKey(portName) ? _tableByPortName[portName] : null);
        }

        public static ComPortItem GetItemByDevieName(string devName)
        {
            return (_tableByDeviceName.ContainsKey(devName) ? _tableByDeviceName[devName] : null);
        }

        public static ArrayList GetPorts(ArrayList deviceNameList)
        {
            if (deviceNameList == null || deviceNameList.Count <= 0)
                return null;

            ArrayList al = new ArrayList();
            foreach (string name in deviceNameList)
            {
                if (_tableByDeviceName.ContainsKey(name))
                {
                    al.Add(_tableByDeviceName[name]);
                }
            }

            return al;
        }
        public static void ResetDetectedFlag()
        {
            foreach (ComPortItem item in _tableByPortName.Values)
            {
                item.DetectedFlag = false;
            }
        }

        public static List<ComPortItem> GetOtherPortsInSameProcess(ComPortItem item)
        {
            if (item.OwnProcessId < 0)
                return null;

            List<ComPortItem> listPorts = new List<ComPortItem>();
            foreach (ComPortItem ci in _tableByPortName.Values)
            {
                if (ci.PortName != item.PortName && item.OwnProcessId == ci.OwnProcessId)
                    listPorts.Add(ci);
            }

            return listPorts;
        }

        public static void InitTable()
        {
            RegistryKey key = Registry.LocalMachine;
            RegistryKey comKey = null;
            try
            {
                comKey = key.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
                if (comKey == null)
                    throw new Exception("Cannot find the serial port device map from registry \"HARDWARE\\DEVICEMAP\\SERIALCOMM\"!");
            }
            catch
            {
                throw new Exception("Cannot find the serial port device map from registry \"HARDWARE\\DEVICEMAP\\SERIALCOMM\"!");
            }

            string[] valNames = comKey.GetValueNames();

            //As we need the table is sorted by port integer number, so here we need create such sorted dictionary.
            SortedDictionary<uint, string> portTable = new SortedDictionary<uint, string>();

            foreach (string name in valNames)
            {
                string val = (string)comKey.GetValue(name);
                try
                {
                    uint port = uint.Parse(val.Substring("COM".Length)); //extract the port integer number, remove "COM" prefix
                    portTable.Add(port, name);
                }
                catch
                {
                    continue;
                }
            }

            _tableByDeviceName.Clear();
            _tableByPortName.Clear();

            foreach (uint port in portTable.Keys)
            {
                string thePortName = "COM" + port.ToString();
                string theDeviceName = portTable[port];
                ComPortItem item = new ComPortItem(thePortName, theDeviceName);
                _tableByDeviceName.Add(theDeviceName, item);
                _tableByPortName.Add(thePortName, item);
            }

            _deviceNamePatterns = ExtractDeviceNamePatterns();
        }

        private static List<string> ExtractDeviceNamePatterns()
        {
            List<string> patternlist = new List<string>();

            foreach (string str in _tableByDeviceName.Keys)
            {
                if (!str.StartsWith("\\Device\\"))
                    continue;

                int n = str.Length - 1;
                while (n >= 0 && str[n] >= '0' && str[n] <= '9')
                    n--;
                if (n > 0)
                {
                    string pattern = str.Substring(0, n + 1);
                    if (!patternlist.Contains(pattern))
                    {
                        patternlist.Add(pattern);
                    }
                }
            }

            return patternlist;
        }

        static public void RefreshAll()
        {
            ResetDetectedFlag();

            //Get all processes that are opening serial port by utility "handle"
            List<ProcessOwnInfo> listOwnProcesses =
                HandleWrapper.GetAllOwnProcesses(ComPortControlTable.DeviceNamePatterns);
            if (listOwnProcesses == null)
                return;

            //Usually, one process often opens more than one serial port, so here creats the dictionary
            //to store the process that have known its owner, so as not to search process owner twice.
            Dictionary<int, string> procOwnerTable = new Dictionary<int, string>(); //key: process ID; value: owner
            foreach (ProcessOwnInfo pinfo in listOwnProcesses)
            {
                string owner = null;
                string procName = null;

                Application.DoEvents();

                //here map the device name to serial port name
                ComPortItem citem = ComPortControlTable.GetItemByDevieName(pinfo.DeviceName);
                if (citem == null)
                    continue;

                //We have searched the process owner before, we just copy its result,
                //so as not to search twice.
                if (procOwnerTable.ContainsKey(pinfo.ProcessId))
                {
                    owner = procOwnerTable[pinfo.ProcessId];
                }
                else
                {
                    //We havn't searched the process owner before 
                    string sid = null;
                    owner = ProcessOwnerFinder.GetProcessOwnerByPID(pinfo.ProcessId, out sid);
                    if (owner == null) //search owner failed
                        continue;
                    procOwnerTable.Add(pinfo.ProcessId, owner);
                }

                procName = pinfo.ProcessName;
                //if the process name have suffix ".exe", we just remove it to have nice format data show to user.
                int exeindex = pinfo.ProcessName.LastIndexOf(".exe");
                if (exeindex > 0)
                {
                    procName = pinfo.ProcessName.Substring(0, exeindex); //remove the suffix ".exe"
                }

                //update the serial port info as we get all result.
                if (citem.Update(owner, procName, pinfo.ProcessName + " (" + pinfo.ProcessId + ")", pinfo.ProcessId))
                {
                    citem.GuiItem.SubItems[1].Text = citem.FormatedOwner;
                    citem.GuiItem.SubItems[2].Text = citem.OwnAppName;
                    citem.GuiItem.SubItems[3].Text = citem.OwnDetailProcessInfo;
                }
                citem.DetectedFlag = true; //mark the serial port is detected be opened.
            }

            //handle other serial ports that is not opening, so reset the info to empty.
            ComPortItem[] allItems = ComPortControlTable.AllItems;
            foreach (ComPortItem item in allItems)
            {
                if (item.GuiItem != null && !item.DetectedFlag)
                {
                    item.ClearContent();
                }
            }
        }
    }
}
