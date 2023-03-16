namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class CloseWindowCommand
    {
        public static void CloseWindowCommandExecuted(object o) 
        {
            OpenNoteNameWindow.NewNoteNameWindow.Close();
        }

        public static bool CloseWindowCommandCanExecute(object o) => true;
    }
}
