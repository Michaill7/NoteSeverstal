using NoteSeverstal.Views;

namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class OpenNoteNameWindow
    {
        public static NoteNameWindow NewNoteNameWindow;
        public static void OpenNoteNameWindowExecuted(object o) 
        {
            NewNoteNameWindow = new NoteNameWindow();
            NewNoteNameWindow.Show();
        }

        public static bool OpenNoteNameWindowCanExecute(object o) => true;
    }
}
