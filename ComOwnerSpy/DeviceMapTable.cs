using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using Microsoft.Win32;

namespace ComOwnerSpy
{
    static public class  DeviceMapTable
    {
        private static Dictionary<string, string> _tblDevicePort; //Key: DeviceName, Value: Port
        private static Dictionary<string, string> _tblPortDevice; //Key: Port, Value: DeviceName

        static DeviceMapTable()
        {
            _tblDevicePort = new Dictionary<string, string>();
            _tblPortDevice = new Dictionary<string, string>();
        }

        public static Dictionary<string, string> RawTable
        {
            get { return _tblPortDevice; }
        }

        public static int Count
        {
            get { return (_tblDevicePort != null ? _tblDevicePort.Count : 0); }
        }

        public static string[] AllPorts
        {
            get { return (_tblPortDevice != null ? _tblPortDevice.Keys.ToArray() : null); }
        }

        public static string[] AllDeviceNames
        {
            get { return (_tblPortDevice != null ? _tblPortDevice.Values.ToArray() : null); }
        }

        public static bool ContainsDeviceName(string devName)
        {
            return _tblDevicePort.ContainsKey(devName) || _tblPortDevice.ContainsValue(devName);
        }

        public static bool ContainsPort(string port)
        {
            return _tblPortDevice.ContainsKey(port) || _tblDevicePort.ContainsValue(port);
        }

        public static void Remove(string port)
        {
            if (_tblPortDevice.ContainsKey(port))
            {        
                string devName = _tblPortDevice[port];
                _tblPortDevice.Remove(port);
                _tblDevicePort.Remove(devName);
            }
        }

        public static void Add(string port, string deviceName)
        {
            _tblDevicePort.Add(deviceName, port);
            _tblPortDevice.Add(port, deviceName);
        }

        public static void Clear()
        {
            _tblDevicePort.Clear();
            _tblPortDevice.Clear();
        }

        public static string GetPort(string deviceName)
        {
            if (_tblDevicePort.ContainsKey(deviceName))
                return _tblDevicePort[deviceName];
            else
                return null;
        }

        public static string GetDeviceName(string port)
        {
            if (_tblPortDevice.ContainsKey(port))
                return _tblPortDevice[port];
            else
                return null;
        }

        public static ArrayList GetPorts(ArrayList deviceNameList)
        {
            if (deviceNameList == null || deviceNameList.Count <= 0)
                return null;

            ArrayList al = new ArrayList();
            foreach (string name in deviceNameList)
            {
                if (_tblDevicePort.ContainsKey(name))
                {
                    al.Add(_tblDevicePort[name]);
                }
            }

            return al;
        }

        public static void BuildFromRegistry()
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
            SortedDictionary<uint, string> portTable = new SortedDictionary<uint, string>(); //sort keys by port number
            foreach (string name in valNames)
            {
                string val = (string)comKey.GetValue(name);
                try
                {
                    uint port = uint.Parse(val.Substring("COM".Length)); //extract the port number, remove "COM" prefix
                    portTable.Add(port, name);
                }
                catch
                {
                    continue;
                }
            }

            Clear();
            foreach (uint port in portTable.Keys)
            {
                string strPort = port.ToString();
                string val = portTable[port];
                Add(strPort, val);
            }
        }
    }
}
