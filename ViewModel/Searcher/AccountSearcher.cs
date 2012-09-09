using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;

namespace Docs.ViewModel.Searcher
{
    public class AccountSearcher: ViewModelBase
    {
        public Predicate<object> Filter 
        {
            get { return account => (account as Account).UserName.ToLower().Contains(userName.ToLower()); }
        }

        private string userName = "";
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }
    }
}
