using NoteSeverstal.ViewModels;
using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class SaveNote
    {
        public static void SaveNoteExecuted(object o)
        {
            string currentTextNoteFile = @"../../Models/NoteFiles/" + MainWindowViewModel.selectedListItemForCum+".docx";
            var Doc = new Document(currentTextNoteFile);
            var builder = new DocumentBuilder(Doc);
            builder.Write(MainWindowViewModel.currentTextForCum);
            Doc.Save(currentTextNoteFile);

        }
        public static bool SaveNoteCanExecute(object o) 
        {
            if (MainWindowViewModel.selectedListItemForCum != null)
                return true;
            else
                return false;
        }
    }
}
