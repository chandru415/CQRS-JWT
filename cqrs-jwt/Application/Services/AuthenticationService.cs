using Application.Common.Interfaces;
using Application.Responses;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthenticationService : IAuthentication
    {
        public Task<AuthenticationResponse> LoginAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<AuthenticationResponse> RegisterAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        private bool CheckPasswordAsync(string password, string salt)
        {
            throw new System.NotImplementedException();
        }

        private AuthenticationResponse GenerateAuthenticationResponseForUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
