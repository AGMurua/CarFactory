using CarFactory.DTOs;

namespace CarFactory.Services.Interfaces
{
    public interface ISaleService
    {
        object GetTotalSalesVolume();
        void InsertSale(SaleDto saleDto);
    }
}
