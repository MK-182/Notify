using System;

namespace Nofity.Core.ReadModels
{
    public sealed class ReminderReadModel
    {
        public string AccountId { get; set; }
        public string ReminderId { get; set; }
        public DateTime NotifyAt { get; set; }
        public DateTime? SentAt { get; set; }
        public int Sequence { get; set; }
    }
}
