using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestForm
{
    internal static class Program
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LOGGER.Info("Start...");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            LOGGER.Info("End...");
        }
    }
}
