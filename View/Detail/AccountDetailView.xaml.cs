﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Docs.View
{
    /// <summary>
    /// Логика взаимодействия для AccountDetailView.xaml
    /// </summary>
    public partial class AccountDetailView : UserControl
    {
        public AccountDetailView()
        {
            InitializeComponent();
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.DataContext.GetType().GetProperty("Password").SetValue(this.DataContext, (sender as PasswordBox).Password, null);
        }
    }
}
