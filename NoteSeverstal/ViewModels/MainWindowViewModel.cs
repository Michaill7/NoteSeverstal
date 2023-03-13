using NoteSeverstal.Infrastructure.Commands;
using NoteSeverstal.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NoteSeverstal.Infrastructure.Commands.CommandsCollection;
using NoteSeverstal.Models;
using System.Windows;

namespace NoteSeverstal.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public void Foo() 
        {
            const string jsonListDir = @"../../Models/NoteList.json";
            var Notes = JsonCustomer.Deserialization(jsonListDir);
            if (Notes is null) 
                return;
            var NotesName = new List<string>() { };
            foreach (var item in Notes)
                NotesName.Add(item.NoteFileName);
            NoteNames = NotesName;
            ActualNoteList = NoteNames;

        }
        private List<string> NoteNames;

        private List<string> actualNoteList;
        public List<string> ActualNoteList 
        {
            get => actualNoteList;
            set 
            {
                actualNoteList = value;
                OnPropertyChange();
            }
        }



        public ICommand Test { get; }

        public MainWindowViewModel()
        {
            Test = new LyambdaCommand(CreateNoteCommand.CreateNoteExecuted, CreateNoteCommand.CreateNoteCanExecrute);
            Foo();
        }
    }
}
