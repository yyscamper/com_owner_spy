using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ComOwnerSpy
{
    public class ProcessOwnInfo
    {
        public string ProcessName;
        public int ProcessId;
        public string DeviceName;


        public ProcessOwnInfo(string name, int id, string handle)
        {
            this.ProcessName = name;
            this.ProcessId = id;
            this.DeviceName = handle;
        }
    }
    public class HandleWrapper
    {
        int _procId = -1;

        public HandleWrapper(int procId)
        {
            _procId = procId;
        }

        public ArrayList ParseCmdStr(string strCmd)
        {
            ArrayList handleList = new ArrayList();

            string[] devNames = ComPortControlTable.AllDeviceNames;
            foreach (string devName in devNames)
            {
                int idx = strCmd.IndexOf(devName, 0);
                if (idx >= 0 && (strCmd[idx + devName.Length] == '\r' || strCmd[idx + devName.Length] == '\n'))
                {
                    handleList.Add(devName);
                }
            }

            return handleList;
        }

        private static string ExecuteCommand(string arg)
        {
            Process cmdProc = new Process();
            cmdProc.StartInfo.FileName = "handle.exe";
            cmdProc.StartInfo.Arguments = arg;
            cmdProc.StartInfo.UseShellExecute = false;
            //cmdProc.StartInfo.RedirectStandardInput = true;
            cmdProc.StartInfo.RedirectStandardOutput = true;
            //cmdProc.StartInfo.RedirectStandardError = true;
            cmdProc.StartInfo.CreateNoWindow = true;
            cmdProc.Start();
            //cmdProc.StandardInput.AutoFlush = true;

            //cmdProc.StandardInput.WriteLine(cmd);
            //cmdProc.StandardInput.WriteLine("exit");
            cmdProc.WaitForExit();
            string strCmd = cmdProc.StandardOutput.ReadToEnd();
            cmdProc.Close();
            return strCmd;
        }

        private static string ExecuteCommand(List<string> patterns)
        {
            Process cmdProc = new Process();
            cmdProc.StartInfo.FileName = "cmd.exe";
            cmdProc.StartInfo.UseShellExecute = false;
            cmdProc.StartInfo.RedirectStandardInput = true;
            cmdProc.StartInfo.RedirectStandardOutput = true;
            cmdProc.StartInfo.RedirectStandardError = true;
            cmdProc.StartInfo.CreateNoWindow = true;
            cmdProc.Start();
            cmdProc.StandardInput.AutoFlush = true;

            foreach (string s in patterns)
            {
                cmdProc.StandardInput.WriteLine("handle -a " + s);
            }
            cmdProc.StandardInput.WriteLine("exit");
            string strCmd = cmdProc.StandardOutput.ReadToEnd();
            cmdProc.WaitForExit();
            cmdProc.Close();

            return strCmd;
        }

        public ArrayList GetComFileHandle()
        {
            ArrayList handleList = new ArrayList();

            string strCmd = ExecuteCommand("handle -a -p " + _procId);

            /*
            Process cmdProc = new Process();
            cmdProc.StartInfo.FileName = "cmd.exe";
            cmdProc.StartInfo.UseShellExecute = false;
            cmdProc.StartInfo.RedirectStandardInput = true;
            cmdProc.StartInfo.RedirectStandardOutput = true;
            cmdProc.StartInfo.RedirectStandardError = true;
            cmdProc.StartInfo.CreateNoWindow = true;
            cmdProc.Start();
            cmdProc.StandardInput.AutoFlush = true;

            cmdProc.StandardInput.WriteLine("handle -a -p " + _procId);
            cmdProc.StandardInput.WriteLine("exit");
            string strCmd = cmdProc.StandardOutput.ReadToEnd();
            cmdProc.WaitForExit();
            cmdProc.Close();
            */
            return ParseCmdStr(strCmd);
        }

        public static List<ProcessOwnInfo> GetAllOwnProcesses(List<string> patterns)
        {
            List<ProcessOwnInfo> listInfo = new List<ProcessOwnInfo>();

            /*
            StringBuilder cmdSb = new StringBuilder();
            foreach (string s in patterns)
            {
                if (cmdSb.Length != 0)
                    cmdSb.Append(" & ");
                cmdSb.Append("handle -a \"" + s + "\"");
            }
            */
            string result = ExecuteCommand(patterns);
            string[] strLines = result.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 4; i < strLines.Length; i++)
            {
                string[] rowItems = strLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (rowItems.Length != 7)
                    continue;

                if (rowItems[1] != "pid:"
                    || rowItems[3] != "type:"
                    || rowItems[4] != "File")
                {
                    continue;
                }

                int procId = 0;
                try
                {
                    procId = int.Parse(rowItems[2]);
                }
                catch
                {
                    continue;
                }

                ProcessOwnInfo phi = new ProcessOwnInfo(rowItems[0], procId, rowItems[6]);
                listInfo.Add(phi);
            }


            return listInfo;
        }

    }
}
