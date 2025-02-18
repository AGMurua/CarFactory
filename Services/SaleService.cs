using AutoMapper;
using CarFactory.Domain;
using CarFactory.DTOs;
using CarFactory.Helper.Types;
using CarFactory.Repositories;
using CarFactory.Repositories.Interfaces;
using CarFactory.Services.Interfaces;

namespace CarFactory.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ICenterService _centerService;
        private readonly ICarService _carService;

        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, ICarService carService, IMapper mapper, ICenterService centerService)
        {
            _saleRepository = saleRepository;
            _carService = carService;
            _mapper = mapper;
            _centerService = centerService;
        }

        public Dictionary<string, decimal> GetSalesByDistributionCenter(string centerName = null)
        {
            return _saleRepository.GetSalesByDistributionCenter(centerName);
        }

        public decimal GetTotalSalesVolume() => _saleRepository.GetAllSales().Sum(s => s.Price);

        public void InsertSale(AddSaleDto saleDto)
        {
            if (saleDto == null)
            {
                throw new ArgumentException("Los datos de la venta no pueden ser nulos");
            }

            var center = _centerService.GetCenterById(saleDto.CenterId);
            if (center == null)
            {
                throw new ArgumentException("Centro de distribucion no valido");
            }

            var carPrice = _carService.GetPriceByType(saleDto.CarType);
            var sale = _mapper.Map<Sale>(new SaleDto(saleDto.CarType, center, carPrice.PriceWithTaxes));
            _saleRepository.AddSale(sale);
        }

        public Dictionary<string, Dictionary<CarTypeEnum, decimal>> GetSalesPercentageByModelPerCenter() => _saleRepository.GetSalesPercentageByModelPerCenter();
    }
}
