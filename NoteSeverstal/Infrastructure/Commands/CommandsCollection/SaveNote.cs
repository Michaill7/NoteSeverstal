using NoteSeverstal.ViewModels;
using System.IO;

namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class SaveNote
    {
        public static void SaveNoteExecuted(object o)
        {
            string currentTextNoteFile = @"../../Models/NoteFiles/" + MainWindowViewModel.selectedListItemForTransfer + ".docx";
            File.WriteAllText(currentTextNoteFile, MainWindowViewModel.currentTextForTransfer);
        }
        public static bool SaveNoteCanExecute(object o) 
        {
            if (MainWindowViewModel.selectedListItemForTransfer != null)
                return true;
            else
                return false;
        }
    }
}
