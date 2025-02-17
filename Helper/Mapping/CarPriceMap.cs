using AutoMapper;
using CarFactory.Domain;
using CarFactory.DTOs;

namespace CarFactory.Helper.Mapping
{
    public class CarPriceMap : Profile
    {
        public CarPriceMap()
        {
            CreateMap<CarPriceDto, CarPrice>().ReverseMap();
        }
    }
}
