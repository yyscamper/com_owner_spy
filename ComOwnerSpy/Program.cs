﻿using System;
using System.Collections;
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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //build "Device Map" from registry
            try
            {
                ComPortControlTable.InitTable(); 
            }
            catch (Exception err)
            {
                yMessageBox.ShowError(null, err.Message);
                return;
            }

            //load config file
            try
            {
                OwnerTranslate.LoadFromFile();
                AppConfig.LoadGlobalConfig();
                ThemeManager.Init();
            }
            catch //if config file has error, just ignore it, we will use the default setting
            {
            }

            Application.Run(new FormMain());
        }
    }
}
