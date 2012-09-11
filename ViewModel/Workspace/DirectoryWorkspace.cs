using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using Docs.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Docs.ViewModel.Searcher;
using System.Data.Objects;
using System.Windows.Input;

namespace Docs.ViewModel.Workspace
{
    public abstract class DirectoryWorkspace<E,W> : WorkspaceBase 
        where W : Entity.EntityViewModel<E>
        where E : EntityObject
    {
        public DirectoryWorkspace(ObjectSet<E> directory, ISearcher searcher)
        {
            Header = directory.CreateObject().ListTitle();
            ItemCollection = new ObservableCollection<E>(directory.ToList());
            itemCollectionView = (ICollectionView)CollectionViewSource.GetDefaultView(ItemCollection);
            itemSearcher = searcher;
            objectSet = directory;

            CreateNewCommand = new RelayCommand(o => createNew(), o => canCreateNew());
            CreateCopyCommand = new RelayCommand(o => createCopy(), o => canCreateCopy());
            EditCommand = new RelayCommand(o => edit(), o => canEdit());
            DeleteCommand = new RelayCommand(o => delete(), o => canDelete());
            FindCommand = new RelayCommand(o => find(), o => canFind());
            ClearFindCommand = new RelayCommand(o => clearFind(), o => canClearFind());
        }

        private ObjectSet<E> objectSet;

        public abstract W CreateInstance(E e);

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

        public ObservableCollection<E> ItemCollection { get; private set; }
        private ICollectionView itemCollectionView;

        private ISearcher itemSearcher;

        public ICommand CreateNewCommand { get; private set; }
        public ICommand CreateCopyCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand FindCommand { get; private set; }
        public ICommand ClearFindCommand { get; private set; }

        protected virtual void InitStartValue(E e) { }

        private void createNew()
        {
            E e = objectSet.CreateObject();
            InitStartValue(e);
            if (HandlerStore.Main.OpenNewWindow(e.NormalTitle(), CreateInstance(e)))
            {
                objectSet.AddObject(e);
                ItemCollection.Add(e);
                HandlerStore.Context.SaveChanges();
            }
        }
        protected virtual bool CanCreateNew() { return true; }
        private bool canCreateNew()
        {
            return CanCreateNew();
        }

        protected virtual void CopyObject(E source, E target)
        {
            foreach (var prop in typeof(E).GetProperties())
            {
                if (prop.GetType().IsValueType)
                    prop.SetValue(target, prop.GetValue(source, null), null);
            }
        }
        private void createCopy()
        {
            E item = objectSet.CreateObject();
            CopyObject(selectedItem, item);

            if (HandlerStore.Main.OpenNewWindow(item.NormalTitle(), CreateInstance(item)))
            {
                objectSet.AddObject(item);
                HandlerStore.Main.Context.SaveChanges();
                ItemCollection.Add(item);
            }
        }
        protected virtual bool CanCreateCopy() { return true; }
        private bool canCreateCopy()
        {
            return CanCreateCopy() 
                && SelectedItem != null 
                && ItemCollection.Contains(SelectedItem);
        }

        private void edit()
        {
            var e = selectedItem;
            if (HandlerStore.Main.OpenNewWindow(e.NormalTitle(), CreateInstance(e)))
                HandlerStore.Context.SaveChanges();
            else
                HandlerStore.Context.Refresh(RefreshMode.StoreWins, e);

        }
        protected virtual bool CanEdit() { return true; }
        private bool canEdit()
        {
            return CanEdit()
                && SelectedItem != null
                && ItemCollection.Contains(SelectedItem);
        }

        private void delete()
        {
            var e = selectedItem;
            if (!HandlerStore.Main.AskQuestion(e.DeleteTitle(), "Вы действительно хотите удалить элемент?"))
                return;
            objectSet.DeleteObject(e);
            HandlerStore.Context.SaveChanges();
            ItemCollection.Remove(e);
        }
        protected virtual bool CanDelete() { return true; }
        private bool canDelete()
        {
            return CanDelete()
                && SelectedItem != null
                && ItemCollection.Contains(SelectedItem);
        }

        private void find()
        {
            if (HandlerStore.Main.OpenNewWindow(selectedItem.SearchTitle(), itemSearcher))
            {
                itemCollectionView.Filter = itemSearcher.Filter;
            }
        }
        protected virtual bool CanFind() { return true; }
        private bool canFind()
        {
            return CanFind();
        }

        private void clearFind()
        {
            itemCollectionView.Filter = null;
        }
        protected virtual bool CanClearFind() { return true; }
        private bool canClearFind()
        {
            return CanClearFind();
        }
    }
}
