using Nofity.Core.Entites;
using Nofity.Core.Repositories;
using Nofity.Core.ValueObjects;
using System;
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
            var account = await _accountRepository.GetAsync(accountId).ConfigureAwait(false);

            account.DeactivateAccount();

            await _accountRepository.SaveAsync(account).ConfigureAwait(false);
        }

        public async Task AddReminder(AccountId accountId, string description, DateTime notifyAt)
        {
            var account = await _accountRepository.GetAsync(accountId).ConfigureAwait(false);

            var reminder = new Reminder(new ReminderId(Guid.NewGuid()), description, notifyAt);

            account.AddReminder(reminder);

            await _accountRepository.SaveAsync(account).ConfigureAwait(false);
        }
    }
}
