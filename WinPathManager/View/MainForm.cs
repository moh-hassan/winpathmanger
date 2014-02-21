using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MvvmFx.Windows.Input;
using NLog;
using WinPathManager.Helper;
using WinPathManager.ViewModel;


namespace WinPathManager
{
    public partial class MainForm : Form
    {

        PathManager _pathManager = PathManager.PathManagerInstance;
         
        public MainFormViewModel ViewModel; 
        //private BindingManager _bindingManager = new BindingManager();
        //commands
        public BoundCommand AddEntryCommand, RemoveEntryCommand, ExportCommand, PathTextCommand, RefreshCommand;

        private CommandBindingManager commandBindingManager = new CommandBindingManager();
        private static Logger _logger = LogManager.GetCurrentClassLogger();
         


        public MainForm()
        {
            InitializeComponent();
            ViewModel = new MainFormViewModel();
            _pathManager.Load();
            BindCommands();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            tabControl1.SelectedTab = tabPage1;
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
             
            TestFolder();
             

            toolStripStatusLabel1.Text = string.Format("Computer Name: {0}  Current User:{1} ", Environment.MachineName, Environment.UserName);
        }

         

        void BindCommands()
        {
            var commands = new Dictionary<object, Action<object>>
                {
                  {addNewEntryToolStripMenuItem,o=> tabControl1.SelectedTab = tabPage2}  ,
                  {AddToolStripButton, o => tabControl1.SelectedTab = tabPage2} ,
                  {exitToolStripMenuItem, o=>Application.Exit()},
                  {TextViewToolStripButton ,o=> tabControl1.SelectedTab =  tabPage4} ,
                  {RemoveToolStripButton, o=>tabControl1.SelectedTab = tabPage3},
                  {ListViewToolStripButton, o=>tabControl1.SelectedTab = tabPage1},
                  {RefreshToolStripButton, o=>_pathManager.Refresh()},
                  {ExportToolStripButton,o=>_pathManager.ExportToFile()},
                  {exportPathToFileToolStripMenuItem,o=>_pathManager.ExportToFile()}

                };

            foreach (var command in commands)
            {
                commandBindingManager.RegisterCommand(command.Key, command.Value);
            }

            // commandBindingManager.AddCommand(ViewModel .PathTextCommand , TextViewToolStripButton);


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
                    _logger.Info("Application Exit");
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


    }//
}//