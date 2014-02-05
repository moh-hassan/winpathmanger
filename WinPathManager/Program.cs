using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NLog;

namespace WinPathManager
{
    static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Subscribe to thread (unhandled) exception events
            AppExceptionHandler handler = new AppExceptionHandler();

            Application.ThreadException +=new ThreadExceptionEventHandler(handler.ApplicationException);
           
            logger.Info("Apllication Start");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new DelPath());

        }
    }
}
