using System.Data;

namespace WorkTimeNoteDomain.DbConnectionFactory.Contracts
{
    public interface IDbConnectionFactory
    {
        IDbConnection NewSqlConnection();
    }
}
