using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Docs.ViewModel
{
    public class AdministrationWorkspace: TabWorkspace
    {
        private AccountWorkspace acountWorksapce = new AccountWorkspace();

        public ICommand AccountCommand { get { return new RelayCommand(o => { CurrentWorkspace = acountWorksapce; }); } }
    }
}
