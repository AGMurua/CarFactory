using CarFactory.Domain;
using CarFactory.Helper.Types;

namespace CarFactory.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        void AddSale(Sale sale);
        decimal GetSalePercentageByModel(CarTypeEnum carType, string distributionCenter);
        IEnumerable<Sale> GetSalesByDistributionCenter(string centerName);
        IEnumerable<Sale> GetTotalSalesVolume();

        Dictionary<string, Dictionary<CarTypeEnum, decimal>> GetSalesPercentageByModelPerCenter();
    }
}
