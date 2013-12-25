using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ComOwnerSpy
{
    public class ProcessFileHandle
    {
        int _procId = -1;

        public ProcessFileHandle(int procId)
        {
            _procId = procId;
        }

        public ArrayList ParseCmdStr(string strCmd)
        {
            ArrayList handleList = new ArrayList();

            string[] devNames = DeviceMapTable.AllDeviceNames;
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

        public ArrayList GetComFileHandle()
        {
            ArrayList handleList = new ArrayList();

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

            return ParseCmdStr(strCmd);
        }

    }
}
