using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;

namespace Docs.ViewModel.Entity
{
    public class DepartmentViewModel: EntityViewModel<Department>
    {
        public DepartmentViewModel (Department department)
            : base(department) { }

        
    }
}
