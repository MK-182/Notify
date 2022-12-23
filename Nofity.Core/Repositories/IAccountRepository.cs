namespace Nofity.Core.Repositories
{
    public interface IAccountRepository
    {
        void Save(Account account);
        Account Get(AccountId accountId);
    }
}
