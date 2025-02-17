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
        private readonly ICarPriceProvider _carPriceProvider;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, ICarPriceProvider carPriceProvider, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _carPriceProvider = carPriceProvider;
            _mapper = mapper;
        }

        public decimal GetSalePercentageByModel(CarTypeEnum carType, string distributionCenter) =>
                _saleRepository.GetSalePercentageByModel(carType, distributionCenter);

        public IEnumerable<SaleDto> GetSalesByDistributionCenter(string center) =>
            _mapper.Map<IEnumerable<SaleDto>>(_saleRepository.GetSalesByDistributionCenter(center));

        public object GetTotalSalesVolume() => _saleRepository.GetTotalSalesVolume();

        public void InsertSale(AddSaleDto saleDto)
        {
            var price = _carPriceProvider.GetPrice(saleDto.CarType);

            var sale = new Sale(saleDto.CarType, saleDto.DistributionCenterName, price);

            _saleRepository.AddSale(sale);
        }

    }
}
