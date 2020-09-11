using Application.Commands;
using Application.Common.Interfaces;
using Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AuthenticationResponse>
    {
        private readonly IAuthentication _authentication;
        public CreateUserCommandHandler(IAuthentication authentication) => _authentication = authentication;


        public async Task<AuthenticationResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _authentication.RegisterAsync(request);
        }
    }
}
