using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Docs.ViewModel
{
    public abstract class TabWorkspace:  ViewModelBase
    {
        private Workspace currentWorkspace;
        public Workspace CurrentWorkspace
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
