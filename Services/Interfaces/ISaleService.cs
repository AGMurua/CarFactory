using CarFactory.DTOs;
using CarFactory.Helper.Types;

namespace CarFactory.Services.Interfaces
{
    public interface ISaleService
    {
        decimal GetSalePercentageByModel(CarTypeEnum carType, string center);
        IEnumerable<SaleDto> GetSalesByDistributionCenter(string centerName);
        IEnumerable<SaleDto> GetTotalSalesVolume();
        void InsertSale(AddSaleDto saleDto);
    }
}
