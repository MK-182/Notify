using Nofity.Core.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tacta.EventStore.Repository;

namespace Nofity.Core.Repositories
{
    public interface IReminderReadModelRepository : IProjectionRepository, IGenericRepository
    {
        Task<IEnumerable<ReminderReadModel>> GetAllToSendAsync();
    }
}
