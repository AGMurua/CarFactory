﻿using AutoMapper;
using CarFactory.Domain;
using CarFactory.DTOs;
using CarFactory.Helper;
using CarFactory.Helper.Types;
using CarFactory.Repositories.Interfaces;
using CarFactory.Services.Interfaces;
using System.Collections.Generic;

namespace CarFactory.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
         
        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public CarPriceDto GetPriceByType(CarTypeEnum carType) => _mapper.Map<CarPriceDto>(_carRepository.GetPriceByType(carType));
        public IEnumerable<CarPriceDto> GetAllCarPrice() => _mapper.Map<IEnumerable<CarPriceDto>>(_carRepository.GetAll());
        
    }
}
