using System;
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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Reflection;

namespace Docs.DesktopApp
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            PropertyInfo pi = this.DataContext.GetType().GetProperty("Model");
            if (pi != null)
            {
                var model = pi.GetValue(this.DataContext, null);
                PropertyInfo error = model.GetType().GetProperty("Error");
                if (error != null)
                {
                    string errorMessage = (string)error.GetValue(model, null);
                    if (errorMessage != null)
                    {
                        MessageBox.Show("Данные содержат ошибки:\n" + errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
            DialogResult = true;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SizeToContent = System.Windows.SizeToContent.Manual;
        }
    }
}
