using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinPathManager
{
    public partial class DelPath : Form
    {
        public DelPath()
        {
            InitializeComponent();
        }

        //remove entries
        private void button1_Click(object sender, EventArgs e)
        {
            string newPath = "";

            try
            {

                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    //if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                    if (!checkedListBox1.GetItemChecked(i))
                    {
                        //MessageBox.Show(checkedListBox1.Items[i] as string );
                        newPath += checkedListBox1.Items[i].ToString() + ";";

                    }
                }

                newPath = newPath.TrimEnd(';');
                //MessageBox.Show(s);
                //  var    msg = "The new path is " + Convert.ToString(size1) + Environment.NewLine;
                var msg2 = "Are you sure to Remove  the selected entries from the path";
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
                //refresh list
                checkedListBox1.Items.Clear();
                FillList();
                Cursor.Current = Cursors.Default;
            }


        }

        private void DelPath_Load(object sender, EventArgs e)
        {
            FillList();
        }

        void FillList()
        {
            var CurrentPathText = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
            var CurrentPathList = CurrentPathText.Split(';').ToList();

            foreach (string item in CurrentPathList)
                if (item != "") checkedListBox1.Items.Add(item);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Sort")
            {
                checkedListBox1.Sorted = true;
                // button2.Text = "Un Sort";

            }
            //else
            //{
            //    checkedListBox1.Sorted = false ;
            //    button2.Text = "Sort"; 
            //}
        }
    }
}
