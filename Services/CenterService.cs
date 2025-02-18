using AutoMapper;
using CarFactory.Domain;
using CarFactory.DTOs;
using CarFactory.Helper;
using CarFactory.Helper.Types;
using CarFactory.Repositories.Interfaces;
using CarFactory.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CarFactory.Services
{
    public class CenterService : ICenterService
    {
        private readonly ICenterRepository _centerRepository;
        private readonly IMapper _mapper;
         
        public CenterService(ICenterRepository centerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _centerRepository = centerRepository;
        }

        public IEnumerable<CenterDto> GetAllCenters() => _mapper.Map<IEnumerable<CenterDto>>(_centerRepository.GetAllCenters());

        public CenterDto GetCenterById(int id) => _mapper.Map<CenterDto>(_centerRepository.GetCenterById(id));
    }
}
