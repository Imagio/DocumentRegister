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

namespace Docs.View.Detail
{
    /// <summary>
    /// Логика взаимодействия для AccountDetailView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        public AccountView()
        {
            InitializeComponent();
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var model = this.DataContext.GetType().GetProperty("Model").GetValue(this.DataContext, null);
            model.GetType().GetProperty("Password").SetValue(model, (sender as PasswordBox).Password, null);
        }
    }
}
