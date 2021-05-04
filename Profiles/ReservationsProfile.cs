using AutoMapper;
using meistrelis.Dtos;
using meistrelis.Dtos.Reservation;
using meistrelis.Dtos.UserRating;
using meistrelis.Dtos.UserService;
using meistrelis.Models;
using Microsoft.IdentityModel.Tokens;

namespace meistrelis.Profiles
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            CreateMap<Reservation, ReservationReadDto>();
            CreateMap<ReservationCreateDto, Reservation>();
        }
    }
}
