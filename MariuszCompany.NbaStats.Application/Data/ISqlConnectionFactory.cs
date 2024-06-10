using System.Data;

namespace MariuszCompany.NbaStats.Application.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();

        IDbConnection CreateNewConnection();

        string GetConnectionString();
    }
}