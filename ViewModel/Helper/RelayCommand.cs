using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;

namespace Docs.ViewModel
{
    public class RelayCommand : RelayCommand<object>
    {
        #region Constructors
        public RelayCommand(Action<object> execute)
            : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            : base(execute, canExecute) { }
        #endregion // Constructors
    }

    public class RelayCommand<E> : ICommand where E : class
    {
        #region Fields

        readonly Action<E> _execute;
        readonly Predicate<E> _canExecute;

        #endregion // Fields

        #region Constructors

        public RelayCommand(Action<E> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<E> execute, Predicate<E> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((E)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute((E)parameter);
        }

        #endregion // ICommand Members
    }
}
