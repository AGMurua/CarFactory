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

        public decimal GetSalePercentageByModel(CarTypeEnum carType, string distributionCenter) =>
                _saleRepository.GetSalePercentageByModel(carType, distributionCenter);

        public IEnumerable<SaleDto> GetSalesByDistributionCenter(string center) =>
            _mapper.Map<IEnumerable<SaleDto>>(_saleRepository.GetSalesByDistributionCenter(center));

        public IEnumerable<SaleDto> GetTotalSalesVolume() => _mapper.Map<IEnumerable<SaleDto>>(_saleRepository.GetTotalSalesVolume().OrderBy(x => x.DistributionCenterName));

        public void InsertSale(AddSaleDto saleDto)
        {
            var carPrice = _carRepository.GetPrice(saleDto.CarType);

            var sale = new Sale(saleDto.CarType, saleDto.DistributionCenterName, carPrice.PriceWithTaxes);

            _saleRepository.AddSale(sale);
        }

    }
}
