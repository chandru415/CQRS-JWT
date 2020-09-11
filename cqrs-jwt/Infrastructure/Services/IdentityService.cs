using Application.Common.Interfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Common.Enums;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class IdentityService : IIdentity
    {
        private readonly IDbContext _dbContext;
        public IdentityService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@UserId", user.UserId);
            dbParams.Add("@Password", user.Password);
            dbParams.Add("@Salt", user.Salt);
            dbParams.Add("@Role", user.Role);

            using var con = _dbContext.CreateSqlContext(Convert.ToInt32(DbProviders.MSSql));
            var result = await con.ExecuteAsync("sp_createuser", dbParams, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<User> FindUserByIdAsync(string userId)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@UserId", userId);

            using var con = _dbContext.CreateSqlContext(Convert.ToInt32(DbProviders.MSSql));
            var result = await con.QueryAsync<User>("sp_findsuserbyid", dbParams, commandType: CommandType.StoredProcedure);

            return result.ToList().FirstOrDefault();
        }
    }
}
