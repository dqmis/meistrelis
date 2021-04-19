using AutoMapper;
using meistrelis.Dtos;
using meistrelis.Models;

namespace meistrelis.Profiles 
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserAuthenticateDto, User>();
        }
    }
}