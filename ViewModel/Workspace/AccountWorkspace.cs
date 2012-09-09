using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Docs.Model;
using System.Windows.Input;
using System.Security.Cryptography;
using ImagioMonads;
using System.ComponentModel;
using System.Windows.Data;
using Docs.ViewModel.Searcher;

namespace Docs.ViewModel
{
    public class AccountWorkspace: Workspace
    {
        public AccountWorkspace()
        {
            Header = "Учетные записи пользователей";
            AccountCollection = new ObservableCollection<Account>(HandlerStore.Main.Context.Accounts.ToList());
            accountCollectionView = (ICollectionView)CollectionViewSource.GetDefaultView(AccountCollection);
        }

        ICollectionView accountCollectionView;
        private AccountSearcher accountSearcher = new AccountSearcher();

        public ObservableCollection<Account> AccountCollection { get; private set; }

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

      

        public ICommand CreateNewCommand
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Account account = new Account();
                    var result = HandlerStore.Main.OpenNewWindow("Учетная запись", account);
                    if (result)
                    {
                        account.LastAccessTime = null;
                        var hsh = account.Return(acc => acc.Password, String.Empty).Return(pwd => PasswordHasher.Calc(pwd), String.Empty);
                        account.Password = hsh;
                        HandlerStore.Main.Context.Accounts.AddObject(account);
                        HandlerStore.Main.Context.SaveChanges();
                        AccountCollection.Add(account);
                    }
                });
            }
        }
        public ICommand CreateCopyCommand
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Account account = new Account();

                    account.UserName = SelectedAccount.UserName;
                    account.IsActive = SelectedAccount.IsActive;
                    account.Password = SelectedAccount.Password;

                    if (HandlerStore.Main.OpenNewWindow("Учетная запись пользователя", account))
                    {
                        account.LastAccessTime = null;
                        var hsh = account.Return(acc => acc.Password, String.Empty).Return(pwd => PasswordHasher.Calc(pwd), String.Empty);
                        account.Password = hsh;
                        HandlerStore.Main.Context.Accounts.AddObject(account);
                        HandlerStore.Main.Context.SaveChanges();
                        AccountCollection.Add(account);
                    }
                }, o => SelectedAccount != null && AccountCollection.Contains(SelectedAccount));
            }
        }
        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(o =>
                {
                    var account = selectedAccount;
                    if (HandlerStore.Main.OpenNewWindow("Учетная запись", account))
                    {
                        if (!String.IsNullOrEmpty(account.Password))
                        {
                            var hsh = account.Return(acc => acc.Password, String.Empty).Return(pwd => PasswordHasher.Calc(pwd), String.Empty);
                            account.Password = hsh;
                            HandlerStore.Main.Context.SaveChanges();
                        }
                    }
                    else
                    {
                        HandlerStore.Main.Context.Refresh(System.Data.Objects.RefreshMode.StoreWins, account);
                    }
                }, o => SelectedAccount != null && AccountCollection.Contains(SelectedAccount));
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(o =>
                    {
                        if (!HandlerStore.Main.AskQuestion("Удаление учетной записи", "Вы действительно хотите удалить учетную запись?"))
                            return;
                        var account = SelectedAccount;
                        HandlerStore.Main.Context.Accounts.DeleteObject(account);
                        HandlerStore.Main.Context.SaveChanges();
                        AccountCollection.Remove(account);
                    }, o => SelectedAccount != null && AccountCollection.Contains(SelectedAccount));
            }
        }
        public ICommand FindCommand
        {
            get
            {
                return new RelayCommand(o =>
                    {
                        if (HandlerStore.Main.OpenNewWindow("Поиск учетных записей", accountSearcher))
                        {
                            accountCollectionView.Filter = accountSearcher.Filter;
                        }
                    });
            }
        }
        public ICommand ClearFindCommand
        {
            get
            {
                return new RelayCommand(o =>
                    {
                        accountCollectionView.Filter = null;
                    });
            }
        }
    }
}
