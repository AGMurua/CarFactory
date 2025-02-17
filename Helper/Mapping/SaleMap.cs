using AutoMapper;
using CarFactory.Domain;
using CarFactory.DTOs;

namespace CarFactory.Helper.Mapping
{
    public class SaleMap : Profile
    {
        public SaleMap()
        {
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<SaleDto, Sale>().ReverseMap();
        }
    }
}
