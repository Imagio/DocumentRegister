using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Docs.ViewModel
{
    public abstract class Workspace: ViewModelBase
    {
        public string Header { get; protected set; }
    }
}
