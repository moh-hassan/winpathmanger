using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using BusinessObjects;
using Microsoft.Win32;
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


namespace WinPathManager.ViewModel
{
    public class AddPathViewModel : BusinessObject
    {
        PathManager _pathManager = PathManager.PathManagerInstance;
     
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public List<string> InstalledPrograms { get; set; }
        private List<ProgramInfo> InstalledAppsInfo { get; set; }
        public BoundCommand BrowseCommand;
        // public  CommandBindingManager commandBindingManager = new CommandBindingManager();
        //public BindingSource BS;
        public event NotifyCollectionChangedEventHandler CollectionChanged = (o, e) => { };


        public bool _isExist;
        public bool IsExist
        {
            get { return _isExist; }
            set
            {
                if (_isExist != value)
                {
                    _isExist = value;
                    OnPropertyChanged("IsExist");
                }
            }
        }

        public BoundCommand AddEntryCommand
        {
            get { return new BoundCommand(AddAction, CanAdd, Entry); }
        }
        

        private string _entry;
        public string Entry
        {
            //    get { return currentPathText; } 
            get { return _entry; }
            set
            {

                _entry = value;
        //        AddEntryCommand.RaiseCanExecuteChanged();
                OnPropertyChanged("Entry");
            }
        }

        //private Boolean _addStatus=true;
        //public Boolean AddStatus
        //{
        //    //    get { return currentPathText; } 
        //    get { return _addStatus; }
        //    set
        //    {

        //        _addStatus = value;
        //        AddEntryCommand.RaiseCanExecuteChanged();
        //        OnPropertyChanged("AddStatus");
        //    }
        //}

        private int _selectionMode;
        public int SelectionMode
        {
            get { return _selectionMode; }
            set
            {
                if (_selectionMode != value)
                {
                    _selectionMode = value;
                    BrowseCommand.RaiseCanExecuteChanged();
                    //  OnPropertyChanged("SelectionMode");
                }
            }
        }

        public AddPathViewModel()
        {
            InstalledPrograms = new List<string>();
            InstalledAppsInfo = new List<ProgramInfo>();
            InstalledAppsInfo = GetInstalledApps();
            foreach (var item in InstalledAppsInfo)
                InstalledPrograms.Add(item.InstallLocation);

            BrowseCommand = new BoundCommand(BrowseAction, CanBrowse, null);
        }


        private bool CanBrowse(object o)
        {
            //  MessageBox.Show("canbrowse:" + SelectionMode .ToString( ));
            return SelectionMode == 1;
        }

        void BrowseAction(object obj)
        {
            // MessageBox.Show("browse action");
            // Set initial selected folder
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = @"C:\Program Files";

            // Show the "Make new folder" button
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Entry = folderBrowserDialog1.SelectedPath;
                //  textPathName.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        //button select

        //public BoundCommand SelectCommand
        //{
        //    get { return new BoundCommand(SelectAction, o => true, null); }
        //}



        //void SelectAction(object obj)
        //{
        //    MessageBox.Show("Select action");
        //    var result = InstalledAppsInfo.Find(item => item.Name.Contains(Entry));
        //    Entry = result.InstallLocation;
        //}

       
        public bool CanAdd(object obj)
        {
            //string s = obj.ToString();

            //return Entry != string.Empty
            //    || !PathManager.CurrentPathText.Contains(s);
         //   MessageBox.Show(obj.ToString() );
            return true;
        }



        //add to path
        //actions: check if path is valid and  not in path or not exist
        //confirm before modify path
        //modify path , refresh form
        private void AddAction(object obj)
        {
            //Add();
            MessageBox.Show(Entry);
            _pathManager.AddPathEntry(Entry );
        
        }

        void Add()
        {

        string addedEntries = "";

            try
            {
                var oldPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
                var newEntry = Entry;
                if (newEntry == ""
                    || oldPath.Contains(newEntry)
                    || !Directory.Exists(newEntry)
                    )
                {
                    var msg = "The Entry exist in the Path or not valid one ";
                    var result = MessageBox.Show(msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                var newPath = oldPath + ";" + newEntry;
                //update path
                //    MessageBox.Show(newPath);

                //  var    msg = "The new path is " + Convert.ToString(size1) + Environment.NewLine;
                var msg2 = "Are you sure to add the new Entry to path";
                var result2 = MessageBox.Show(msg2, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result2 == DialogResult.Cancel) return;
                Cursor.Current = Cursors.WaitCursor;
                Environment.SetEnvironmentVariable("path", newPath, EnvironmentVariableTarget.Machine);
                MessageBox.Show("Sucess Updating the Path", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _logger.Info("Add: {0}", newEntry);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _logger.Error("Error in Add Entry: " + ex.Message);
            }
            finally
            {
                
                Cursor.Current = Cursors.Default;
            }
        }

        //---------------------------------------------------------
        public List<ProgramInfo> GetInstalledApps() //string os=null )
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            //if(os=="64")
            //    uninstallKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            List<ProgramInfo> lst = new List<ProgramInfo>();


            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            ProgramInfo app = new ProgramInfo(sk);
                            if (app.Name != "" && app.InstallLocation != "") lst.Add(app);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }//using
                }//foreach
            }
            return lst;
        }


    }//
}
