using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.IO;
using System.Windows.Forms;
using BusinessObjects;
using NLog;
using PathUtilty;
/********************************************************************************************************
 * 
 * WinPath Manager
 * Copyright ©2014 Mohamed Hassan 
 * Apache License 2.0 (Apache)
 * 
 * https://pathmanger.codeplex.com/
 * 
 ******************************************************************************************************/


namespace WinPathManager.Helper
{
    /// <summary>
    /// Singletone class to mange winpath environment variable
    /// </summary>
    public sealed class PathManager : BusinessObject
    {
        public event EventHandler<PathManagerEventArgs> AddEntry, RemoveEntry, SavePath, PathChanged;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private static readonly PathManager _pathManagerInstance = new PathManager();
        public static PathManager PathManagerInstance
        {
            get
            {
                return _pathManagerInstance;
            }
        }

        private EnvironmentVariableTarget Evt { get; set; } //=EnvironmentVariableTarget.Machine; //

        public string _currentPathText;
        public string CurrentPathText
        {
            get { return _currentPathText; }
            set
            {
                if (_currentPathText != value)
                {
                    _currentPathText = value;
                    OnPropertyChanged("CurrentPathText");
                    OnPropertyChanged("IsDuplicated");
                }
            }
        }

        public bool _canRepair = false;
        public bool CanRepair
        {
            get { return _canRepair; }
            set
            {
                if (_canRepair != value)
                {
                    _canRepair = value;
                    OnPropertyChanged("CanRepair");
                }
            }
        }

        public string _pathSummary;
        public string PathSummary
        {
            get { return _pathSummary; }
            set
            {
                if (_pathSummary != value)
                {
                    _pathSummary = value;
                    OnPropertyChanged("PathSummary");
                }
            }
        }

        

        public Color _pathSummaryColor;
        public Color PathSummaryColor
        {
            get { return _pathSummaryColor; }
            set
            {
                if (_pathSummaryColor != value)
                {
                    _pathSummaryColor = value;
                    OnPropertyChanged("PathSummaryColor");
                }
            }
        }

        public bool IsDuplicated { get; set; }
        //{
        //    get { return DublicatedList.Count > 0; }
        //}


        public int CurrentPathLength { get; set; }
        public int CurrentPathCount { get; set; }
        public List<string> CurrentPathList { get; set; }
        //        public  BindingList<string> CurrentPathBl;//{ get; set; }
        public Boolean Over1023 { get; set; }
        public List<string> PathUnique { get; set; }
       // public List<string> DublicatedList { get; set; }
        public BindingList<string> DublicatedList { get; set; }
        public BindingList<string> NotExistList { get; set; }
        //  public List<string> Newlist { get; set; }
        public string CurrentUser { get; set; }
        public string ComputerName { get; set; }
        //  public string PathSummary { get; set; }
        
        public Color InfoColor { get; set; }

        private PathManager(EnvironmentVariableTarget ev)
        {
            //   MessageBox.Show("constructor singletone");
            Evt = ev; //EnvironmentVariableTarget.Machine;
            //      bs = new BindingSource();
            CurrentPathList = new List<string>();
            PathUnique = new List<string>();
            DublicatedList = new BindingList<string>();
            NotExistList = new BindingList<string>();
            CurrentPathText = GetCurrentPathText();
            // Init();
        }

        PathManager()
            : this(EnvironmentVariableTarget.Machine)
        {}

        private string GetCurrentPathText()
        {
            var s = Environment.GetEnvironmentVariable("path", Evt);
            return s;
        }



        public void Load()
        {
            CurrentPathText = GetCurrentPathText();
            Init();
            PathChanged.Raise( this,null);
        }

        public bool GetRepairStatus()
        {
            return DublicatedList.Count > 0 ||
                   NotExistList.Count > 0 ||
                   Over1023;
        }
        public void Init()
        {
            Init(EnvironmentVariableTarget.Machine);

        }
        public void Init(EnvironmentVariableTarget ev)
        {
            // MessageBox.Show("init");
            //  CurrentPathText = GetCurrentPathText();

            if (CurrentPathText != string.Empty)
            {
                CurrentPathLength = CurrentPathText.Length;

                CurrentPathList.Clear();
                CurrentPathList = GetCurrentPathList();

                CurrentPathCount = CurrentPathList.Count;

                // MessageBox.Show(PathSummary);
                Over1023 = CurrentPathLength > 1023;
                PathSummaryColor = Over1023 ? Color.Red : Color.Black;

                PathUnique = CurrentPathList.Where(Directory.Exists) // remove not exist
                                                .Distinct().ToList();  //remove duplicated

                DublicatedList.Clear();
                DublicatedList = GetDuplicatedList(CurrentPathList);

                NotExistList = new BindingList<string>( CurrentPathList.Where(item => !Directory.Exists(item)).ToList());
                PathSummary = string.Format("Path Length: {0}, Count: {1}", CurrentPathLength, CurrentPathCount);
                if (Over1023) PathSummary += " (Over 1023 char)";
                CanRepair = GetRepairStatus();
                IsDuplicated = DublicatedList.Count > 0;
                PathChanged.Raise(this, null);

            }

        }

        public void Refresh()
        {
            Load();
            MessageBox.Show("Refreshing List Complete");

        }

        public List<string> GetCurrentPathList()
        {
            //   var currentPathText = GetCurrentPathText();
            List<string> lst = new List<string>();
            lst = CurrentPathText.Split(';').ToList();
            return new List<string>(lst);
        }

