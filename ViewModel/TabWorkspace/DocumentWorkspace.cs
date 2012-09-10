using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Docs.ViewModel.Workspace;

namespace Docs.ViewModel.TabWorkspace
{
    public class DocumentWorkspace: TabWorkspaceBase
    {
        private DecreeWorkspace decreeWorkspace;

        public ICommand DecreeCommand 
        { 
            get 
            { 
                return new RelayCommand(o => 
                {
                    if (decreeWorkspace == null)
                        decreeWorkspace = new DecreeWorkspace();
                    CurrentWorkspace = decreeWorkspace; 
                }); 
            } 
        }
    }
}
