using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Docs.ViewModel
{
    public class DecreeWorkspace: Workspace
    {
        public DecreeWorkspace()
        {
            Header = "Приказы";
            Items = new ObservableCollection<string>();

            Period = new Extended.Period()
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(7)
            };
        }

        public ObservableCollection<string> Items { get; private set; }

        public Extended.Period Period { get; private set; }
    }
}
