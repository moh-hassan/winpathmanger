using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BusinessObjects;
using MvvmFx.Windows.Input;
using PathUtilty;
 

namespace WinPathManager
{

    public class PathEditorViewModel : BusinessObject
    {
        #region properties

      

       // private string currentPathText;
       // [Notify]
      //  [Notify("CurrentPathText")]
        private string currentPathText;
        public string CurrentPathText
        {
        //    get { return currentPathText; } 
            get { return currentPathText; }
            set 
            {

                currentPathText = value;
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
            get { return new BoundCommand(RepairPathAction, (o) => Over1023 , null ); }
        }


        public BoundCommand FillAllCommand
        {

            get { return new BoundCommand((o) => bs.DataSource = CurrentPathList, (o) => true, null); }
        }

        

        public BoundCommand FillDuplicatedCommand
        {

            get { return new BoundCommand((o) => bs.DataSource = DublicatedList, (o) => DublicatedList.Count >0, null); }
        }

        public BoundCommand FillNotExistCommand
        {

            get { return new BoundCommand((o) => bs.DataSource = NotExistList, (o) => NotExistList.Count > 0, null); }
        }

         

         

        //public ICommand RefeshCommand
        //{
        //    get { return new ActionCommand("Refresh", () => true, Refresh); }
        //}

        

        #endregion

        #region Events


        //public event EventHandler PathChange;
        //protected void OnPathChange(object sender, EventArgs e)
        //{
        //    Debug.WriteLine("onpathchane");
        //    if (PathChange != null)
        //        PathChange(sender, e);
        //}

        //public event EventHandler PathOverLength;
        //protected void OnPathOverLength(object sender, EventArgs e)
        //{
        //    Debug.WriteLine("PathOverLength event");
        //    if (PathOverLength != null)
        //        PathOverLength(sender, e);
        //}

        //public event EventHandler PathRepairing;
        //protected void OnPathRepairing(object sender, EventArgs e)
        //{
        //    Debug.WriteLine("PathRepairing event");
        //    if (PathRepairing != null)
        //        PathRepairing(sender, e);
        //}


        #endregion Event



        public PathEditorViewModel()
        {
            CurrentPathText = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
            bs.DataSource = CurrentPathList;
        }

        void Refresh()
        {
        //    MessageBox.Show("hi");
            CurrentPathText = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
        }

        /// <summary>
        ///  compute other properties
        /// </summary>
        public   void Init()
        {
            if (CurrentPathText != null)
            {
                CurrentPathLength = CurrentPathText.Length;
            


                CurrentPathList = CurrentPathText.Split(';').ToList();
                //   CurrentPathList = new ObservableCollection<string>(aa);

                //      MyList = CurrentPathList;

                CurrentPathCount = CurrentPathList.Count;
                PathSummary = string.Format("Length: {0}, Count: {1}", CurrentPathLength, CurrentPathCount);
                Over1023 = CurrentPathLength > 1023;
                PathUnique = CurrentPathList.Where(item => Directory.Exists(item)) // remove not exist
                                                .Distinct().ToList();  //remove duplicated

                DublicatedList = CurrentPathList
                     .GroupBy(i => i)
                     .Where(g => g.Count() > 1)
                     .Select(g => g.Key).ToList();

                NotExistList = CurrentPathList.Where(item => !Directory.Exists(item)).ToList();

                //OnPathChange(this, null);
                //if (CurrentPathText.Length > 1023)
                //    OnPathOverLength(this, null);
                if (Over1023) PathSummary += " (Over 1023 char)";
         
            }

        }

        public void RepairPathAction(object obj)
        {
            var flag = RepairPath();
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
                

            //int newsize = PathUnique.Sum(item => item.Length + 1);
            //int newsize = Newlist.Sum(item => item.Length + 1);
            //Console.WriteLine("newsize {0}", newsize);

            //add every element as short/asis 

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
                    Console.WriteLine("shoert: {0}, newsize: {1}", size1, Newlist[index]);
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
            FileSystemHelper.SavePath(CurrentPathText);
            Environment.SetEnvironmentVariable("path", newPath, EnvironmentVariableTarget.Machine); ;

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

