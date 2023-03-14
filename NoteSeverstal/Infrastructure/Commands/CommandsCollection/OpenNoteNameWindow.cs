using NoteSeverstal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class OpenNoteNameWindow
    {
        public static void OpenNoteNameWindowExecuted(object o) 
        {
            var NewNoteNameWindow = new NoteNameWindow();
            NewNoteNameWindow.Show();
        }

        public static bool OpenNoteNameWindowCanExecute(object o) => true;
    }
}
