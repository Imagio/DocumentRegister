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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Docs.View
{
    /// <summary>
    /// Логика взаимодействия для AccountWorkspaceView.xaml
    /// </summary>
    public partial class AccountWorkspaceView : UserControl
    {
        public AccountWorkspaceView()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ICommand editCommand = DataContext.GetType().GetProperty("EditCommand").GetValue(DataContext, null) as ICommand;
                if (editCommand.CanExecute(null))
                    editCommand.Execute(null);
            }
            catch
            {
            }
        }
    }
}
