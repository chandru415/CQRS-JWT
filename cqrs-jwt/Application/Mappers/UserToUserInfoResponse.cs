using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class UserToUserInfoResponse : Profile
    {
        public UserToUserInfoResponse() => CreateMap<User, UserInfoQueryResponse>();
                //.ForMember(destinationMember: dest => dest.UserId, memberOptions: opt => opt.MapFrom(src => src.UserId))
                //.ForMember(destinationMember: dest => dest.Role, memberOptions: opt => opt.MapFrom(src => src.Role));
    }
}
