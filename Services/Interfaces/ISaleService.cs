using CarFactory.DTOs;
using CarFactory.Helper.Types;

namespace CarFactory.Services.Interfaces
{
    public interface ISaleService
    {
        Dictionary<string, Dictionary<CarTypeEnum, decimal>> GetSalesPercentageByModelPerCenter();
        Dictionary<string, decimal> GetSalesByDistributionCenter(string centerName = null);
        decimal GetTotalSalesVolume();
        void InsertSale(AddSaleDto saleDto);
    }
}
