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
            if (this.DataContext is IDataErrorInfo && (this.DataContext as IDataErrorInfo).Error != null)
            {
                MessageBox.Show("Данные содержат ошибки:\n" + (this.DataContext as IDataErrorInfo).Error, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
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
