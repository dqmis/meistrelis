using AutoMapper;
using meistrelis.Dtos;
using meistrelis.Dtos.UserRating;
using meistrelis.Dtos.UserService;
using meistrelis.Models;

namespace meistrelis.Profiles
{
    public class UserRatingsProfile : Profile
    {
        public UserRatingsProfile()
        {
            CreateMap<UserRating, UserRatingReadDto>();
            CreateMap<UserRatingCreateDto, UserRating>();
        }
    }
}
