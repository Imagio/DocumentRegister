using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Docs.ViewModel.Searcher
{
    public class DepartmentSearcher: ISearcher
    {
        public Predicate<object> Filter
        {
            get { throw new NotImplementedException(); }
        }
    }
}
