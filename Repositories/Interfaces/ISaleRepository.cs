using CarFactory.Domain;
using CarFactory.Helper.Types;

namespace CarFactory.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        void AddSale(Sale sale);
        Dictionary<string, decimal> GetSalesByDistributionCenter(string centerName = null);
        IEnumerable<Sale> GetAllSales();

        Dictionary<string, Dictionary<CarTypeEnum, decimal>> GetSalesPercentageByModelPerCenter();
    }
}
