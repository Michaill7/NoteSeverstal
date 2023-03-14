using NoteSeverstal.Infrastructure.Commands;
using NoteSeverstal.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NoteSeverstal.Infrastructure.Commands.CommandsCollection;
using System.Windows;

namespace NoteSeverstal.ViewModels
{
    internal class OpenNoteNameWindowViewModel : ViewModel
    {
        public static string NoteNameFor;

        private string noteName;
        public string NoteName 
        {
            get => noteName;
            set 
            {
                noteName = value;
                NoteNameFor = value;
                OnPropertyChange();
            }
        }


        public static string NoteDescriptionFor;
        private string noteDescription;
        public string NoteDescription
        {
            get => noteDescription;
            set
            {
                noteDescription = value;
                NoteDescriptionFor = NoteDescription;
                OnPropertyChange();
            }
        }


        public ICommand CreateNewNote { get;}
        public ICommand CloseWinCommand { get; }
        public OpenNoteNameWindowViewModel()
        {
            CreateNewNote = new LyambdaCommand(CreateNoteCommand.CreateNoteExecuted, CreateNoteCommand.CreateNoteCanExecrute);
            CloseWinCommand = new LyambdaCommand(CloseWindowCommand.CloseWindowCommandExecuted, CloseWindowCommand.CloseWindowCommandCanExecute);
        }
    }
}
