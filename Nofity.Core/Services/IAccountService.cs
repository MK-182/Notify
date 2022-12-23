using System;
using System.Collections.Generic;
using System.Text;

namespace Nofity.Core.Services
{
    public interface IAccountService
    {
        void CreateAccount(string email, string password);
    }
}
