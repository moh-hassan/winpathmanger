using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace WinPathManager.Helper
{
    /// <summary>
    /// Raise Events
    /// Example: AddEntry.Raise (this , new EventArgs())
    /// </summary>
    public static class ExtensionsForEventHandler
    {
        public static void Raise<T>(this EventHandler<T> handler, object sender, T args)
          where T : EventArgs
        {
            EventHandler<T> evt = handler;
            if (evt != null) evt(sender, args);
        }
    }
}

 
