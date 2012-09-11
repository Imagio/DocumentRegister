using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;
using System.Windows.Input;
using Docs.ViewModel.Selector;

namespace Docs.ViewModel.Entity
{
    public class AccountViewModel: EntityViewModel<Account>
    {
        public AccountViewModel(Account account)
            : base(account) 
        {
            Employees = HandlerStore.Context.Employees.ToList();
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;
                    OnPropertyChanged("SelectedEmployee");
                }
            }
        }

        public IList<Employee> Employees { get; private set; }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(o =>
                    {
                        var employeeSelector = new EmployeeSelector(Employees);
                        if (HandlerStore.Main.OpenNewWindow("Выберите", employeeSelector) &&
                            employeeSelector.SelectedItem != null)
                        {
                            Model.Employees.Add(employeeSelector.SelectedItem);
                        }
                    });
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(o =>
                    {
                        if (Model.Employees.Contains(selectedEmployee))
                            Model.Employees.Remove(selectedEmployee);
                        SelectedEmployee = null;
                    }, o => selectedEmployee != null && Model.Employees.Contains(selectedEmployee));
            }
        }


    }
}
