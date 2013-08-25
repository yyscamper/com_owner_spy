using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace ComOwnerSpy
{
    static public class  DeviceMapTable
    {
        private static Dictionary<string, string> _tblDevicePort; //Key: DeviceName, Value: Port
        private static Dictionary<string, string> _tblPortDevice; //Key: Port, Value: DeviceName
        private static IProgressEvent _progressHandle = null;

        static DeviceMapTable()
        {
            _tblDevicePort = new Dictionary<string, string>();
            _tblPortDevice = new Dictionary<string, string>();
        }

        static IProgressEvent ProgressEvent
        {
            get { return _progressHandle; }
            set { _progressHandle = value; }
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

        public static string GetDevice(string port)
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

        public static void Load(string path)
        {
            StreamReader fs = null;
            try
            {
                fs = File.OpenText(path);
                fs.ReadLine(); //version number
                Clear();
                while (!fs.EndOfStream)
                {
                    string line = fs.ReadLine();
                    int idx = line.IndexOf(':');
                    if (idx > 0 || idx < (line.Length - 1))
                    {
                        Add(line.Substring(0, idx), line.Substring(idx + 1));
                    }
                }
            }
            catch
            {
                Clear();
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        public static void BuildTable(ArrayList allPorts, ref ArrayList errorPortsInfo)
        {
            ArrayList errPorts = new ArrayList();

            if (_progressHandle != null)
            {
                _progressHandle.ProgressSet(0, allPorts.Count);
                _progressHandle.ProgressUpdate(0);
            }

            ProcessFileHandle proc = new ProcessFileHandle(System.Diagnostics.Process.GetCurrentProcess().Id);
            Clear();

            for (int i = 0; i < allPorts.Count; i++)
            {
                string port = (string)allPorts[i];
                try
                {
                    SerialPort sp = new SerialPort("COM" + port);
                    sp.Open();
                    ArrayList handles = proc.GetComFileHandle();
                    if (handles != null && handles.Count > 0)
                    {
                        Add(port, handles[0].ToString());
                    }
                    sp.Close();
                }
                catch
                {
                    /*
                    if (port >= 29 && port <= 92)
                    {
                        _table.Add("\\Device\\mxuport00" + (port-29).ToString("D2"), port.ToString());
                    }
                    */
                    errPorts.Add(port);
                }
                finally
                {
                    if (_progressHandle != null)
                        _progressHandle.ProgressUpdate(i + 1);
                }
            }
            errorPortsInfo = errPorts;
        }

        public static void BuildTableFile(string path, ArrayList allPorts, ref ArrayList errorPortsInfo)
        {
            StreamWriter sw = new StreamWriter(path);
            BuildTable(allPorts, ref errorPortsInfo);
            sw.WriteLine("version=1.0");
            foreach (string key in _tblPortDevice.Keys)
            {
                sw.WriteLine(key + ":" + _tblPortDevice[key]);
            }
            sw.Flush();
            sw.Close();
        }
    }
}
