using Application.Responses;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAuthentication
    {
        Task<AuthenticationResponse> LoginAsync(User user);
        Task<AuthenticationResponse> RegisterAsync(User user);
    }
}
