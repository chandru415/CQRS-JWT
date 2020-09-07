using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IIdentity
    {
        Task<User> FindUserByIdAsync();
    }
}
