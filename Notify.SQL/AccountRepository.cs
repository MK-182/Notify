using Nofity.Core;
using Nofity.Core.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Tacta.EventStore.Domain;
using Tacta.EventStore.Repository;

namespace Notify.SQL
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public AccountRepository(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task SaveAsync(Account account)
        {
            var aggregateRecord = new AggregateRecord(account.Id.ToString(), account.GetType().Name, account.Version);

            var eventRecords = account.DomainEvents
                .Select(x => new EventRecord<DomainEvent>(((DomainEvent)x).Id, x.CreatedAt, (DomainEvent)x))
                .ToList()
                .AsReadOnly();

            await _eventStoreRepository.SaveAsync(aggregateRecord, eventRecords).ConfigureAwait(false);
        }

        public Account Get(AccountId accountId)
        {
            return new Account();
        }
    }
}
