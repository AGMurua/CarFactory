using CarFactory.Helper.Types;

namespace CarFactory.Helper
{
    public class CarPriceProvider : ICarPriceProvider
    {
        private readonly Dictionary<CarTypeEnum, decimal> _prices;

        public CarPriceProvider(IConfiguration configuration)
        {
            _prices = Enum.GetValues(typeof(CarTypeEnum))
                .Cast<CarTypeEnum>()
                .ToDictionary(
                    type => type,
                    type => configuration.GetSection("CarPrices")[type.ToString()] != null
                        ? decimal.Parse(configuration.GetSection("CarPrices")[type.ToString()])
                        : 0m
                );
        }

        public decimal GetPrice(CarTypeEnum carType)
        {
            return TaxApplier(_prices.TryGetValue(carType, out var price) ? price : 0m, carType);
        }

        private static decimal TaxApplier(decimal price, CarTypeEnum type)
        {
            return type == CarTypeEnum.Sport ? price + price * 0.07m : price;
        }
    }
}
