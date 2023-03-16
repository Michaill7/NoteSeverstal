using NoteSeverstal.Models;
using NoteSeverstal.ViewModels;
using System.IO;

namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class DeleteNoteCommand
    {
        public static void DeleteNoteCommandExecuted(object o) 
        {
            const string jsonListDir = @"../../Models/NoteList.json";
            var Notes = JsonCustomer.Deserialization(jsonListDir);
            var currentItem = new Note();
            foreach (var item in Notes)
            {
                if (!(item.NoteFileName == MainWindowViewModel.selectedListItemForTransfer))
                {
                    continue;
                }
                currentItem = item;
            }
            Notes.Remove(currentItem);
            JsonCustomer.Serialization(Notes, jsonListDir);
            string currentTextNoteFile = @"../../Models/NoteFiles/" + MainWindowViewModel.selectedListItemForTransfer + ".docx";
            File.Delete(currentTextNoteFile);
            MainWindowViewModel.AddNoteDel();

        }

        public static bool DeleteNoteCommandCanExecute(object o) 
        {
            if (MainWindowViewModel.selectedListItemForTransfer != null)
                return true;
            else
                return false;
        }
    }
}
