using CarFactory.Helper.Types;

namespace CarFactory.DTOs
{
    public class CarPriceDto
    {
        public CarTypeEnum CarType { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal PriceWithTaxes => BasePrice * (1 + TaxPercentage / 100);
        public string CarTypeName => CarType.ToString();
    }
}
