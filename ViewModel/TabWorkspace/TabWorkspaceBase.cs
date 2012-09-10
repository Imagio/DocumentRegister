using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Docs.ViewModel.TabWorkspace
{
    public abstract class TabWorkspaceBase:  ViewModelBase
    {
        private Workspace.WorkspaceBase currentWorkspace;
        public Workspace.WorkspaceBase CurrentWorkspace
        {
            get { return currentWorkspace; }
            set
            {
                if (currentWorkspace != value)
                {
                    currentWorkspace = value;
                    OnPropertyChanged("CurrentWorkspace");
                }
            }
        }
    }
}
