using NoteSeverstal.Models;
using NoteSeverstal.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class CreateNoteCommand
    {
        public static void CreateNoteExecuted(object o) 
        {
            const string MyDir = @"../../Models/NoteFiles/";
            const string jsonListDir = @"../../Models/NoteList.json";
            var note1 = new Note 
            {
                NoteFileName = OpenNoteNameWindowViewModel.NoteNameFor,
                NoteFileWay = MyDir,
                NoteFileDescription = OpenNoteNameWindowViewModel.NoteDescriptionFor
            };
            var Notes =JsonCustomer.Deserialization(jsonListDir);
            if (Notes == null)
                Notes = new List<Note>() { };
            foreach (var item in Notes)
            {
                if (note1.NoteFileName == item.NoteFileName) 
                {
                    MessageBox.Show("Заметка с тамим названием уже сущесвтует");
                    return;
                }
            }
            Notes.Add(note1);
            JsonCustomer.Serialization(Notes, jsonListDir);
            File.WriteAllText(MyDir + $"{OpenNoteNameWindowViewModel.NoteNameFor}.docx", "");
            MainWindowViewModel.AddNoteDel();
        }


        public static bool CreateNoteCanExecrute(object o) => true;
    }
}
