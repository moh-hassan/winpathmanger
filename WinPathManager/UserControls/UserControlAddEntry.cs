using System;
using System.Windows.Forms;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Input;
using NLog;
using WinPathManager.Helper;
using WinPathManager.ViewModel;
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
    
    public partial class UserControlAddEntry : UserControl
    {
        public AddPathViewModel ViewModel = new AddPathViewModel();
        private BindingManager _bindingManager = new BindingManager();
        private CommandBindingManager commandBindingManager = new CommandBindingManager();
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public UserControlAddEntry()
        {
            InitializeComponent();
            OnInitializeBinding();
            BindCommands();
            Load += OnLoad;
        }



        protected void OnInitializeBinding()
        {
            _bindingManager.Bindings.Add(
                new TypedBinding<TextBox, AddPathViewModel>(textPathName, t => t.Text, ViewModel, s => s.Entry));
        }

        private void BindCommands()
        {
            //    AddCommand(ViewModel.BrowseCommand, buttonBrowse);
            commandBindingManager.RegisterCommand(ViewModel.BrowseCommand, buttonBrowse);
            commandBindingManager.RegisterCommand(ViewModel.AddEntryCommand, button2);
        }


        private void OnLoad(object sender, EventArgs e)
        {
            
            radioButton1.Checked = true;
            radioButton1.Click += radioButtonCheckedChanged;
            radioButton2.Click += radioButtonCheckedChanged;
            listBox1.DataSource = ViewModel.InstalledPrograms;
            listBox1.SelectedIndexChanged += (s, e1) => ViewModel.Entry = listBox1.SelectedItem.ToString();
            listBox1.SetSelected(0, true);

        }




        private void radioButtonCheckedChanged(object sender, EventArgs e)
        {
            ViewModel.SelectionMode = radioButton1.Checked ? 0 : 1;
            listBox1.Enabled = radioButton1.Checked ? true : false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("item: " + listBox1.SelectedItem.ToString());
            ViewModel.Entry = listBox1.SelectedItem.ToString();
        }

       }
}
