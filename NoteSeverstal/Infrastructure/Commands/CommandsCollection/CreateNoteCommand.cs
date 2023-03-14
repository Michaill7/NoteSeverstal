using Aspose.Words;
using NoteSeverstal.Models;
using NoteSeverstal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class CreateNoteCommand
    {
        public static void CreateNoteExecuted(object o) 
        {
            const string MyDir = @"../../Models/NoteFiles/";
            const string jsonListDir = @"../../Models/NoteList.json";
            var doc = new Document();
            var note1 = new Note 
            {
                NoteFileName = "Test1",
                NoteFileWay = MyDir
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
            doc.Save(MyDir + "Test1.docx");
        }


        public static bool CreateNoteCanExecrute(object o) => true;
    }
}
