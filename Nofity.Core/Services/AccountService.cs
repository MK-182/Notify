using Nofity.Core.Repositories;

namespace Nofity.Core.Services
{
    public sealed class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void CreateAccount(string email, string password)
        {
            var account = Account.CreateAccount(email, password);

            _accountRepository.Save(account);
        }

        public void DeactivateAccount(AccountId accountId)
        {
            var account = _accountRepository.Get(accountId);

            account.DeactivateAccount();

            _accountRepository.Save(account);
        }
    }
}
