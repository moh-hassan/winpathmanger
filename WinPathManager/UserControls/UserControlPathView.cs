using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Input;
using PathUtilty;
using WinPathManager.Helper;
//using WinPathManager.ViewModel;
using WinPathManager.ViewModel;
using Binding = MvvmFx.Windows.Data.Binding;
/********************************************************************************************************
 * 
 * WinPath Manager
 * Copyright 2014 Mohamed Hassan 
 * Apache License 2.0 (Apache)
 * 
 * https://pathmanger.codeplex.com/
  * 
 ******************************************************************************************************/



namespace WinPathManager
{
    public partial class UserControlPathView : UserControl //BaseUserControl //
    {
        private  PathManager _pathManager = PathManager.PathManagerInstance;
        private CommandBindingManager commandBindingManager = new CommandBindingManager();
        private BindingManager _bindingManager= new BindingManager( );
        private PathEditorViewModel viewModel;  
        private string BackupFolder = "backup";
        private string AppPath;
     
 

        public object DataSource
        {
            get
            {
                return this.listBoxCurrentPath.DataSource;
            }
            set
            {
                if (DataSource != value)
                {
                    listBoxCurrentPath.DataSource = value;
                }
            }
        }

         
         
        public UserControlPathView()
        {
            InitializeComponent(); // 
            viewModel = new PathEditorViewModel(); // (DataSource);

        }


       
        private void UserControlPathView_Load(object sender, EventArgs e)
        {
            AddBindings();
            BindCommands();
          
           
           // _pathManager.AddEntry += _pathManager_AddEntry;
           // _pathManager.RemoveEntry += _pathManager_AddEntry;
            _pathManager.PathChanged += _pathManager_PathChanged;
            radioButton1.PerformClick();
          
        }

        void AddBindings()
        {
           // _bindingManager = new BindingManager();
            _bindingManager.Bindings.Add(new Binding(labelPathLength, "Text",viewModel._pathManager, "PathSummary"));
            _bindingManager.Bindings.Add(new Binding(labelPathLength, "ForeColor",viewModel. _pathManager, "PathSummaryColor"));
            _bindingManager.Bindings.Add(new Binding(buttonRepair, "Enabled",viewModel. _pathManager, "CanRepair"));
          //  _bindingManager.Bindings.Add(new Binding(radioButton2, "Enabled", viewModel._pathManager, "IsDuplicated"));


            DataSource = viewModel.bs ;
        }

        void BindCommands()
        {
            commandBindingManager.RegisterCommand(viewModel.RepairPathCommand, buttonRepair);
            commandBindingManager.RegisterCommand(viewModel.FillAllCommand, radioButton1);
            commandBindingManager.RegisterCommand(viewModel.FillDuplicatedCommand, radioButton2);
            commandBindingManager.RegisterCommand(viewModel.FillNotExistCommand, radioButton3);

        }

        private void _pathManager_PathChanged(object sender, PathManagerEventArgs e)
        {

            radioButton2.Enabled = _pathManager.DublicatedList.Count > 0;
            radioButton3.Enabled = _pathManager.NotExistList.Count > 0;
           // viewModel.bs.ResetBindings(false );
            DataSource = null;
            DataSource = viewModel.GetActiveList();
        }

        //void ManageRadioButtons()
        //{
        //    switch (viewModel.ActiveList )
        //    {
        //        case 1:
        //            break;
        //        case 2:
        //            break;
        //        case 3:
        //            radioButton3.PerformClick();
        //            break;
        //    }
        //}

    } //
}//

