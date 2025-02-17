using CarFactory.Domain;
using CarFactory.Helper.Types;

namespace CarFactory.Repositories.Interfaces
{
    public interface ICarRepository
    {
        CarPrice GetPrice(CarTypeEnum carType);
    }
}
