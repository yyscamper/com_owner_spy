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
        private static readonly string  SERIAL_DEVICE_PATTERN1 = "\\Device\\VSerial";
        private static readonly string  SERIAL_DEVICE_PATTERN2 = "\\Device\\mxuport";

        public ProcessFileHandle(int procId)
        {
            _procId = procId;
        }

        public ArrayList ParseCmdStr(string strCmd)
        {
            ArrayList handleList = new ArrayList();
            int startIndex = 0;
            int idx1 = 0;
            int idx2 = 0;
            int lstart, lend;
            int idxColon = 0;
            int patternLen = ((SERIAL_DEVICE_PATTERN1.Length < SERIAL_DEVICE_PATTERN2.Length) ?
                                SERIAL_DEVICE_PATTERN1.Length : SERIAL_DEVICE_PATTERN2.Length);

            while (startIndex < strCmd.Length)
            {
                idx1 = strCmd.IndexOf(SERIAL_DEVICE_PATTERN1, startIndex);
                idx2 = strCmd.IndexOf(SERIAL_DEVICE_PATTERN2, startIndex);

                if (idx1 < 0)
                {
                    if (idx2 < 0)
                        break;
                    else
                        lstart = idx2;
                }
                else
                {
                    if (idx2 < 0)
                        lstart = idx1;
                    else
                        lstart = ((idx1 < idx2) ? idx1 : idx2);
                }

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
