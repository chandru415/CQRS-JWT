using Application.Responses;
using MediatR;

namespace Application.Handlers.QHandlers
{
    public class UserInfoQuery : IRequest<UserInfoQueryResponse>
    {
        public string UserId { get; set; }
    }
}
