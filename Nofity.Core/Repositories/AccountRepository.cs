using System;
using System.Collections.Generic;
using System.Text;

namespace Nofity.Core.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public void Save(Account account)
        {

        }

        public Account Get(AccountId accountId)
        {
            return new Account();
        }
    }
}
