using System;
using Tacta.EventStore.Domain;

namespace Nofity.Core.DomainEvents
{
    public sealed class AccountCreated : DomainEvent
    {
        public string Email { get; }
        public string Password { get; }

        public AccountCreated(string aggregateId, string email, string password) : base(aggregateId)
        {
            Email = email;
            Password = password;
        }
    }
}
