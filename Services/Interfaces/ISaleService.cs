using CarFactory.DTOs;

namespace CarFactory.Services.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<SaleDto> GetSalesByDistributionCenter(string centerName);
        object GetTotalSalesVolume();
        void InsertSale(AddSaleDto saleDto);
    }
}
