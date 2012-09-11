using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;

namespace Docs.ViewModel.Entity
{
    public class EmployeeViewModel: EntityViewModel<Employee>
    {
        public EmployeeViewModel(Employee employee)
            : base(employee) { }
    }
}
