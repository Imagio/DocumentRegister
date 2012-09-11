using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;
using Docs.ViewModel.Entity;

namespace Docs.ViewModel.Workspace
{
    public class EmployeeWorkspace: DirectoryWorkspace<Employee, EmployeeViewModel>
    {
        public EmployeeWorkspace()
            : base(HandlerStore.Context.Employees, null, w => w.Name) { }

        public override EmployeeViewModel CreateInstance(Employee e)
        {
            return new EmployeeViewModel(e);
        }
    }
}
