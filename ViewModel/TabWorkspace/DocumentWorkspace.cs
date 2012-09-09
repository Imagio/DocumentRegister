using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Docs.ViewModel
{
    public class DocumentWorkspace: TabWorkspace
    {
        public DocumentWorkspace()
        {
        }

        private DecreeWorkspace decreeWorkspace = new DecreeWorkspace();

        public ICommand DecreeCommand { get { return new RelayCommand(o => { CurrentWorkspace = decreeWorkspace; }); } }
    }
}
