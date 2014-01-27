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
";
            label1.Text = string.Format(s, Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
