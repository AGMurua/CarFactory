using CarFactory.DTOs;
using CarFactory.Helper.Types;

namespace CarFactory.Services.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarPriceDto> GetAllCarPrice();
        CarPriceDto GetPriceByType(CarTypeEnum carType);
    }
}
