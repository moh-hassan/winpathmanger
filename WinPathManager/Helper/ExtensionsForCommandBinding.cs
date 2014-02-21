using System;
using System.Windows.Forms;
using MvvmFx.Windows.Input;

namespace WinPathManager.Helper
{
    /// <summary>
    /// Extension methods to utilize MVVM FX for Windows Forms Framework
    /// </summary>
    public static class ExtensionsForCommandBinding
    {
        public static CommandBindingManager RegisterCommand(this CommandBindingManager cmdBindingManager,
             BoundCommand command, object sourceObject, string sourceEvent = "Click")
        {
            var commandBinding = new CommandBinding(command, sourceObject, sourceEvent);
            cmdBindingManager.CommandBindings.Add(commandBinding);
            return cmdBindingManager;
        }


        public static CommandBindingManager RegisterCommand(this CommandBindingManager cmdBindingManager,
             object source, Action<object> execute, Func<object, bool> canExecute, string sourceEvent = "Click")
        {
            var command = new BoundCommand(execute, canExecute, null);
            var commandBinding = new CommandBinding(command, source, sourceEvent);
            cmdBindingManager.CommandBindings.Add(commandBinding);
            return cmdBindingManager;
        }

        public static CommandBindingManager RegisterCommand(this CommandBindingManager cmdBindingManager,
                                                       object source, Action<object> execute)
        {
            return RegisterCommand(cmdBindingManager, source, execute, o => true, "Click");
        }
    }
}

