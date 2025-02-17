using CarFactory.Domain;
using CarFactory.Helper.Types;
using CarFactory.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace CarFactory.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Dictionary<CarTypeEnum, CarPrice> _prices;

        public CarRepository(IConfiguration configuration)
        {
            var carPriceConfig = new Dictionary<string, CarPrice>();
            configuration.GetSection("CarPricesConfig:Prices").Bind(carPriceConfig);

            _prices = carPriceConfig.ToDictionary(
                kvp => Enum.Parse<CarTypeEnum>(kvp.Key),
                kvp => new CarPrice
                {
                    CarType = Enum.Parse<CarTypeEnum>(kvp.Key),
                    BasePrice = kvp.Value.BasePrice,
                    TaxPercentage = kvp.Value.TaxPercentage
                });
        }

        public CarPrice GetPrice(CarTypeEnum carType)
        {
            if (!_prices.TryGetValue(carType, out var carPrice))
            {
                throw new KeyNotFoundException($"No se encontro el precio para el tipo de auto");
            }
            return carPrice;
        }
    }
}
