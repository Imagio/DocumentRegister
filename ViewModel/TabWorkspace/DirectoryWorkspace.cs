using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.ViewModel.Workspace;
using System.Windows.Input;

namespace Docs.ViewModel.TabWorkspace
{
    public class DirectoryWorkspace: TabWorkspaceBase
    {
        DepartmentWorkspace departmentWorkspace;
        public ICommand DepartmentCommand
        {
            get
            {
                return new RelayCommand(o =>
                    {
                        if (departmentWorkspace == null)
                            departmentWorkspace = new DepartmentWorkspace();
                        CurrentWorkspace = departmentWorkspace;
                    });
            }
        }
    }
}
