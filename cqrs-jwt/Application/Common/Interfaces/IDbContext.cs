using System.Data.Common;

namespace Application.Common.Interfaces
{
    public interface IDbContext
    {
        string ConnectionString();
        DbConnection CreateSqlContext(int provider);

        DbConnection CreateMySqlContext();
    }
}
