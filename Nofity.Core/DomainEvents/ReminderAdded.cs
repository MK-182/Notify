using System;
using Tacta.EventStore.Domain;

namespace Nofity.Core.DomainEvents
{
    public sealed class ReminderAdded : DomainEvent
    {
        public string ReminderId { get; }
        public string Description { get; }
        public DateTime NotifyAt { get; }

        public ReminderAdded(string aggregateId, string reminderId, string description, DateTime notifyAt) : base(aggregateId)
        {
            ReminderId = reminderId;
            Description = description;
            NotifyAt = notifyAt;
        }
    }
}
