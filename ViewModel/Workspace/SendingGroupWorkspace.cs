using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.ViewModel.Entity;
using Docs.Model;

namespace Docs.ViewModel.Workspace
{
    public class SendingGroupWorkspace: DirectoryWorkspace<SendingGroup, SendingGroupViewModel>
    {
        public override SendingGroupViewModel CreateInstance(SendingGroup e)
        {
            return new SendingGroupViewModel(e);
        }

        public SendingGroupWorkspace()
            : base(HandlerStore.Context.SendingGroups, null, w => w.Name) { }

        protected override void CopyObject(SendingGroup source, SendingGroup target)
        {
            base.CopyObject(source, target);
            target.Name = source.Name;
            foreach (var dep in source.Departments)
                target.Departments.Add(dep);
        }
    }
}
