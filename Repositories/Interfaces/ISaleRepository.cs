using CarFactory.Domain;

namespace CarFactory.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        void AddSale(Sale sale);
        IEnumerable<Sale> GetSalesByDistributionCenter(string centerName);
        decimal GetTotalSalesVolume();
    }
}
