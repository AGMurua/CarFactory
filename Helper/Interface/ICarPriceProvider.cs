using CarFactory.Helper.Types;

namespace CarFactory.Helper
{
    public interface ICarPriceProvider
    {
        decimal GetPrice(CarTypeEnum carType);
    }
}
