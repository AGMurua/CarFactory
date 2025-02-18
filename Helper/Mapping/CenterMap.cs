using AutoMapper;
using CarFactory.Domain;
using CarFactory.DTOs;

namespace CarFactory.Helper.Mapping
{
    public class CenterMap : Profile
    {
        public CenterMap()
        {
            CreateMap<Center, CenterDto>().ReverseMap();
        }
    }
}
