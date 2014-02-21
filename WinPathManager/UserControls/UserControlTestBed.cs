using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinPathManager.Helper;

namespace WinPathManager.UserControls
{
    public partial class UserControlTestBed : UserControl
    {
        private PathManager _pathManager = PathManager.PathManagerInstance;
        public UserControlTestBed()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor ;
            string s = _pathManager.CurrentPathText;
            s += @";h:\xyz;h:\xyz;h:\abc;";
            _pathManager.SaveProgramPath(s);
            _pathManager.Refresh();
            Cursor.Current = Cursors.Default;

        }
    }
}
