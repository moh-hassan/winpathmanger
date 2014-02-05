using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NLog;
using WinPathManager.Helper;

namespace WinPathManager
{
    public partial class Form1 : Form
    {
        private static   Logger logger = LogManager.GetCurrentClassLogger();
        public Form1()
        {
            InitializeComponent();
            //  Icon = GetExecutableIcon();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;


             
            // if (IsAdministrator()) MessageBox.Show("Ok admin");
            TestFolder();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //    tabControl1.ImageList = imageList1;
            //    tabPage1.ImageIndex = 0;
             
            toolStripStatusLabel1.Text = string.Format("Computer Name: {0}  Current User:{1} ", Environment.MachineName, Environment.UserName);
            // MessageBox.Show(statusStrip1.Text);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            var result = MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    logger.Info("Application Exit");
                    break;
            }
        }

        private void TestFolder()
        {
            string directoryString =
               Directory.GetCurrentDirectory() + @"\backup";
            //  Directory.CreateDirectory(directoryString);
            if (Directory.Exists(directoryString))
                Console.WriteLine("Directory \"{0}\" exists", directoryString);
            else
            {
                Console.WriteLine("Directory \"{0}\" does not exist", directoryString);
                Directory.CreateDirectory(directoryString);
            }


        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }

        private void userControlPathView1_Load(object sender, EventArgs e)
        {

        }

        private void addNewEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPath f = new AddPath();
            f.ShowDialog();
        }

        private void removeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelPath f = new DelPath();
            f.ShowDialog();
        }

        private void exportPathToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            PathManager pathManager = new PathManager();
          string  fname=  pathManager.ExportToFile();
          //  if (fname !=string .Empty )
            logger.Info("Export path to file: {0}",fname);
            //MessageBox.Show(fname);
        }

         
    }//
}//