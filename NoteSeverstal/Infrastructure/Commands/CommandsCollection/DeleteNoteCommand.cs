using Aspose.Words;
using NoteSeverstal.Models;
using NoteSeverstal.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                if (!(item.NoteFileName == MainWindowViewModel.selectedListItemForCum))
                {
                    continue;
                }
                currentItem = item;
            }
            Notes.Remove(currentItem);
            JsonCustomer.Serialization(Notes, jsonListDir);
            string currentTextNoteFile = @"../../Models/NoteFiles/" + MainWindowViewModel.selectedListItemForCum + ".docx";
            File.Delete(currentTextNoteFile);

        }

        public static bool DeleteNoteCommandCanExecute(object o) 
        {
            if (MainWindowViewModel.selectedListItemForCum != null)
                return true;
            else
                return false;
        }
    }
}
