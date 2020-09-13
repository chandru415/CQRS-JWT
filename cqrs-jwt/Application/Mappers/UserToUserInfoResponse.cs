using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class UserToUserInfoResponse : Profile
    {
        public UserToUserInfoResponse() => CreateMap<User, UserInfoQueryResponse>();
    }
}
