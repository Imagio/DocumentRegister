using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;
using System.Data.Objects.DataClasses;
using System.Collections.ObjectModel;

namespace Docs.ViewModel.DocumentEntity
{
    public class FilesViewModel: ViewModelBase
    {
        public FilesViewModel(EntityCollection<File> files)
        {
            FileCollection = files;
        }

        public EntityCollection<File> FileCollection { get; private set; }

        private File selectedFile;
        public File SelectedFile
        {
            get { return selectedFile; }
            set
            {
                if (selectedFile != value)
                {
                    selectedFile = value;
                    OnPropertyChanged("SelectedFile");
                }
            }
        }
    }
}
