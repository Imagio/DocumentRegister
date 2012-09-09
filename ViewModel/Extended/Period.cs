using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Docs.ViewModel.Extended
{
    public class Period: ViewModelBase
    {
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    if (startDate > endDate)
                        EndDate = startDate;
                    OnPropertyChanged("StartDate");
                }
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    if (startDate > endDate)
                        StartDate = endDate;
                    OnPropertyChanged("EndDate");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0:d} - {1:d}", startDate, endDate);
        }

        public ICommand ClearCommand
        {
            get
            {
                return new RelayCommand(o =>
                    {
                        StartDate = DateTime.MinValue;
                        EndDate = DateTime.MinValue;
                        OnPropertyChanged("");
                    });
            }
        }
        public ICommand ChangeCommand
        {
            get
            {
                return new RelayCommand(o =>
                    {
                        PeriodChanger pc = new PeriodChanger(this);
                        if (HandlerStore.Main.OpenNewWindow("Период", pc))
                        {
                            this.StartDate = pc.Period.StartDate;
                            this.EndDate = pc.Period.EndDate;
                        }
                    });
            }
        }
    }
}
