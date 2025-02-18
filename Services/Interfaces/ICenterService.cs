using CarFactory.DTOs;
using CarFactory.Helper.Types;

namespace CarFactory.Services.Interfaces
{
    public interface ICenterService
    {
        IEnumerable<CenterDto> GetAllCenters();
        CenterDto GetCenterById(int id);
    }
}
