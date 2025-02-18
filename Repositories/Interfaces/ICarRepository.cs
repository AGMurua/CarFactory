using CarFactory.Domain;
using CarFactory.Helper.Types;

namespace CarFactory.Repositories.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<CarPrice> GetAll();
        CarPrice GetPriceByType(CarTypeEnum carType);
    }
}
