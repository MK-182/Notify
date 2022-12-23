using System;
using System.Collections.Generic;
using System.Text;
using Tacta.EventStore.Domain;

namespace Nofity.Core.DomainEvents
{
    public sealed class AccountDeactivated : DomainEvent
    {
        public AccountDeactivated(string aggregateId) : base(aggregateId)
        {

        }
    }
}
