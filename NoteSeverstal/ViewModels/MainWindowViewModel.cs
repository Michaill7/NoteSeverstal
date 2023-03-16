using NoteSeverstal.Infrastructure.Commands;
using NoteSeverstal.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;
using NoteSeverstal.Infrastructure.Commands.CommandsCollection;
using NoteSeverstal.Models;
using System.IO;

namespace NoteSeverstal.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region AddNoteFileToList
        public delegate void AddNoteFileToListDel();
        public static AddNoteFileToListDel AddNoteDel = null;

        private List<string> NoteNames;
        //Метод добавляет Созданную заметку в Json документ со списком
        public void AddNoteFileToList() 
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
        #endregion AddNoteFileToList

        #region ActualNoteListToSystem
        private List<string> actualNoteList;
        //Свойство - список названий заметок, которые отображаются в системе
        public List<string> ActualNoteList 
        {
            get => actualNoteList;
            set 
            {
                actualNoteList = value;
                OnPropertyChange();

            }
        }
        #endregion ActualNoteListToSystem

        #region SelectedItem
        public static string selectedListItemForTransfer;

        private string selectedListItem = null;
        //Свойство с ифнормацией о выбранной заметке в списке приложения
        public string SelectedListItem 
        {
            get => selectedListItem;
            set 
            {
                selectedListItemForTransfer = value;
                selectedListItem = value;
                OnPropertyChange();
                ShowText();
                
            }
        }
        #endregion SelectedItem

        #region CurrentTextIntoTextbox
        public static string currentTextForTransfer;
        private string currentText;
        //Свойство, содержащее данные с текстом выбранной заметки
        public string CurrentText 
        {
            get => currentText;
            set 
            {
                currentText = value;
                currentTextForTransfer = value;
                OnPropertyChange();
            }
        }
        #endregion CurrentTextIntoTextbox

        #region DescriptionTextForNote
        private string descriptionText;
        //Свойство, содержащее описание выбранной заметки
        public string DescriptionText 
        {
            get => descriptionText;
            set 
            {
                descriptionText = value;
                OnPropertyChange();
            }        
        }
        #endregion DescriptionTextForNote

        #region ShowTextMethod
        //Метод, выводящий в TextBox содержание выбранной заметки
        public void ShowText() 
        {
            string currentTextNoteFile = @"../../Models/NoteFiles/" + MainWindowViewModel.selectedListItemForTransfer+ ".docx";
            try
            {
                File.ReadAllText(currentTextNoteFile);
            }
            catch (System.IO.FileNotFoundException) 
            {
                CurrentText = "";
                DescriptionText = "";
                return;
            }
            var a = File.ReadAllText(currentTextNoteFile);
            if (a == null)
                CurrentText = "";
            CurrentText = a;
            const string jsonListDir = @"../../Models/NoteList.json";
            var Notes = JsonCustomer.Deserialization(jsonListDir);
            foreach (var item in Notes)
            {
                if (item.NoteFileName == SelectedListItem)
                {
                    DescriptionText = item.NoteFileDescription;
                    return;
                }
            }
        }
        #endregion ShowTextMethod

        #region Commands
        //Команда, открывающая окно создания новой заметки
        public ICommand OpenNoteWindow { get; }
        //Команда для сохранения текста заметки
        public ICommand AddTextToNote { get; }
        //Команда для удаления выбранной заметки
        public ICommand DeleteNote { get; }
        #endregion Commands
        public MainWindowViewModel()
        {
            OpenNoteWindow = new LyambdaCommand(OpenNoteNameWindow.OpenNoteNameWindowExecuted, OpenNoteNameWindow.OpenNoteNameWindowCanExecute);
            AddTextToNote = new LyambdaCommand(SaveNote.SaveNoteExecuted, SaveNote.SaveNoteCanExecute);
            DeleteNote = new LyambdaCommand(DeleteNoteCommand.DeleteNoteCommandExecuted, DeleteNoteCommand.DeleteNoteCommandCanExecute);
            AddNoteFileToList();
            AddNoteDel += AddNoteFileToList;
        }
    }
}
