using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BusinessObjects;
using MvvmFx.Windows.Input;
using PathUtilty;
using WinPathManager.Helper;

namespace WinPathManager.ViewModel
{

    public class PathEditorViewModel : BusinessObject
    {
        #region properties

        private PathManager _pathManager = new PathManager();
      

        
        private string _currentPathText;
        public string CurrentPathText
        {
        get { return _currentPathText; }
            set 
            {

                _currentPathText = value;
                Init();
                OnPropertyChanged("CurrentPathText");
            }
        }

        public int CurrentPathLength { get; set; }
        public int CurrentPathCount { get; set; }
        public List<string> CurrentPathList { get; set; }
        public Boolean Over1023 { get; set; }
        public List<string> PathUnique { get; set; }

        public List<string> DublicatedList { get; set; }
        public List<string> NotExistList { get; set; }
        public List<string> Newlist { get; set; }
        public string CurrentUser { get; set; }
        public string ComputerName { get; set; }
        public string PathSummary { get; set; }
        //public Color

        public   BindingSource bs = new BindingSource();
        #endregion properties

        #region Commands
       
        public BoundCommand RepairPathCommand
        {
            get { return new BoundCommand(RepairPathAction, o => Over1023 , null ); }
        }

        public BoundCommand RefreshCommand
        {
            get { return new BoundCommand(RefreshAction, o => true, null); }
        }


        public BoundCommand FillAllCommand
        {

            get { return new BoundCommand(o => bs.DataSource = CurrentPathList, o => true, null); }
        }

        

        public BoundCommand FillDuplicatedCommand
        {

            get { return new BoundCommand((o) => bs.DataSource = DublicatedList, (o) => DublicatedList.Count >0, null); }
        }

        public BoundCommand FillNotExistCommand
        {

            get { return new BoundCommand((o) => bs.DataSource = NotExistList, (o) => NotExistList.Count > 0, null); }
        }

        #endregion

        #region Events


         
        #endregion Event



        public PathEditorViewModel()
        {
           // CurrentPathText = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
            CurrentPathText = _pathManager.GetCurrentPathText();
            bs.DataSource = CurrentPathList;
        }

        void Refresh()
        {
        //    MessageBox.Show("refresh");
            CurrentPathList.Clear();
            CurrentPathText = _pathManager.GetCurrentPathText();
            Init();
            bs.DataSource = null ;
            bs.DataSource = CurrentPathList;
        }

        /// <summary>
        ///  compute other properties
        /// </summary>
        public   void Init()
        {
             
            if (CurrentPathText != null)
            {
                CurrentPathLength = CurrentPathText.Length;
                CurrentPathList = _pathManager.GetCurrentPathList();
                     
                CurrentPathCount = CurrentPathList.Count;
                PathSummary = string.Format("Length: {0}, Count: {1}", CurrentPathLength, CurrentPathCount);
                Over1023 = CurrentPathLength > 1023;

                PathUnique = CurrentPathList.Where(item => Directory.Exists(item)) // remove not exist
                                                .Distinct().ToList();  //remove duplicated

                DublicatedList = _pathManager.GetDuplicatedList(CurrentPathList);

                NotExistList = CurrentPathList.Where(item => !Directory.Exists(item)).ToList();
                if (Over1023) PathSummary += " (Over 1023 char)";
            }

        }

        public void RepairPathAction(object obj)
        {
            var flag = RepairPath();
        }

        public void RefreshAction(object obj)
        {
           // MessageBox.Show("refresh");
            Refresh();
        }
        /// <summary>
        /// Remove dublicated entries /not exist ones
        /// </summary>
        public Boolean RepairPath() //(List< string > newlist)
        {
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
                

            //shoorten the path
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
                }//for
            }//if

            string newPath = Newlist.Aggregate((workingSentence, next) => workingSentence + ";" + next);
            Console.WriteLine("final path new length {0} ", newPath.Length);
            Console.WriteLine(newPath);

            msg = "The new path is " + Convert.ToString(size1) + Environment.NewLine;
            msg += "Are you sure to write the new path";

            result = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel) return false;

            //export to file
            _pathManager.BackupPath();

            //update path
           // Environment.SetEnvironmentVariable("path", newPath, EnvironmentVariableTarget.Machine); ;
            _pathManager.SaveProgramPath(newPath);

            return true;
        }

        /// <summary>
        /// Restore path from pre-saved file to replace the current path
        /// </summary>
        /// <param name="filename"></param>
        public void Init(string filename)
        {
            //import external file containing path as path variable env.
            //TODO: need to be implemented
            //    CurrentPathText = s;

        }
    }
}

