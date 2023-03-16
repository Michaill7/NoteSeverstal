using NoteSeverstal.Infrastructure.Commands;
using NoteSeverstal.ViewModels.Base;
using System.Windows.Input;
using NoteSeverstal.Infrastructure.Commands.CommandsCollection;

namespace NoteSeverstal.ViewModels
{
    internal class OpenNoteNameWindowViewModel : ViewModel
    {
        #region NoteNameProperty
        public static string NoteNameFor;

        private string noteName;
        //Свойство названия новой заметки
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
        #endregion NoteNameProperty

        #region NoteDescriptionProperty
        public static string NoteDescriptionFor;
        private string noteDescription;
        //Свойство описания новой заметки
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
        #endregion NoteDescriptionProperty

        #region Commands
        //Команда для создания новой заметки
        public ICommand CreateNewNote { get;}
        //Команда закрытия текущего окна
        public ICommand CloseWinCommand { get; }
        #endregion Commands
        public OpenNoteNameWindowViewModel()
        {
            CreateNewNote = new LyambdaCommand(CreateNoteCommand.CreateNoteExecuted, CreateNoteCommand.CreateNoteCanExecrute);
            CloseWinCommand = new LyambdaCommand(CloseWindowCommand.CloseWindowCommandExecuted, CloseWindowCommand.CloseWindowCommandCanExecute);
        }
    }
}
