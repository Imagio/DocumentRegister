using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Docs.Model;
using System.Windows.Input;

namespace Docs.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        public delegate bool NewWindowEventHandler(object sender, string title, object e);
        public event NewWindowEventHandler NewWindow;

        public delegate bool QuestionBoxEventHandler(object sender, string title, string message);
        public event QuestionBoxEventHandler OnQuestion;

        public DocContainer Context { get; private set; }
        public Account Account { get; private set; }

        public MainViewModel(Account account, DocContainer context)
        {
            HandlerStore.Main = this;
            Context = context;
            Account = account;

            CurrentWorkspace = documentWorkspace;
            initWorkspaces();
        }

        private void initWorkspaces()
        {
            directoryWorkspace = new DirectoryWorkspace();
            documentWorkspace = new DocumentWorkspace();
            administrationWorkspace = new AdministrationWorkspace();
        }

        private TabWorkspace currentWorkspace;
        public TabWorkspace CurrentWorkspace
        {
            get { return currentWorkspace; }
            set
            {
                if (currentWorkspace != value)
                {
                    currentWorkspace = value;
                    OnPropertyChanged("CurrentWorkspace");
                }
            }
        }

        public bool OpenNewWindow(string title, object vm)
        {
            if (NewWindow != null)
               return NewWindow(this, title, vm);
            return false;
        }

        public bool AskQuestion(string title, string message)
        {
            if (OnQuestion != null)
                return OnQuestion(this, title, message);
            return false;
        }

        #region TabWorkspaces

        private DirectoryWorkspace directoryWorkspace;
        private DocumentWorkspace documentWorkspace;
        private AdministrationWorkspace administrationWorkspace;
        public ICommand DocumentWorkspaceCommand { get { return new RelayCommand(o => { CurrentWorkspace = documentWorkspace; }); } }
        public ICommand DirectoryWorkspaceCommand { get { return new RelayCommand(o => { CurrentWorkspace = directoryWorkspace; }); } }
        public ICommand AdministrationWorkspaceCommand { get { return new RelayCommand(o => { CurrentWorkspace = administrationWorkspace; }); } }

        #endregion
    }
}
