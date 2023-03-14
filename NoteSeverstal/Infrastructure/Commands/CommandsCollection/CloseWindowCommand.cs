using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class CloseWindowCommand
    {
        public static void CloseWindowCommandExecuted(object o) 
        {
            Application.Current.Shutdown();
            
        }

        public static bool CloseWindowCommandCanExecute(object o) => true;
    }
}
