using System;
using System.Windows.Forms;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Input;
using NLog;
using WinPathManager.Helper;
using WinPathManager.ViewModel;

namespace WinPathManager
{
    public partial class DelPath : Form
    {
        private PathManager _pathManager = new PathManager();
        public DelPathViewModel ViewModel = new DelPathViewModel();
        private BindingManager _bindingManager = new BindingManager();
        private CommandBindingManager commandBindingManager = new CommandBindingManager();
        private static Logger _logger = LogManager.GetCurrentClassLogger();


        //load event
        public DelPath()
        {
            InitializeComponent();
            OnInitializeBinding();
            BindCommands();
            Load += OnLoad;
            // checkedListBox1.DataSource = _pathManager.GetCurrentPathList();


        }

        protected void OnInitializeBinding()
        {
            FillList();
        }

        void BindCommands()
        {
            // commandBindingManager.AddCommand(ViewModel.RemoveCommand,buttonRemove);

        }

        private void OnLoad(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            //FillList();
            buttonRemove.Click += OnRemove;
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
                _pathManager.SaveProgramPath(newPath);
                MessageBox.Show("Sucess Removing  the Path", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _logger.Info("Remove: {0}", removedEntries);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                _logger.ErrorException("Error in Remove Entry: ", ex);
            }
            finally
            {
                //refresh list
                checkedListBox1.Items.Clear();
                FillList();
                // buttonRemove.Enabled = false;
                Cursor.Current = Cursors.Default;
            }


        }





        void FillList()
        {

            var CurrentPathList = _pathManager.GetCurrentPathList();
            foreach (string item in CurrentPathList)
                if (item != "") checkedListBox1.Items.Add(item);

        }


    }//
}
