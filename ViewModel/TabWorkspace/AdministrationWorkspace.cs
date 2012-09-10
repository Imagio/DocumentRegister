using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Docs.ViewModel.Workspace;

namespace Docs.ViewModel.TabWorkspace
{
    public class AdministrationWorkspace: TabWorkspaceBase
    {
        private AccountWorkspace accountWorksapce;

        public ICommand AccountCommand 
        { 
            get 
            { 
                return new RelayCommand(o =>
                {
                    if (accountWorksapce == null)
                        accountWorksapce = new AccountWorkspace();
                    CurrentWorkspace = accountWorksapce; 
                }); 
            } 
        }
    }
}
