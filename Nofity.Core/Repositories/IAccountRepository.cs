using System.Threading.Tasks;

namespace Nofity.Core.Repositories
{
    public interface IAccountRepository
    {
        Task SaveAsync(Account account);
        Account Get(AccountId accountId);
    }
}
