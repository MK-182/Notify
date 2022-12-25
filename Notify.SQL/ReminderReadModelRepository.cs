using Dapper;
using Nofity.Core.ReadModels;
using Nofity.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tacta.EventStore.Repository;

namespace Notify.SQL
{
    public sealed class ReminderReadModelRepository : ProjectionRepository, IReminderReadModelRepository
    {

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private const string tableName = "ReminderReadModel";

        public ReminderReadModelRepository(ISqlConnectionFactory connectionFactory) : base(connectionFactory, tableName)
        {
            _sqlConnectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ReminderReadModel>> GetAllToSendAsync()
        {
            using (var connection = _sqlConnectionFactory.SqlConnection())
            {
                var query = $"SELECT * FROM {tableName} WHERE SentAt IS NULL AND NotifyAt < GETDATE()";
                return await connection.QueryAsync<ReminderReadModel>(query).ConfigureAwait(false);
            }
        }
    }
}
