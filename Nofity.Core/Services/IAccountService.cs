using System;
using System.Threading.Tasks;

namespace Nofity.Core.Services
{
    public interface IAccountService
    {
        Task CreateAccount(string email, string password);
        Task AddReminder(AccountId accountId, string description, DateTime notifyAt);
    }
}
