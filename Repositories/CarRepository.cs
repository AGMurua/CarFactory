using CarFactory.Domain;
using CarFactory.Helper.Types;
using CarFactory.Repositories.Interfaces;

namespace CarFactory.Repositories
{
    public class CarRepository : ICarRepository
    {
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

        public IEnumerable<CarPrice> GetAll() => _prices.Values;
        public CarPrice GetPriceByType(CarTypeEnum carType)
        {
            if (!_prices.TryGetValue(carType, out var carPrice))
            {
                throw new ArgumentException($"No se encontro el precio para el tipo de auto");
            }
            return carPrice;
        }
    }
}
