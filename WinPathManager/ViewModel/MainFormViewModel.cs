using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BusinessObjects;
using Microsoft.Win32;
using MvvmFx.Windows.Input;
using NLog;
using WinPathManager.Helper;

namespace WinPathManager.ViewModel
{
    public class MainFormViewModel : BusinessObject
    {
        PathManager _pathManager = PathManager.PathManagerInstance;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public BoundCommand AddEntryCommand, RemoveEntryCommand, ExportCommand, PathTextCommand,RefreshCommand;
      //  private PathManager _pathManagerEx;//= new PathManager();

        public MainFormViewModel()
        {
            
        //    _pathManagerEx = pm;
            
            //AddEntryCommand = new BoundCommand(AddEntryAction, o=>true, null);
            
            //RemoveEntryCommand = new BoundCommand(RemoveEntryAction, o => true, null);
            ExportCommand = new BoundCommand(ExportyAction, o => true, null);
            PathTextCommand = new BoundCommand(PathTextAction, o => true, null);
           // RefreshCommand = new BoundCommand(RefreshAction, o => true, null);
            
        }

        

        void AddEntryAction(object obj)
        {
          //  AddPath f = new AddPath();
          //  f.ShowDialog();
          //  RefreshAction(obj);

        }

        private void RemoveEntryAction(object obj)
        {
           // DelPath f = new DelPath();
          //  f.ShowDialog();
        }

        private void PathTextAction(object obj)
        {
            //var f = new PathTextForm();
            //f.ShowDialog();
        }
        //PathTextForm
        private void ExportyAction(object obj)
        {

            
            string fname = _pathManager.ExportToFile();
            //  if (fname !=string .Empty )
           // _logger.Info("Export path to file: {0}", fname);
            //MessageBox.Show(fname);
        }

        

        


    }//
}
