using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Docs.ViewModel;
using Docs.Model;

namespace Docs.DesktopApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        Shell shell;
        LoginWindow lw;

        void App_Startup(object sender, StartupEventArgs e)
        {
            shell = new Shell();

            lw = new LoginWindow();
            LoginViewModel loginVM = new LoginViewModel();
            loginVM.LoginComplete += new LoginViewModel.LoginEventHandler(loginVM_LoginComplete);

            lw.DataContext = loginVM;
            if (lw.ShowDialog() == false)
                App.Current.Shutdown();

        }

        void loginVM_LoginComplete(object sender, Account account, DocContainer context)
        {
            if (context == null)
                lw.DialogResult = false;
            else
                lw.DialogResult = true;
            MainViewModel main = new MainViewModel(account, context);
            shell.DataContext = main;
            main.NewWindow += new MainViewModel.NewWindowEventHandler(main_NewWindow);
            main.OnQuestion += new MainViewModel.QuestionBoxEventHandler(main_OnQuestion);
            shell.Show();
        }

        bool main_OnQuestion(object sender, string title, string message)
        {
            return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes ? true : false;
        }

        bool main_NewWindow(object sender, string title, object e)
        {
            DialogWindow dw = new DialogWindow();
            dw.Title = title;
            dw.DataContext = e;
            if (dw.ShowDialog() == true)
                return true;
            return false;
        }
    }
}
