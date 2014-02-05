using MvvmFx.Windows.Input;

namespace WinPathManager.Helper
{
 public static    class BindingHelper
    {
     public static CommandBindingManager AddCommand(this CommandBindingManager cmdBindingManager,
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
         return cmdBindingManager;
     }
       
    }
}
