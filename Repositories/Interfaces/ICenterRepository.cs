using CarFactory.Domain;
using CarFactory.Helper.Types;

namespace CarFactory.Repositories.Interfaces
{
    public interface ICenterRepository
    {
        Center? GetCenterById(int id);
        IEnumerable<Center> GetAllCenters();
    }
}
