using CarFactory.Domain;
using CarFactory.Helper.Types;
using CarFactory.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CarFactory.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IMemoryCache _memoryCache;

        public SaleRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private List<Sale> GetSales() => _memoryCache.GetOrCreate("Sales", entry =>
                                                  {
                                                      entry.SlidingExpiration = TimeSpan.FromMinutes(15);
                                                      return new List<Sale>();
                                                  });

        public void AddSale(Sale sale)
        {
            var sales = GetSales();
            sales.Add(sale);
            _memoryCache.Set("Sales", sales);
        }

        public IEnumerable<Sale> GetAllSales() => GetSales();

        public Dictionary<string, decimal> GetSalesByDistributionCenter(string centerName = null)
        {
            return GetSalesByCenter(GetSales(), centerName);
        }

        public Dictionary<string, Dictionary<CarTypeEnum, decimal>> GetSalesPercentageByModelPerCenter()
        {
            var sales = GetSales();
            var totalCompanySales = sales.Count();

            if (totalCompanySales == 0) return new Dictionary<string, Dictionary<CarTypeEnum, decimal>>();

            return sales
                .GroupBy(s => s.DistributionCenterName)
                .ToDictionary(
                    centerGroup => centerGroup.Key,
                    centerGroup => centerGroup
                        .GroupBy(s => s.CarType)
                        .ToDictionary(
                            modelGroup => modelGroup.Key,
                            modelGroup => (decimal)modelGroup.Count() / totalCompanySales * 100
                        )
                );
        }

        private Dictionary<string, decimal> GetSalesByCenter(IEnumerable<Sale> sales, string centerName = null)
        {
            if (!string.IsNullOrWhiteSpace(centerName))
            {
                sales = sales.Where(s => s.DistributionCenterName == centerName);
            }

            return sales
                .GroupBy(s => s.DistributionCenterName)
                .ToDictionary(g => g.Key, g => g.Sum(s => s.Price));
        }
    }
}
