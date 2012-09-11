using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;

namespace Docs.ViewModel.Entity
{
    public class MonitoringViewModel: EntityViewModel<Monitoring>
    {
        public MonitoringViewModel(Monitoring monitoring)
            : base(monitoring) { }
    }
}
