using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Docs.ViewModel.Workspace
{
    public abstract class WorkspaceBase: ViewModelBase
    {
        public string Header { get; protected set; }
    }
}
