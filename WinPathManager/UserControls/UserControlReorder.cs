using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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


namespace WinPathManager.UserControls
{
    public partial class UserControlReorder : UserControl
    {
        private PathManager _pathManager = PathManager.PathManagerInstance;
        private CommandBindingManager _commandBindingManager = new CommandBindingManager();
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        //selectedIndex = myListBox.SelectedIndex;

        private BoundCommand MoveUpCommand
        {
            get { return new BoundCommand(MoveUp, CanMoveUp, null); }
        }
        private BoundCommand MoveDownCommand
        {
            get { return new BoundCommand(MoveDown, CanMoveDown, null); }
        }
        private BoundCommand MoveTopCommand
        {
            get { return new BoundCommand(MoveTop, CanMoveTop, null); }
        }
        private BoundCommand MoveBottomCommand
        {
            get { return new BoundCommand(MoveBottom, CanMoveBottom, null); }
        }
        private BoundCommand SortListCommand
        {
            get { return new BoundCommand(SortList, o=>true , null); }
        }
        private BoundCommand ResetListCommand
        {
            get { return new BoundCommand(ResetList, o=>true , null); }
        }
        private BoundCommand SaveCommand
        {
            get { return new BoundCommand(SaveList, o => true, null); }
        }


        public int SelectedIndex
        {
            get
            {
                return this.listBoxCurrentPath.SelectedIndex;
            }
            set
            {
                if (SelectedIndex != value)
                {
                    listBoxCurrentPath.SelectedIndex = value;
                    //  OnDataSourceChanged();
                }
            }
        }

        public UserControlReorder()
        {
            InitializeComponent();
            Load += OnLoad;
            BindCommands();
        }

        void OnLoad(object sender , EventArgs e)
        {
            foreach (var item in _pathManager.CurrentPathList)
            {
                listBoxCurrentPath.Items.Add(item);
            }

          
        }

        void BindCommands()
        {
            _commandBindingManager.RegisterCommand(MoveUpCommand, buttonUp);
            _commandBindingManager.RegisterCommand(MoveDownCommand, buttonDown);
            _commandBindingManager.RegisterCommand(MoveTopCommand, buttonTop);
            _commandBindingManager.RegisterCommand(MoveBottomCommand, buttonBottom);
            _commandBindingManager.RegisterCommand(SortListCommand, buttonSort);
            _commandBindingManager.RegisterCommand(ResetListCommand, buttonReset);
            _commandBindingManager.RegisterCommand(SaveCommand, buttonSave);
             
        }

         

        bool  CanMoveUp(object o)
        {
            return true;
        }
        void MoveUp(object o)
        {
            ListBox myListBox = listBoxCurrentPath;
            int selectedIndex = myListBox.SelectedIndex;
            if (selectedIndex > 0 & selectedIndex != -1)
            {
                myListBox.Items.Insert(selectedIndex - 1, myListBox.Items[selectedIndex]);
                myListBox.Items.RemoveAt(selectedIndex + 1);
                myListBox.SelectedIndex = selectedIndex - 1;
            }
        }

        bool CanMoveDown(object o)
        {
            return true;
        }
        bool CanMoveTop(object o)
        {
            return true;
        }
        bool CanMoveBottom(object o)
        {
            return true;
        }

        void MoveDown(object o)
        {
            int selectedIndex = listBoxCurrentPath.SelectedIndex;
            if (selectedIndex < listBoxCurrentPath.Items.Count - 1 & selectedIndex != -1)
            {
                listBoxCurrentPath.Items.Insert(selectedIndex + 2, listBoxCurrentPath.Items[selectedIndex]);
                listBoxCurrentPath.Items.RemoveAt(selectedIndex);
                listBoxCurrentPath.SelectedIndex = selectedIndex + 1;

            }
        }

        void MoveBottom(object o)
        {
            int selectedIndex = listBoxCurrentPath.SelectedIndex;
            if (selectedIndex <= listBoxCurrentPath.Items.Count - 1 & selectedIndex != -1)
            {
                listBoxCurrentPath.Items.Insert(listBoxCurrentPath.Items.Count, listBoxCurrentPath.Items[selectedIndex]);
                listBoxCurrentPath.Items.RemoveAt(selectedIndex);
                listBoxCurrentPath.SelectedIndex = listBoxCurrentPath.Items.Count - 1;

            }
        }

        void MoveTop(object o)
        {
            int selectedIndex = listBoxCurrentPath.SelectedIndex;
            if (selectedIndex <= listBoxCurrentPath.Items.Count - 1 & selectedIndex != -1)
            {
                listBoxCurrentPath.Items.Insert(0, listBoxCurrentPath.Items[selectedIndex]);
                listBoxCurrentPath.Items.RemoveAt(selectedIndex + 1);
                listBoxCurrentPath.SelectedIndex = 0;

            }
        }

        private void SortList(object o)
        {
            listBoxCurrentPath.Sorted = true ;
        }

        private void ResetList(object o)
        {
            listBoxCurrentPath.Items.Clear();
            listBoxCurrentPath.Sorted = false ;
            foreach (var item in _pathManager.CurrentPathList)
            {
                listBoxCurrentPath.Items.Add(item);
            }
        }

        private void SaveList(object o)
        {
            try
            {


                string msg = "Are you sure to Save the modified path" + Environment.NewLine;
                msg += "The current path will be saved to  file as backup";

                var result = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel) return;

                // listBoxCurrentPath.Sorted = true;
                Cursor.Current = Cursors.WaitCursor;
                string s = "";
                foreach (var item in listBoxCurrentPath.Items)
                {
                    s += item.ToString() + ";";
                }
                s= s.TrimEnd(';');
           // MessageBox.Show(s);
                _pathManager.SaveProgramPath(s);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error("Error in save: " + ex.Message);
               

            }
            finally
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Save Completed Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.None);  
            }
           

        }
         

    }
}
