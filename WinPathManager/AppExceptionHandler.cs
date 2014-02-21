
using System.Windows.Forms;
using System.Threading;
using System;
using NLog;

namespace WinPathManager
{
    public  class AppExceptionHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void ApplicationException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                
                DialogResult result = ShowException(e.Exception);

                if (result == DialogResult.Abort)
                    Application.Exit();
            }
            catch
            {
                // Fatal error, terminate program
                try
                {
                    MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        /// 
        /// Creates and displays the error message.
        /// 
        private DialogResult ShowException(Exception ex)
        {
            string errorMessage =
                "Unhandled Exception:\n\n" +
                "Please contact the developers with the following information:\n\n" +
                "Message: "+ ex.Message + "\n\n" +
                ex.GetType() +
                "\n\nStack Trace:\n" + ex.StackTrace;
            logger.Error(errorMessage);
            return MessageBox.Show(errorMessage, "Application Error", MessageBoxButtons.AbortRetryIgnore,
                                   MessageBoxIcon.Stop);
        }
    }
}