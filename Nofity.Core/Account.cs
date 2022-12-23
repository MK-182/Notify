using Nofity.Core.DomainEvents;
using Nofity.Core.ValueObjects;
using Tacta.EventStore.Domain;

namespace Nofity.Core
{
    public sealed class Account : AggregateRoot<AccountId>
    {
        public override AccountId Id { get; protected set; }

        public static Account CreateAccount(Credentials credentials)
        {
            var account = new Account();

            var accountId = new AccountId(credentials.Email);
            var @event = new AccountCreated(accountId.ToString(), credentials.Email, credentials.Password);
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
            Id = new AccountId(@event.AggregateId);
        }

        public void On(AccountDeactivated @event)
        {
        }
    }
}
