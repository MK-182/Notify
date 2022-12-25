using Nofity.Core.DomainEvents;
using Nofity.Core.ReadModels;
using Nofity.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tacta.EventStore.Projector;
using Tacta.EventStore.Repository;

namespace Notify.Projections.Projections
{
    public sealed class ReminderReadModelProjection : Projection
    {
        private readonly IReminderReadModelRepository _reminderReadModelRepository;

        public ReminderReadModelProjection(IReminderReadModelRepository reminderReadModelRepository) : base(reminderReadModelRepository)
        {
            _reminderReadModelRepository = reminderReadModelRepository;
        }


        public async Task On(ReminderAdded @event)
        {
            try
            {
                var reminderReadModel = new ReminderReadModel
                {
                    AccountId = @event.AggregateId,
                    ReminderId = @event.ReminderId,
                    NotifyAt = @event.NotifyAt,
                    SentAt = null,
                    Sequence = @event.Sequence
                };

                await _reminderReadModelRepository.InsertAsync<ReminderReadModel>(reminderReadModel);
            }
            catch (Exception e)
            {
                var a = e;
                throw;
            }
        }
    }
}
