using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Docs.ViewModel.Searcher
{
    public interface ISearcher
    {
        Predicate<object> Filter { get; }
    }
}
