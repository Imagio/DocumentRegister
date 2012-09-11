using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;

namespace Docs.ViewModel.Selector
{
    public class EmployeeSelector: Selector<Employee>
    {
        public EmployeeSelector(IList<Employee> employees)
            : base(employees) { }
    }
}
