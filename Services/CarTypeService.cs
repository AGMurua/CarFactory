using AutoMapper;
using CarFactory.Domain;
using CarFactory.DTOs;
using CarFactory.Helper;
using CarFactory.Helper.Types;
using CarFactory.Repositories.Interfaces;
using CarFactory.Services.Interfaces;
using System.Collections.Generic;

namespace CarFactory.Services
{
    public class CarTypeService : ICarTypeService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
         
        public CarTypeService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public CarPriceDto GetPrice(CarTypeEnum carType) => _mapper.Map<CarPriceDto>(_carRepository.GetPrice(carType));
        
    }
}
