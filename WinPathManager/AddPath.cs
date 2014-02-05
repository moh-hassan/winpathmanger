using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Input;
using NLog;
using WinPathManager.Helper;
using WinPathManager.ViewModel;

namespace WinPathManager
{

    public partial class AddPath : Form
    {
        public AddPathViewModel ViewModel = new AddPathViewModel();
        private BindingManager _bindingManager = new BindingManager( );
        private CommandBindingManager commandBindingManager = new CommandBindingManager();
      private static Logger _logger = LogManager.GetCurrentClassLogger();

        public AddPath()
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

        void BindCommands()
        {
        //    AddCommand(ViewModel.BrowseCommand, buttonBrowse);
            commandBindingManager.AddCommand(ViewModel.BrowseCommand, buttonBrowse);
            commandBindingManager.AddCommand(ViewModel.AddEntryCommand, button2);
        }


        private void OnLoad(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

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


        //-------------------------------
        /*
        void AddCommand(CommandBindingManager cmdBindingManager,
           BoundCommand command, object sourceObject, string sourceEvent = null)
        {
            if (sourceEvent == null) sourceEvent = ControlEvent.Click.ToString();
            var commandBinding = new CommandBinding()
            {
                Command = command,
                SourceObject = sourceObject, //button
                SourceEvent = sourceEvent
            };
            cmdBindingManager.CommandBindings.Add(commandBinding);
        }

        void AddCommand(BoundCommand command, object sourceObject, string sourceEvent = null)
        {
            AddCommand(commandBindingManager, command, sourceObject, sourceEvent);
        }

        */

    }//
}

