using CarFactory.DTOs;
using CarFactory.Helper.Types;

namespace CarFactory.Services.Interfaces
{
    public interface ISaleService
    {
        Dictionary<string, Dictionary<CarTypeEnum, decimal>> GetSalesPercentageByModelPerCenter();
        IEnumerable<SaleDto> GetSalesByDistributionCenter(string centerName);
        IEnumerable<SaleDto> GetTotalSalesVolume();
        void InsertSale(AddSaleDto saleDto);
    }
}
