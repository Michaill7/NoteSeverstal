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
using Aspose.Words;

namespace NoteSeverstal.ViewModels
{
    internal class MainWindowViewModel : ViewModel
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


        public static string selectedListItemForCum;

        private string selectedListItem = "0";
        public string SelectedListItem 
        {
            get => selectedListItem;
            set 
            {
                selectedListItemForCum = value;
                selectedListItem = value;
                OnPropertyChange();
                ShowText();
                
            }
        }

        public static string currentTextForCum;
        private string currentText;
        public string CurrentText 
        {
            get => currentText;
            set 
            {
                currentText = value;
                currentTextForCum = value;
                OnPropertyChange();
            }
        }

        public void ShowText() 
        {
            string currentTextNoteFile = @"../../Models/NoteFiles/" + MainWindowViewModel.selectedListItemForCum+".docx";
            string a = new Document(currentTextNoteFile).GetText();
            CurrentText = a;
        }

        public ICommand Test { get; }
        public ICommand AddTextToNote { get; }

        public MainWindowViewModel()
        {
            Test = new LyambdaCommand(CreateNoteCommand.CreateNoteExecuted, CreateNoteCommand.CreateNoteCanExecrute);
            AddTextToNote = new LyambdaCommand(SaveNote.SaveNoteExecuted, SaveNote.SaveNoteCanExecute);
            Foo();
        }
    }
}
