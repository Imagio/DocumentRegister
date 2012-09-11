using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Docs.ViewModel.Entity
{
    public abstract class EntityViewModelBase : ViewModelBase { }

    public abstract class EntityViewModel<E>: EntityViewModelBase
        where E : EntityObject 
    {
        public EntityViewModel(E entity)
        {
            Model = entity;
        }

        public E Model { get; private set; }

    }
}
