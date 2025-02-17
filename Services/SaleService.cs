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
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ICarRepository _carRepository;

        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, ICarRepository carRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public Dictionary<string, decimal> GetSalesByDistributionCenter(string centerName = null)
        {
            return _saleRepository.GetSalesByDistributionCenter(centerName);
        }
        public decimal GetTotalSalesVolume() => _saleRepository.GetAllSales().Sum(s => s.Price);

        public void InsertSale(AddSaleDto saleDto)
        {
            var carPrice = _carRepository.GetPrice(saleDto.CarType);

            var sale = new Sale(saleDto.CarType, saleDto.DistributionCenterName, carPrice.PriceWithTaxes);

            _saleRepository.AddSale(sale);
        }

        public Dictionary<string, Dictionary<CarTypeEnum, decimal>> GetSalesPercentageByModelPerCenter() => _saleRepository.GetSalesPercentageByModelPerCenter();



    }
}
