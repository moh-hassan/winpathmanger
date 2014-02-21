using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BusinessObjects;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Input;
using PathUtilty;
using WinPathManager.Helper;
using Binding = System.Windows.Forms.Binding;
/********************************************************************************************************
 * 
 * WinPath Manager
 * Copyright 2014 Mohamed Hassan 
 * Apache License 2.0 (Apache)
 * 
 * https://pathmanger.codeplex.com/
 * 
 ******************************************************************************************************/
 
namespace WinPathManager.ViewModel
{

    public class PathEditorViewModel : BusinessObject
    {
        public  PathManager _pathManager = PathManager.PathManagerInstance;
       public  BindingSource bs = new BindingSource();
       public int ActiveList { get; set; }
        private string BackupFolder = "backup";
        private string AppPath;
      //  private BindingManager _bindingManager;
        //public object DataSource; //=new object();


        public PathEditorViewModel() //(object dataSource)
        {
         //   DataSource = dataSource;
            //_pathManager.AddEntry += _pathManager_AddEntry;
            //_pathManager.RemoveEntry += _pathManager_AddEntry;
            //_pathManager.LoadPath += _pathManager_AddEntry;
             ActiveList = 1;
            //bs = GetActiveList();
            CreateBackupFolder();
        //    FillAllCommand.RaiseCanExecuteChanged();
        }

        #region Commands
        public BoundCommand RepairPathCommand
        {

            get { return new BoundCommand(RepairPathAction, o => _pathManager.CanRepair, null); }
        }

        private bool CanRepair(object arg)
        {

            bool flag = _pathManager.CanRepair;
            return flag;
        }


        public  BoundCommand FillAllCommand
        {
            get
            {
                return new BoundCommand(FillAllAction, CanFillAll, 1);
            }
        }

        void FillAllAction(object o)
        {
          //  MessageBox.Show("FillAllAction: "+o.ToString());
            ActiveList = (int) o;
//           GetActiveList();
            //DataSource = null;
            //DataSource = bs;
            bs.DataSource = _pathManager.CurrentPathList;
        }

        bool CanFillAll(object o)
        {
        //    MessageBox.Show("CanFillAll: " + o.ToString());
            return true;
        }


        public  BoundCommand FillDuplicatedCommand
        {
            get
            {
                return new BoundCommand(FillDuplicatedAction, CanFillDuplicated, 2);
            }
        }

        void FillDuplicatedAction(object o)
        {
            ActiveList = (int)o;
         //  bs.DataSource = null;
          //   GetActiveList();
            bs.DataSource = _pathManager.DublicatedList;
        }

        bool CanFillDuplicated(object o)
        {
            return _pathManager.DublicatedList.Count > 0;
        }

        public BoundCommand FillNotExistCommand
        {

            get
            {
                return new BoundCommand((o) =>
                                        {
                                            ActiveList = (int)o;
                                            //GetActiveList();
                                            bs.DataSource = _pathManager.NotExistList ;
                                        }, (o) => _pathManager.NotExistList.Count > 0, 3);
            }
        }

        #endregion




        public BindingSource GetActiveList()
        {
            bs.DataSource = null;
            //   BindingSource b = new BindingSource();
            switch (ActiveList)
            {
                case 1:
                    bs.DataSource = _pathManager.CurrentPathList;
                    break;
                case 2:
                    bs.DataSource = _pathManager.DublicatedList;
                    break;
                case 3:
                    bs.DataSource = _pathManager.NotExistList;
                    break;
            }
            return bs;
        }

        
        private void CreateBackupFolder()
        {
            //backup
            if (!Directory.Exists("backup"))
            {
                Directory.CreateDirectory("backup");
            }
        }
       

        public void RepairPathAction(object obj)
        {
            var flag = _pathManager.RepairPath();
        }

    } //
}//


