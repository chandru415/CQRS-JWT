using Application.Common.Models;

namespace Application.Responses
{
    public class UserInfoQueryResponse : BaseResponse
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
