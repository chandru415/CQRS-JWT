using Application.Common.Interfaces;
using Application.Responses;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class IdentityService : IIdentity
    {
        public Task<User> FindUserByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
