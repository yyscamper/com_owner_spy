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
            int startIndex = 0;
            int idx = 0;
            int lstart, lend;
            int patternLen = AppConfig.MinSerialDeviceNamePatternLength;
            string[] allPatterns = AppConfig.SerialDeviceNamePatterns;

            while (startIndex < strCmd.Length)
            {
                lstart = 0xffffff;
                foreach (string pattern in allPatterns)
                {
                    idx = strCmd.IndexOf(pattern, startIndex);
                    if (idx >=0 && lstart > idx)
                    {
                        lstart = idx;
                    }
                }
                if (lstart == 0xffffff) //Don't find any patterns
                    break;

                lend = lstart + patternLen;
                while (true) //find the end of line "\r\n"
                {
                    if (lend == strCmd.Length - 1)
                        break;

                    if (strCmd[++lend] == '\r')
                        break;
                }
                handleList.Add(strCmd.Substring(lstart, lend-lstart));
                startIndex = lend + 2; //ignore the "\r\n"
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


            /*

            string[] cmdResultArr = strCmd.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);



            foreach (string str in cmdResultArr)
            {
                string[] itemArr = str.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (itemArr.Length > 2)
                {

                    string handleName = itemArr[itemArr.Length - 1];
                    if (handleName.StartsWith("\\Device\\", StringComparison.InvariantCultureIgnoreCase)
                        && (handleName.IndexOf("serial", StringComparison.InvariantCultureIgnoreCase) > 0
                        || handleName.IndexOf("mxuport", StringComparison.InvariantCultureIgnoreCase) > 0))
                    {
                        handleList.Add(handleName);
                    }
                }
            }
            return handleList;
             * 
             * */
        }

    }
}
