using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Docs.ViewModel.Extended
{
    public class PeriodChanger: ViewModelBase
    {
        private static string userDefPeriod     = "Произвольный период";
        private static string thisWeekPeriod    = "Эта неделя";
        private static string thisMonthPeriod   = "Этот месяц";
        private static string thisYearPeriod    = "Этот год";

        private bool changing = false;

        public PeriodChanger(Period period)
        {
            PeriodChanger.period.StartDate = period.StartDate;
            PeriodChanger.period.EndDate = period.EndDate;

            Period.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Period_PropertyChanged);
        }

        void Period_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!changing)
                CurrentPeriod = userDefPeriod;
        }

        public static Period period = new Period();
        public Period Period { get { return period;} }

        private static List<string> periodList = new List<string>() 
        { 
            userDefPeriod,
            thisWeekPeriod,
            thisMonthPeriod,
            thisYearPeriod
        };
        public List<string> PeriodList { get { return periodList; } }

        private string currentPeriod = userDefPeriod;
        public string CurrentPeriod 
        {
            get { return currentPeriod; }
            set
            {
                if (currentPeriod != value)
                {
                    currentPeriod = value;
                    if (currentPeriod == thisWeekPeriod)
                    {
                        changing = true;
                        var day_num = (int)DateTime.Today.DayOfWeek - 1;
                        Period.StartDate = DateTime.Today.AddDays(-day_num);
                        Period.EndDate = DateTime.Today.AddDays(-day_num + 6);
                    }
                    if (currentPeriod == thisMonthPeriod)
                    {
                        changing = true;
                        var days_count = (int)DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
                        Period.StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        Period.EndDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, days_count);
                    }
                    if (currentPeriod == thisYearPeriod)
                    {
                        changing = true;
                        Period.StartDate = new DateTime(DateTime.Today.Year, 1, 1);
                        Period.EndDate = new DateTime(DateTime.Today.Year, 12, 31);
                    }
                    changing = false;
                    OnPropertyChanged("CurrentPeriod");
                }
            }
        }
    }
}
