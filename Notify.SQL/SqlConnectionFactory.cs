using Microsoft.Data.SqlClient;
using Tacta.EventStore.Repository;

namespace Notify.SQL
{
    public sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        public SqlConnection SqlConnection()
        {
            var connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Notify;Integrated Security=true;TrustServerCertificate=True;";
            return new SqlConnection(connectionString);
        }
    }
}
