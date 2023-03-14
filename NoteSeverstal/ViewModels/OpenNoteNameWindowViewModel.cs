using NoteSeverstal.Infrastructure.Commands;
using NoteSeverstal.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NoteSeverstal.Infrastructure.Commands.CommandsCollection;

namespace NoteSeverstal.ViewModels
{
    class OpenNoteNameWindowViewModel : ViewModel
    {
        public ICommand OpenNoteNameWindows { get;}
        public ICommand CloseWinCommand { get; }
        public OpenNoteNameWindowViewModel()
        {
            OpenNoteNameWindows = new LyambdaCommand(OpenNoteNameWindow.OpenNoteNameWindowExecuted, OpenNoteNameWindow.OpenNoteNameWindowCanExecute);
            CloseWinCommand = new LyambdaCommand(CloseWindowCommand.CloseWindowCommandExecuted, CloseWindowCommand.CloseWindowCommandCanExecute);
        }
    }
}
