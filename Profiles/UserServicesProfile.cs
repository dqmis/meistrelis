using AutoMapper;
using meistrelis.Dtos;
using meistrelis.Dtos.UserService;
using meistrelis.Models;

namespace meistrelis.Profiles
{
    public class UserServicesProfile : Profile
    {
        public UserServicesProfile()
        {
            CreateMap<UserService, UserServiceReadDto>();
            CreateMap<UserServiceCreateDto, UserService>();
            CreateMap<UserServiceUpdateDto, UserService>();
            CreateMap<UserService, UserServiceUpdateDto>();
        }
    }
}
