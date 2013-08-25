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

        public static void Init()
        {
            for (int i = 1; i < 100; i++)
            {
                ComItem item = new ComItem();
                item.Port = i.ToString();
                ComHandle.Add(item);
            }
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
            writer.WriteLine("#End Data#");
            writer.Flush();
            writer.Close();
        }
    }
}
