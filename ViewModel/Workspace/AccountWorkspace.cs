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
using System.Diagnostics;
using Docs.ViewModel.Entity;

namespace Docs.ViewModel.Workspace
{
    public class AccountWorkspace: WorkspaceBase
    {
        public AccountWorkspace()
        {
            Header = selectedAccount.ListTitle();
            AccountCollection = new ObservableCollection<Account>(HandlerStore.Main.Context.Accounts.ToList());
            accountCollectionView = (ICollectionView)CollectionViewSource.GetDefaultView(AccountCollection);
        }

        ICollectionView accountCollectionView;
        private ISearcher accountSearcher = new AccountSearcher();

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
                    var result = HandlerStore.Main.OpenNewWindow(account.NormalTitle(), new AccountViewModel(account));
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

                    if (HandlerStore.Main.OpenNewWindow(account.NormalTitle(), new AccountViewModel(account)))
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
                    if (HandlerStore.Main.OpenNewWindow(account.NormalTitle(), new AccountViewModel(account)))
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
                        if (!HandlerStore.Main.AskQuestion(selectedAccount.DeleteTitle(), "Вы действительно хотите удалить элемент?"))
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
                        if (HandlerStore.Main.OpenNewWindow(selectedAccount.SearchTitle(), accountSearcher))
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
