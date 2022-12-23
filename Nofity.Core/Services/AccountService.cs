using Nofity.Core.Repositories;
using Nofity.Core.ValueObjects;
using System.Threading.Tasks;

namespace Nofity.Core.Services
{
    public sealed class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task CreateAccount(string email, string password)
        {
            var credentials = new Credentials(email, password);

            var account = Account.CreateAccount(credentials);

            await _accountRepository.SaveAsync(account).ConfigureAwait(false);
        }

        public async Task DeactivateAccount(AccountId accountId)
        {
            var account = _accountRepository.Get(accountId);

            account.DeactivateAccount();

            await _accountRepository.SaveAsync(account).ConfigureAwait(false);
        }
    }
}
