using CarFactory.Domain;
using CarFactory.DTOs;
using CarFactory.Helper;
using CarFactory.Helper.Types;
using CarFactory.Repositories.Interfaces;
using CarFactory.Services.Interfaces;

namespace CarFactory.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ICarPriceProvider _carPriceProvider;

        public SaleService(ISaleRepository saleRepository, ICarPriceProvider carPriceProvider)
        {
            _saleRepository = saleRepository;
            _carPriceProvider = carPriceProvider;
        }

        public void InsertSale(SaleDto saleDto)
        {
            var price = _carPriceProvider.GetPrice(saleDto.CarType);

            var sale = new Sale
            {
                CarType = saleDto.CarType,
                DistributionCenterName = saleDto.DistributionCenterName,
                Price = price,
                Date = DateTime.Now
            };

            _saleRepository.AddSale(sale);
        }


    }
}
