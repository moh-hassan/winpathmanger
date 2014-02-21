using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Input;
using NLog;
using WinPathManager.Helper;
using WinPathManager.ViewModel;
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
    public partial class UserControlRemoveEntry : UserControl
    {
        PathManager _pathManager = PathManager.PathManagerInstance;
        // private PathManager _pathManager = new PathManager();
        public DelPathViewModel ViewModel = new DelPathViewModel();
        private BindingManager _bindingManager = new BindingManager();
        private CommandBindingManager commandBindingManager = new CommandBindingManager();
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public object DataSource
        {
            get
            {
                return checkedListBox1.DataSource;
            }
            set
            {
                if (DataSource != value)
                {
                    checkedListBox1.DataSource = value;
                    //  OnDataSourceChanged();
                }
            }
        }

        public UserControlRemoveEntry()
        {
            InitializeComponent();
            OnInitializeBinding();
            BindCommands();
            Load += OnLoad;
            // checkedListBox1.DataSource = _pathManager.GetCurrentPathList();

        }

        protected void OnInitializeBinding()
        {
        }

        void BindCommands()
        {
            // commandBindingManager.AddCommand(ViewModel.RemoveCommand,buttonRemove);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            DataSource = _pathManager.CurrentPathList;
            buttonRemove.Click += OnRemove;


            _pathManager.PathChanged += _pathManager_PathChanged;
        }

        void _pathManager_PathChanged(object sender, PathManagerEventArgs e)
        {
            DataSource = null;
            DataSource = _pathManager.CurrentPathList;

        }
        //remove entries
        private void OnRemove(object sender, EventArgs e)
        {
            //check that there are selected items
            var n = checkedListBox1.CheckedItems.Count;
            if (n == 0)
            {
                MessageBox.Show("No entries is selected", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string newPath = "";
            string removedEntries = "";

            try
            {

                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    //if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                    if (!checkedListBox1.GetItemChecked(i))
                    {
                        //MessageBox.Show(checkedListBox1.Items[i] as string );
                        newPath += checkedListBox1.Items[i].ToString() + ";";

                    }
                    else
                    {
                        removedEntries += checkedListBox1.Items[i].ToString() + ";";
                    }
                }

                newPath = newPath.TrimEnd(';');
                //MessageBox.Show(s);
                //  var    msg = "The new path is " + Convert.ToString(size1) + Environment.NewLine;
                var msg2 = string.Format("Are you sure to Remove  the selected entries from the path( {0} entries)", n);
                var result2 = MessageBox.Show(msg2, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result2 == DialogResult.Cancel) return;
                Cursor.Current = Cursors.WaitCursor;
                // Environment.SetEnvironmentVariable("path", newPath, EnvironmentVariableTarget.Machine);
                newPath = newPath.TrimEnd(';');
                _pathManager.SaveProgramPath(newPath);
              
                _pathManager.CurrentPathText = newPath;
                MessageBox.Show("Sucess Removing  the entry: " + removedEntries, "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _pathManager.Init();
                _logger.Info("Remove: {0}", removedEntries);

            }
            catch (Exception ex)
            {
                _logger.ErrorException("Error in Remove Entry: ", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {

                Cursor.Current = Cursors.Default;
            }


        }

    }//
}

