using Microsoft.Data.SqlClient;
using Tacta.EventStore.Repository;

namespace Notify.SQL
{
    public sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        public SqlConnection SqlConnection()
        {
            var connectionString = @"Data Source=DESKTOP-H2ULPLT\SQLEXPRESS;Initial Catalog=Notify;User ID=sa;Password=sa";
            return new SqlConnection(connectionString);
        }
    }
}
