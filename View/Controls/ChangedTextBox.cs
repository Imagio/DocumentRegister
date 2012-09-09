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

namespace Docs.View.Controls
{
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Docs.View.Controls"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Docs.View.Controls;assembly=Docs.View.Controls"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:ChangedTextBox/>
    ///
    /// </summary>
    public class ChangedTextBox : TextBox
    {
        static ChangedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChangedTextBox), new FrameworkPropertyMetadata(typeof(ChangedTextBox)));
        }

        public ICommand ClearCommand
        {
            get { return (ICommand)GetValue(ClearCommandProperty); }
            set { SetValue(ClearCommandProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ClearCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearCommandProperty =
            DependencyProperty.Register("ClearCommand", typeof(ICommand), typeof(ChangedTextBox), new UIPropertyMetadata(null));

        public object ClearCommandParameter
        {
            get { return (object)GetValue(ClearCommandParameterProperty); }
            set { SetValue(ClearCommandParameterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ClearCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearCommandParameterProperty =
            DependencyProperty.Register("ClearCommandParameter", typeof(object), typeof(ChangedTextBox), new UIPropertyMetadata(null));

        public ICommand ChangeCommand
        {
            get { return (ICommand)GetValue(ChangeCommandProperty); }
            set { SetValue(ChangeCommandProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ChangeCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChangeCommandProperty =
            DependencyProperty.Register("ChangeCommand", typeof(ICommand), typeof(ChangedTextBox), new UIPropertyMetadata(null));

        public object ChangeCommandParameter
        {
            get { return (object)GetValue(ChangeCommandParameterProperty); }
            set { SetValue(ChangeCommandParameterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ChangeCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChangeCommandParameterProperty =
            DependencyProperty.Register("ChangeCommandParameter", typeof(object), typeof(ChangedTextBox), new UIPropertyMetadata(null));
    }
}
