using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PathUtilty;
//using WindowsFormsToolkit.CommandManager;
//using WindowsFormsToolkit.MVVM;

namespace WinPathManager
{

    public class PathEditor  :Model 
    {
        #region properties

        private string currentPathText;
        [Notify]
        [Notify("CurrentPathText")]
        public string CurrentPathText
        {
            get { return currentPathText; } 
            set 
            {
                base.SetValue("CurrentPathText", value);
               // currentPathText = value;
                //Init();
            }
        }

        public int CurrentPathLength { get; set; }
        public int CurrentPathCount { get; set; }
        public List<string> CurrentPathList { get; set; }
        // public ObservableCollection<string > CurrentPathList { get; set; }
        public Boolean Over1023 { get; set; }
        public List<string> PathUnique { get; set; }

        public List<string> DublicatedList { get; set; }
        public List<string> NotExistList { get; set; }
        public List<string> Newlist { get; set; }

      //  public int Index { get; set; }

        //    public ObservableCollection<string> Mylist { get; set; }
       // public BindingList<string> Mylist2 = new BindingList<string>();
        public BindingSource bs = new BindingSource();




        /// <summary>
        /// The <see cref="MyProperty" /> property's name.
        /// </summary>
        //public const string MyPropertyPropertyName = "MyProperty";

        //private List<string> _myList = null;

        /// <summary>
        /// Gets the MyProperty property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        //public List<string> MyList
        //{
        //    get
        //    {
        //        return _myList;
        //    }

        //    set
        //    {
        //        if (_myList == value)
        //        {
        //            return;
        //        }

        //        var oldValue = _myList;
        //        _myList = value;

        //        // Remove one of the two calls below
        //        throw new NotImplementedException();

        //        // Update bindings, no broadcast
        //        RaisePropertyChanged(MyPropertyPropertyName);

        //        // Update bindings and broadcast change using GalaSoft.MvvmLight.Messenging
        //        RaisePropertyChanged(MyPropertyPropertyName, oldValue, value, true);
        //    }
        //}  


        //private string name;
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;

        //        //         NotifyPropertyChanged("Name");
        //    }
        //}
        //public List<string> MyList { get; set; }

        #endregion properties
        

        



        //public PathEditor()
        //{
        //    CurrentPathText = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
        //    bs.DataSource = CurrentPathList;
        //}
        /// <summary>
        ///  
        /// </summary>
        public void Init()
        {
            if (CurrentPathText != null)
            {
                CurrentPathLength = CurrentPathText.Length;
                CurrentPathList = CurrentPathText.Split(';').ToList();
                //   CurrentPathList = new ObservableCollection<string>(aa);

                //      MyList = CurrentPathList;

                CurrentPathCount = CurrentPathList.Count;
                Over1023 = CurrentPathLength > 1023;
                PathUnique = CurrentPathList.Where(item => Directory.Exists(item)) // remove not exist
                                                .Distinct().ToList();  //remove duplicated

                DublicatedList = CurrentPathList
                     .GroupBy(i => i)
                     .Where(g => g.Count() > 1)
                     .Select(g => g.Key).ToList();

                NotExistList = CurrentPathList.Where(item => !Directory.Exists(item)).ToList();
                /*
                OnPathChange(this, null);
                if (CurrentPathText.Length > 1023)
                    OnPathOverLength(this, null);
                */
                 
                //Mylist2 = new BindingList<string>(CurrentPathList);
              //  FillAllAction();
            }

        }

    }
}

