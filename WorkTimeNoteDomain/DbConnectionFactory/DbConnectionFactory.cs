using System.Data;
using System.Data.SqlClient;
using WorkTimeNoteCommon;
using WorkTimeNoteDomain.DbConnectionFactory.Contracts;

namespace WorkTimeNoteDomain.DbConnectionFactory
{
    public sealed class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection NewSqlConnection() =>
            new SqlConnection(ConfigurationManager.DatabaseConnectionString);
    }
}
