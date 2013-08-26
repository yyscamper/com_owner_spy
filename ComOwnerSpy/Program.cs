using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComOwnerSpy
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string mapFilePath = System.Environment.CurrentDirectory + "\\config\\serial_devices.map";
                if (!System.IO.File.Exists(mapFilePath))
                {
                    yMessageBox.ShowError(null, "Cannot find the file \"" + mapFilePath + "\", this is must for ComOwnerSpy to run, please copy one to that directory.");
                    return;
                }
                DeviceMapTable.Load("config\\serial_devices.map");
                AppConfig.LoadGlobalConfig();
            }
            catch
            {

            }
            Application.Run(new bntSetting());
        }
    }
}
