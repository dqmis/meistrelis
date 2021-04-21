using AutoMapper;
using meistrelis.Dtos;
using meistrelis.Dtos.Service;
using meistrelis.Models;

namespace meistrelis.Profiles 
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<Service, ServiceReadDto>();
        }
    }
}
