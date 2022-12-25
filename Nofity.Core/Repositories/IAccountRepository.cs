using System.Threading.Tasks;

namespace Nofity.Core.Repositories
{
    public interface IAccountRepository
    {
        Task SaveAsync(Account account);
        Task<Account> GetAsync(AccountId accountId);
    }
}