        private string List2String(List<string> lst)
        {

            string s = string.Join(";", lst.ToArray());
            return s;
        }

        private BindingList<string> GetDuplicatedList(List<string> lst)
        {
            var lst2= lst.GroupBy(i => i)
                         .Where(g => g.Count() > 1)
                         .Select(g => g.Key).ToList();
             
            return new BindingList<string>(lst2); 
        }

        public void SaveProgramPath(string path)
        {
            BackupPath();
            Environment.SetEnvironmentVariable("path", path, Evt);
            _logger.Info("Save Environment");

        }

        public void SaveProgramPath(List<string> path)
        {
            string pathText = List2String(path);
            SaveProgramPath(pathText);
            SavePath.Raise( this , null);
        }

        public void BackupPath()
        {
             
            string path = CurrentPathText;
            //  string path = GetCurrentPathText();
            DateTime dt = DateTime.Now; // new DateTime(2008, 3, 9, 16, 5, 7, 123);
            string fname = "backup\\path" + String.Format("{0:yyyyMMdd-hhmmss}", dt) + ".txt";
            // string path = textBox1.Text;
            File.WriteAllText(fname, path);
            _logger.Info("Export path Environment to file {0}", fname);
        }

        public string ExportToFile()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog()
                                            {
                                                InitialDirectory = Directory.GetCurrentDirectory(),
                                                // Title = "Browse Files",
                                                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                                                DefaultExt = "txt",
                                                CheckPathExists = true,
                                                FilterIndex = 1,
                                                RestoreDirectory = true
                                            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string path = GetCurrentPathText();
                string path = CurrentPathText;
                string fname = saveFileDialog.FileName;
                //System.IO.StreamReader sr = new
                //   System.IO.StreamReader(openFileDialog1.FileName);
                File.WriteAllText(fname, path);
                //MessageBox.Show(saveFileDialog.FileName);
                //sr.Close();
                _logger.Info("Export path to file: {0}", fname);
                return fname;
            }
            return string.Empty;
        }

         

        public bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


 

        public void AddPathEntry(string entry)
        {
            // string addedEntries = "";

            try
            {
                // var oldPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
                var oldPath = CurrentPathText;
                // var newEntry = entry;
                if (entry == string.Empty
                    || oldPath.Contains(entry)
                    || !Directory.Exists(entry)
                    )
                {
                    var msg = string.Format("[{0}]\nThe Entry exist in the Path or not valid one ", entry);
                    var result = MessageBox.Show(msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                var newPath = oldPath + ";" + entry;
                //update path
                //    MessageBox.Show(newPath);

                //  var    msg = "The new path is " + Convert.ToString(size1) + Environment.NewLine;
                var msg2 = "Are you sure to add the new Entry to path";
                var result2 = MessageBox.Show(msg2, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result2 == DialogResult.Cancel) return;
                Cursor.Current = Cursors.WaitCursor;
                //  Environment.SetEnvironmentVariable("path", newPath, EnvironmentVariableTarget.Machine);
                SaveProgramPath(newPath);
                CurrentPathText = newPath;
                Init();
                _logger.Info("Add: {0}", entry);
                //should init variables
                //OnCollectionChanged(NotifyCollectionChangedAction.Reset);
              //  OnAddEntry(null);
                AddEntry.Raise(this, null);
                MessageBox.Show("Sucess Updating the Path", "Information", MessageBoxButtons.OK,
                         MessageBoxIcon.Information);

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


        public Boolean RepairPath() //(List< string > newlist)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<string> Newlist = new List<string>();
                string msg = "Are you sure to repair the window path" + Environment.NewLine;
                msg += "The current path will be exported to external file";

                var result = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel) return false;



                Newlist = PathUnique.ToList();

                int size1 = Newlist.Sum(item => item.Length + 1);

                //bool shouldSave = size1 != CurrentPathText.Length;
                string s = "";

                Console.WriteLine("Excluding dublicated entries");

                Console.WriteLine("{0}: excluding dublicated entries", size1);


                //shoorten the path starting with last entries
                if (size1 > 1023)
                {
                    //int size2 = 0;
                    //  for (int index = 0; index < newlist.Count; index++)
                    for (int index = Newlist.Count - 1; index > 0; index--)
                    {
                        var item = Newlist[index];
                        Newlist[index] = FileSystemHelper.GetShortPathName(item);
                        size1 = Newlist.Sum(item2 => item2.Length + 1);
                        Console.WriteLine("short: {0}, newsize: {1}", size1, Newlist[index]);
                        if (size1 < 1023) break; //1023- 10 extra room for any next installation
                    } //for
                } //if

                string newPath = Newlist.Aggregate((workingSentence, next) => workingSentence + ";" + next);
                Console.WriteLine("final path new length {0} ", newPath.Length);
                Console.WriteLine(newPath);

                msg = "The new path is " + Convert.ToString(size1) + Environment.NewLine;
                msg += "Are you sure to write the new path";

                result = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel) return false;

                //export to file
                BackupPath();
                SaveProgramPath(newPath);
                Refresh();
                _logger.Info("Repairing Path");
                PathChanged.Raise( this ,null);
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error("Error in Repair: " + ex.Message);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Repair Completed Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.None);
              

            }
            return false;
          
        }
        
    }//
}//
