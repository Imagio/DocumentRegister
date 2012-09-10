using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Docs.Model;
using System.ComponentModel;
using System.Windows.Data;
using Docs.ViewModel.Searcher;
using System.Windows.Input;

namespace Docs.ViewModel.Workspace
{
    public class DepartmentWorkspace: DirectoryWorkspace<Department>
    {
        public DepartmentWorkspace()
            : base(HandlerStore.Context.Departments, new DepartmentSearcher()) { }

        protected override void CopyObject(Department source, Department target)
        {
            base.CopyObject(source, target);
        }

        protected override void InitStartValue(Department e)
        {
            base.InitStartValue(e);
            e.Name = "new";
            e.Code = "01";
        }
    }
}
