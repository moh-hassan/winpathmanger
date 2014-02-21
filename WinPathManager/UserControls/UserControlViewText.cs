using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MvvmFx.Windows.Input;
using NLog;
using WinPathManager.Helper;
/********************************************************************************************************
 * 
 * WinPath Manager
 * Copyright 2014 Mohamed Hassan 
 * Apache License 2.0 (Apache)
 * 
 * https://pathmanger.codeplex.com/
  * 
 ******************************************************************************************************/


namespace WinPathManager.UserControls
{
    public partial class UserControlViewText : UserControl
    {
        PathManager _pathManager = PathManager.PathManagerInstance;
        public UserControlViewText()
        {
            InitializeComponent();
        }

        private void UserControlViewText_Load(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            textBox1.Text = _pathManager.CurrentPathText;
        }
    }
}
