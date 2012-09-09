using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ImagioMonads;

namespace Docs.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {
        public delegate void LoginEventHandler(object sender, Account account, DocContainer context);
        public event LoginEventHandler LoginComplete;

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        DocContainer context = new DocContainer();

        public LoginViewModel()
        {
            AccountList = new ObservableCollection<Account>(context.Accounts.OrderBy(o => o.UserName).ToList());
        }

        public ObservableCollection<Account> AccountList { get; private set; }

        private Account selectedAccount;
        public Account SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                if (selectedAccount != value)
                {
                    selectedAccount = value;
                    OnPropertyChanged("SelectedAccount");
                }
            }
        }

        public ICommand SignInCommand
        {
            get
            {
                return new RelayCommand(o =>
                    {
                        if (SelectedAccount
                                .If(account => account.IsActive)
                                .With(account => account.Password)
                                .If(pwd => pwd == PasswordHasher.Calc(Password))
                                .ReturnSuccess() || context.Accounts.Count() == 0)
                        {
                            if (LoginComplete != null)
                                LoginComplete(this, selectedAccount, context);
                        }
                    });
            }
        }
    }
}
