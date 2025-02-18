using CarFactory.Domain;
using CarFactory.Helper.Types;
using CarFactory.Repositories.Interfaces;

namespace CarFactory.Repositories
{
    public class CenterRepository : ICenterRepository
    {
        private readonly List<Center> _centers;

        public CenterRepository(IConfiguration configuration)
        {
            _centers = new List<Center>();
            configuration.GetSection("CarPricesConfig:Centers").Bind(_centers);
        }

        public IEnumerable<Center> GetAllCenters() => _centers;

        public Center? GetCenterById(int id) => _centers.FirstOrDefault(c => c.Id == id);
    }
}
