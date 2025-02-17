using CarFactory.Domain;
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

        public decimal GetTotalSalesVolume()
        {
            var sales = GetSales();
            return sales.Sum(s => s.Price);
        }

        public IEnumerable<Sale> GetSalesByDistributionCenter(string centerName)
        {
            var sales = GetSales();
            return sales.Where(s => s.DistributionCenterName == centerName);
        }
    }
}
