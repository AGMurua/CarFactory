using CarFactory.DTOs;
using CarFactory.Helper.Types;

namespace CarFactory.Services.Interfaces
{
    public interface ICarTypeService
    {
        CarPriceDto GetPrice(CarTypeEnum carType);
    }
}
