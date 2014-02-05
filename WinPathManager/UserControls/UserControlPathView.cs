using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Input;
using WinPathManager;
using WinPathManager.ViewModel;


//using WindowsFormsToolkit.CommandManager;
//using WindowsFormsToolkit.MVVM;

namespace WinPathManager
{
    public partial class UserControlPathView : UserControl //BaseUserControl //
    {
        public PathEditorViewModel ViewModel = new PathEditorViewModel();
        private BindingManager _bindingManager;
        public string BackupFolder = "backup";
        public string AppPath;
        //   private CommandManager commandManager;
        private CommandBindingManager commandBindingManager = new CommandBindingManager();

        //private ErrorProvider errorProvider2 = new ErrorProvider();

        public UserControlPathView() //: this(new PathEditorViewModel() ) 
        {
            InitializeComponent();// 
            OnInitializeBinding();
            BindCommands();
            CreateBackupFolder();
        }

        //  public UserControlPathView()
        //public UserControlPathView(PathEditorViewModel viewModel):base(viewModel)
        //{
        //    InitializeComponent();//          
        //    BindCommands();
        //}

        //protected override void OnInitializeBinding()
        protected void OnInitializeBinding()
        {
            _bindingManager = new BindingManager();
            //_bindingManager.Bindings.Add(
            //   new TypedBinding<TextBox, PathEditorViewModel>(textBox1, t => t.Text, ViewModel, s => s.CurrentPathText));

            var v = new TypedBinding<Label, PathEditorViewModel>(labelPathLength, t => t.ForeColor, ViewModel,
                                                                    s => s.CurrentPathText);
             

            _bindingManager.Bindings.Add(
              new TypedBinding<Label, PathEditorViewModel>(labelPathLength, t => t.Text, ViewModel, s => s.PathSummary));

            //button buttonRepair
            _bindingManager.Bindings.Add(
             new TypedBinding<Button, PathEditorViewModel>(buttonRepair, t => t.Enabled, ViewModel, s => s.Over1023));



            listBoxCurrentPath.DataSource = ViewModel.bs;


        }

        void CreateBackupFolder()
        {
            //backup
            if (!Directory.Exists("backup"))
            {
                Directory.CreateDirectory("backup");
            }
        }
        void BindCommands()
        {


            var commandBindingRepair = new CommandBinding(ViewModel.RepairPathCommand, buttonRepair, "Click");
            commandBindingManager.CommandBindings.Add(commandBindingRepair);


            var commandBindingFillAll = new CommandBinding(ViewModel.FillAllCommand, radioButton1, "Click");
            commandBindingManager.CommandBindings.Add(commandBindingFillAll);

            var commandBindingDublicate = new CommandBinding(ViewModel.FillDuplicatedCommand, radioButton2, "Click");
            commandBindingManager.CommandBindings.Add(commandBindingDublicate);

            var commandBindingNotExist = new CommandBinding(ViewModel.FillNotExistCommand, radioButton3, "Click");
            commandBindingManager.CommandBindings.Add(new CommandBinding(ViewModel.FillNotExistCommand, radioButton3, "Click"));

            var commandBindingRefresh = new CommandBinding(ViewModel.RefreshCommand, buttonRefresh, "Click");
            commandBindingManager.CommandBindings.Add(commandBindingRefresh);


            

            //TODO: bind command of menu options
        }


        //TODO: exceptionhandling command manager,others
        //TODO: count/length of different lists
        //TODO: display uniqueList with Length/count



        void PathEditor_PathChange(object sender, EventArgs e)
        {
            //   MessageBox.Show("path change event");
            ShowInfo();
        }
        /*
        void PathEditor_PathOverLength(object sender, EventArgs e)
        {
           // MessageBox.Show("path over1023 event");
            //ShowInfo();
        }

        void PathEditor_PathRepairing(object sender, EventArgs e)
        {
           // MessageBox.Show("path repairing event");
            //ShowInfo();
        }

  */



        private void UserControlPathView_Load(object sender, EventArgs e)
        {
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            //this.errorProvider1.ContainerControl = this;

            //  Icon icon = EmbededResourceManager.GetIcon("sucess.ico");//new System.Drawing.Icon("tick.ico");
            //this.errorProvider2.Icon = icon ; 
            //this.errorProvider2.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            //-----------------

            //    ViewModel.PathChange += new EventHandler(PathEditor_PathChange);
            ShowInfo();
        }


        void ShowInfo()
        {
           // textBox1.BackColor = Color.White;
              labelPathLength.ForeColor = ViewModel.Over1023 ? Color.Red : Color.Black  ; ;
            radioButton1.Checked = true;
            buttonRepair.Enabled = ViewModel.Over1023;
            //ShowErrorProvider();
        }

         
        //private void ShowErrorProvider()
        //{
        //    {
        //        if (textBox1.Text.Length >1023)
        //        {
        //            errorProvider1.SetError(textBox1, "Path Exceed 1023 char");
        //        }
        //        else
        //        {
        //            errorProvider2.SetError(textBox1, "Path Is less 1023 char");
        //        }//if
        //    }
        //}

    }//


    //public class BaseUserControl : ControlView<PathEditorViewModel>
    //{
    //    public BaseUserControl() : this(new PathEditorViewModel()) { }

    //    public BaseUserControl(PathEditorViewModel viewModel)
    //        : base(viewModel)
    //    {
    //    }
    //}

}//
