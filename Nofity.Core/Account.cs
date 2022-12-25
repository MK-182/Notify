using Nofity.Core.DomainEvents;
using Nofity.Core.Entites;
using Nofity.Core.ValueObjects;
using System.Collections.Generic;
using Tacta.EventStore.Domain;

namespace Nofity.Core
{
    public sealed class Account : AggregateRoot<AccountId>
    {
        public override AccountId Id { get; protected set; }
        public List<Reminder> Reminders { get; private set; }

        public Account(IReadOnlyCollection<DomainEvent> domainEvents) : base(domainEvents)
        { 
        }

        public Account()
        { 
        
        }

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

        public void AddReminder(Reminder reminder)
        {
            var @event = new ReminderAdded(Id.ToString(), reminder.Id.ToString(), reminder.Description, reminder.NotifyAt);
            Apply(@event);
        }

        public void On(AccountCreated @event)
        {
            Id = new AccountId(@event.AggregateId);
            Reminders = new List<Reminder>();
        }

        public void On(AccountDeactivated @event)
        {
        }

        public void On(ReminderAdded @event)
        {
            Reminders.Add(new Reminder(new ReminderId(@event.ReminderId), @event.Description, @event.NotifyAt));
        }
    }
}
