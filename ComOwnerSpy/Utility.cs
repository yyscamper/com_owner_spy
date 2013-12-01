using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    public static class Utility
    {
        public static string GetProcessOwner(int processId, bool ownerWithDomain = true)
        {
            if (processId <= 0)
                return null;

            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectCollection processList = null;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                processList = searcher.Get();
            }
            catch
            {
                return null;
            }

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    if (ownerWithDomain)
                        return argList[1] + "\\" + argList[0]; // return DOMAIN\user
                    else
                        return argList[0];
                }
            }

            return "NO OWNER";
        }

        public static string GetPortOwner(string targetPort, ref string appName, ref Process ownProcess)
        {
            List<Process> listProcs = new List<Process>();

            Process[] allSecureCrtProcess = Process.GetProcessesByName("SecureCRT");
            Process[] allTeraTermProcess = Process.GetProcessesByName("ttermpro");
            Process[] allMultyTermProcess = Process.GetProcessesByName("Multy-Term");

            listProcs.AddRange(allSecureCrtProcess);
            listProcs.AddRange(allTeraTermProcess);
            listProcs.AddRange(allMultyTermProcess);

            foreach (Process proc in listProcs)
            {
                ArrayList handles = new ProcessFileHandle(proc.Id).GetComFileHandle();
                ArrayList ports = DeviceMapTable.GetPorts(handles);
                foreach (string port in ports)
                {
                    if (port == targetPort)
                    {
                        try
                        {
                            string owner = Utility.GetProcessOwner(proc.Id);
                            if (allSecureCrtProcess.Contains(proc))
                                appName = "SecureCRT";
                            else if (allTeraTermProcess.Contains(proc))
                                appName = "TeraTerm";
                            else if (allMultyTermProcess.Contains(proc))
                                appName = "Multy-Term";
                            else
                                appName = "???";
                            ownProcess = proc;
                            return owner;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            return null;
        }

        public static DialogResult ShowErrorDialog(string txt)
        {
            return MessageBox.Show(txt, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowInfoDialog(string txt)
        {
            return MessageBox.Show(txt, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ValidateDomainUser(string str) //validate whether the string is valid domain\user input
        {
            char[] seps = new char[] {'\\', '/'};

            if (str == null || str.Length < 3)
                return false;
            int sindex = str.IndexOfAny(seps);
            int eindex = str.LastIndexOfAny(seps);

            return (sindex > 0 && sindex == eindex && sindex < str.Length - 1); //Only on seprator
        }

        public static OwnerShowFormat ParseOwnerShowFormat(string str)
        {
            str = str.ToLower();
            if (str == "default")
                return OwnerShowFormat.Default;
            else if (str == "domainuser")
                return OwnerShowFormat.DomainUser;
            else if (str == "fullname")
                return OwnerShowFormat.FullName;
            else if (str == "shortname")
                return OwnerShowFormat.ShortName;
            else if (str == "phone")
                return OwnerShowFormat.Phone;
            else
                return OwnerShowFormat.Default;
        }
    }
}
