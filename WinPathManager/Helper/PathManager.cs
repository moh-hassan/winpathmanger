using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.IO;
using System.Windows.Forms;

namespace WinPathManager.Helper
{
    class PathManager
    {
        public  EnvironmentVariableTarget Evt { get; set; }

        public PathManager(EnvironmentVariableTarget  ev)
        {
            Evt = ev;
        }

        public PathManager():this (EnvironmentVariableTarget.Machine)
        {}

        public   string GetCurrentPathText()
        {

            return Environment.GetEnvironmentVariable("path", Evt);
        }

        public   List<string> GetCurrentPathList()
        {
            var currentPathText = GetCurrentPathText();
            return currentPathText.Split(';').ToList();
        }

        private    string List2String(List<string> lst)
        {

            string s = string.Join(";", lst.ToArray());
            return s;
        }

        public   List<string> GetDuplicatedList(List<string> lst)
        {
           return    lst.GroupBy(i => i)
                        .Where(g => g.Count() > 1)
                        .Select(g => g.Key).ToList();
        }

        public   void SaveProgramPath(string path)
        {

            Environment.SetEnvironmentVariable("path", path, Evt );


        }

        public   void SaveProgramPath(List<string> path)
        {
            string pathText = List2String(path);
            SaveProgramPath(pathText);

        }

        public   void BackupPath()
        {
            //  if (!Directory.Exists("backup" ))
            //  Directory .CreateDirectory(pathString);

            // System.IO.Directory.CreateDirectory(pathString);
            string path = GetCurrentPathText();
            DateTime dt = DateTime.Now; // new DateTime(2008, 3, 9, 16, 5, 7, 123);
            string fname = "backup\\path" + String.Format("{0:yyyyMMdd-hhmmss}", dt) + ".txt";
                        // string path = textBox1.Text;
            File.WriteAllText(fname, path);
        }

    public    string  ExportToFile()
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
                string path = GetCurrentPathText();
                string fname = saveFileDialog.FileName;
                //System.IO.StreamReader sr = new
                //   System.IO.StreamReader(openFileDialog1.FileName);
                File.WriteAllText(fname , path);
                //MessageBox.Show(saveFileDialog.FileName);
                //sr.Close();
                return fname;
            }
        return string.Empty;
        }

        //public void ExportPath()
        //{
          
        //}

        public bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        //TODO: mange path of current user EnvironmentVariableTarget.User
    }
}
