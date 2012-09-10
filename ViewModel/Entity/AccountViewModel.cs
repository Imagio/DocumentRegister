using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;

namespace Docs.ViewModel.Entity
{
    public class AccountViewModel: EntityViewModel<Account>
    {
        public AccountViewModel(Account account)
            : base(account) { }

    }
}
