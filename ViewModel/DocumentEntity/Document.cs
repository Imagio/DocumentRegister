using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;

namespace Docs.ViewModel.DocumentEntity
{
    public class DocumentBase: ViewModelBase
    {
        public DocumentBase(Document document)
        {
            Model = document;
            FileTab = new FilesViewModel(document.Files);
        }

        public Document Model { get; private set; }

        public FilesViewModel FileTab { get; private set; }
    }
}
