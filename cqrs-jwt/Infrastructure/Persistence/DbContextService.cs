using Application.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Common.Enums;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data.SqlClient;

namespace Infrastructure.Persistence
{
    internal class DbContextService : IDbContext
    {
        public string ConnectionString()
        {
            return ConfigurationConstants.DBConnectionString;
        }

        public DbConnection CreateSqlContext(int provider)
        {
            return provider switch
            {
                (int)DbProviders.MSSql => new SqlConnection(ConnectionString()),
                _ => new MySqlConnection(ConnectionString()),
            };
        }

        public DbConnection CreateMySqlContext()
        {
            return new MySqlConnection(ConnectionString());
        }
    }
}
