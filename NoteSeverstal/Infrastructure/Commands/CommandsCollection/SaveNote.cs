using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteSeverstal.Infrastructure.Commands.CommandsCollection
{
    internal abstract class SaveNote
    {
        public void SaveNoteExecuted(object o) 
        {

        }

        public bool SaveNoteCanExecute(object o) 
        {
            return true;
        }
    }
}
