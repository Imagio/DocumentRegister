using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;
using Docs.ViewModel.Entity;

namespace Docs.ViewModel.Workspace
{
    public class MonitoringWorkspace: DirectoryWorkspace<Monitoring, MonitoringViewModel>
    {
        public MonitoringWorkspace()
            : base(HandlerStore.Context.Monitorings, null, mon => mon.Name) { }

        public override MonitoringViewModel CreateInstance(Monitoring e)
        {
            return new MonitoringViewModel(e);
        }

        protected override void CopyObject(Monitoring source, Monitoring target)
        {
            base.CopyObject(source, target);
            target.Name = source.Name;
        }
    }
}
