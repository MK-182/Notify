using Nofity.Core.DomainEvents;
using Tacta.EventStore.Domain;

namespace Nofity.Core
{
    public sealed class Account : AggregateRoot<AccountId>
    {
        public override AccountId Id { get; protected set; }

        public static Account CreateAccount(string email, string password)
        {
            // validacija todo
            var account = new Account();

            var accountId = new AccountId(email);
            var @event = new AccountCreated(accountId.ToString(), email, password);
            account.Apply(@event);

            return account;
        }

        public void DeactivateAccount()
        {
            // validacija todo
            var @event = new AccountDeactivated(Id.ToString());
            Apply(@event);
        }

        public void On(AccountCreated @event)
        { 
        }

        public void On(AccountDeactivated @event)
        {
        }
    }
}
