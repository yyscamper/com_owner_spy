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
        private static bool _flagOwnerWithDomain;
        private static int _rowHeight;
        private static bool _enableAutoRefreshAtStartup;
        private static int _autoRefreshInternval;
        private static OwnerShowFormat _ownerShowFmt;
        private static string _curThemeName;
        static AppConfig()
        {
            ResetDefault();
        }

        public static void ResetDefault()
        {
            _flagOwnerWithDomain = true;
            _rowHeight = 24;
            _enableAutoRefreshAtStartup = true;
            _autoRefreshInternval = 10;
            _ownerShowFmt = OwnerShowFormat.FullName;
            _curThemeName = "default";
        }

        public static OwnerShowFormat OwnerFormat
        {
            get {return _ownerShowFmt; }
            set { _ownerShowFmt = value; }
        }

        public static String CurrentThemeName
        {
            get { return _curThemeName; }
            set { _curThemeName = value; }
        }
        public static int AutoRefreshInterval
        {
            get { return _autoRefreshInternval; }
            set { _autoRefreshInternval = value; }
        }

        public static bool EnableAutoRefresh
        {
            get { return _enableAutoRefreshAtStartup; }
            set { _enableAutoRefreshAtStartup = value; }
        }

        public static int RowHeight
        {
            get { return _rowHeight; }
            set { _rowHeight = value; }
        }

        public static bool OwnerWithDomain
        {
            get { return _flagOwnerWithDomain; }
            set { _flagOwnerWithDomain = value; }
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
            //ComHandle.Clear();
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (line.StartsWith("Ports:"))
                {
                    //string[] ports = line.Substring("Ports:".Length).Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //foreach (string p in ports)
                    //{
                    //    ComHandle.Add(new ComItem(p));
                    //}
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
                else if (line.StartsWith("CurrentThemeName:"))
                {
                    string str = line.Substring("CurrentThemeName:".Length);
                    _curThemeName = str;
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
            writer.WriteLine("RowHeight:" + _rowHeight.ToString());
            writer.WriteLine("EnableAutoRefreshAtStartup:" + _enableAutoRefreshAtStartup.ToString());
            writer.WriteLine("AutoRefreshInternval:" + _autoRefreshInternval.ToString());
            writer.WriteLine("OwnerShowFormat:" + _ownerShowFmt.ToString().ToLower());
            writer.WriteLine("CurrentThemeName:" + (_curThemeName == null ? "default" : _curThemeName));
            writer.WriteLine("#End Data#");
            writer.Flush();
            writer.Close();  
        }
    }
}
