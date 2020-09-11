using Application.Commands;
using Application.Common.Interfaces;
using Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResponse>
    {
        private readonly IAuthentication _authentication;
        public LoginCommandHandler(IAuthentication authentication) => _authentication = authentication;

        public async Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authentication.LoginAsync(request);
        }
    }
}
