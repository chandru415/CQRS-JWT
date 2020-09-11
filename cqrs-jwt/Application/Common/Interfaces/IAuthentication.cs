using Application.Commands;
using Application.Responses;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAuthentication
    {
        Task<AuthenticationResponse> LoginAsync(LoginCommand user);
        Task<AuthenticationResponse> RegisterAsync(CreateUserCommand user);
    }
}
