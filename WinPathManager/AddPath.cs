using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WinPathManager
{

    public partial class AddPath : Form
    {
        public AddPath()
        {
            InitializeComponent();
        }

        private void buttonAddPath_Click(object sender, EventArgs e)
        {

            // Set initial selected folder
            folderBrowserDialog1.SelectedPath = @"C:\Program Files";

            // Show the "Make new folder" button
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textPathName.Text = folderBrowserDialog1.SelectedPath;
                //
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //
                //string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                //MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            }
        }
        //private string FindByDisplayName(string name)
        //{


        //}

        //dictionary name,location, ProductGuid
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


        private List<ProgramInfo> lst = new List<ProgramInfo>(); // GetInstalledApps();

        private void AddPath_Load(object sender, EventArgs e)
        {
            lst = GetInstalledApps();
            foreach (var l in lst)
                listBox1.Items.Add(l.Name);
            listBox1.SelectedIndex = 0;
        }

        //select
        private void button1_Click(object sender, EventArgs e)
        {
            var name = listBox1.SelectedItem.ToString();
            var result = lst.Find(item => item.Name.Contains(name));
            //MessageBox.Show(name + " -" + result.InstallLocation );
            textPathName.Text = result.InstallLocation;
        }

        //add to path
        //actions: check if path is valid and  not in path or not exist
        //confirm before modify path
        //modify path , refresh form
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {



                var oldPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
                var newEntry = textPathName.Text;
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }//
}

