using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WinPathManager
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            string s = @"
WinPath Manager version {0}
Copyright ©2014 Mohamed Hassan.
The program is distributed under the terms of 
the Apache License 2.0 (Apache).
https://pathmanger.codeplex.com/
";
            label1.Text = string.Format(s, Assembly.GetExecutingAssembly().GetName().Version);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
             

            //int boundWidth = Screen.PrimaryScreen.Bounds.Width;
            //int boundHeight = Screen.PrimaryScreen.Bounds.Height;
            //int x = boundWidth - this.Width;
            //int y = boundHeight - this.Height;
            //this.Location = new Point(x / 2, y / 2);

        }

         

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
