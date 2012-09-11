using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;
using System.Data.Objects.DataClasses;

namespace Docs.ViewModel.Entity
{
    public class SendingGroupViewModel: EntityViewModel<SendingGroup>
    {
        public class CheckItem<E> : ViewModelBase where E: EntityObject
        {
            public delegate void OnChangeEventHandler(CheckItem<E> sender, bool ieChecked);
            public event OnChangeEventHandler OnChange;

            public CheckItem(E model)
            {
                Model = model;
            }

            private bool isChecked;
            public bool IsChecked
            {
                get { return isChecked; }
                set
                {
                    if (isChecked != value)
                    {
                        isChecked = value;
                        OnPropertyChanged("IsChecked");
                        if (OnChange != null)
                            OnChange(this, isChecked);
                    }
                }
            }

            public E Model { get; private set; }
        }

        public SendingGroupViewModel(SendingGroup sg)
            : base(sg) 
        { 
            Departments = new List<CheckItem<Department>>();
            foreach (var dep in HandlerStore.Context.Departments)
            {
                var checkedDep = new CheckItem<Department>(dep);
                if (Model.Departments.Contains(dep))
                    checkedDep.IsChecked = true;
                else
                    checkedDep.IsChecked = false;
                checkedDep.OnChange += (sender, e) =>
                    {
                        if (e)
                            Model.Departments.Add(sender.Model);
                        else
                            Model.Departments.Remove(sender.Model);
                    };
                
                Departments.Add(checkedDep);
            }
        }

        public IList<CheckItem<Department>> Departments { get; private set; }

    }
}
