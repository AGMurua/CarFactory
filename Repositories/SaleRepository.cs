using CarFactory.Domain;
using CarFactory.Repositories.Interfaces;

namespace CarFactory.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly List<Sale> _sales;

        public SaleRepository()
        {
            _sales = new List<Sale>(); 
        }

        public void AddSale(Sale sale)
        {
            _sales.Add(sale);
        }

        public decimal GetTotalSalesVolume()
        {
            return _sales.Sum(s => s.Price);
        }
    }
}
