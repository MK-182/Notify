using System;
using Tacta.EventStore.Domain;

namespace Nofity.Core.Entites
{
    public sealed class Reminder : Entity<ReminderId>
    {
        public override ReminderId Id { get; protected set; }
        public string Description { get; }
        public DateTime NotifyAt { get; }

        public Reminder(ReminderId reminderId, string description, DateTime notifyAt)
        {
            if (string.IsNullOrWhiteSpace(description) || notifyAt < DateTime.Now)
                throw new Exception("Invalid reminder");

            Id = reminderId;
            Description = description;
            NotifyAt = notifyAt;
        }
    }
}
