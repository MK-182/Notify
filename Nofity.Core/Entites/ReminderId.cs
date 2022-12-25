using System;
using Tacta.EventStore.Domain;

namespace Nofity.Core.Entites
{
    public sealed class ReminderId : EntityId
    {
        public Guid ReminderIdentifier { get; }

        public ReminderId(Guid reminderIdentifier)
        {
            ReminderIdentifier = reminderIdentifier;
        }

        public ReminderId(string reminderIdentifier)
        {
            ReminderIdentifier = Guid.Parse(reminderIdentifier);
        }

        public override string ToString() => ReminderIdentifier.ToString();
    }
}
