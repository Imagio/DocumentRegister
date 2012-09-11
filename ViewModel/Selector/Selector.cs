using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Docs.ViewModel.Selector
{
    public abstract class SelectorBase : ViewModelBase { }

    public abstract class Selector<E>: SelectorBase where E : EntityObject
    {
        public Selector(IList<E> items)
        {
            ItemCollection = items;
        }

        public IList<E> ItemCollection { get; private set; }

        private E selectedItem;
        public E SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }
    }
}
