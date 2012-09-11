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
using Docs.ViewModel.Entity;

namespace Docs.ViewModel.Workspace
{
    public class DepartmentWorkspace: DirectoryWorkspace<Department, DepartmentViewModel>
    {
        public DepartmentWorkspace()                                       
            : base(HandlerStore.Context.Departments, new DepartmentSearcher(), w => w.Code) { }

        protected override void CopyObject(Department source, Department target)
        {
            base.CopyObject(source, target);
            target.Code = source.Code;
            target.Name = source.Name;
        }

        public override DepartmentViewModel CreateInstance(Department e)
        {
            return new DepartmentViewModel(e);
        }
    }
}
