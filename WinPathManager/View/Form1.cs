using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinPathManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //  Icon = GetExecutableIcon();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TestFolder();
            MaximizeBox = false;
            MinimizeBox = false;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            tabControl1.ImageList = imageList1;
            tabPage1.ImageIndex = 0;

            //center form
            int boundWidth = Screen.PrimaryScreen.Bounds.Width;
            int boundHeight = Screen.PrimaryScreen.Bounds.Height;
            int x = boundWidth - this.Width;
            int y = boundHeight - this.Height;
            this.Location = new Point(x / 2, y / 2);
            toolStripStatusLabel1.Text = string .Format( "Computer Name: {0}  Current User:{1} " ,Environment.MachineName , Environment.UserName);
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
            switch (result )
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private    void TestFolder()
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
    }//
}//
