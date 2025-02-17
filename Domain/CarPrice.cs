using CarFactory.Helper.Types;

namespace CarFactory.Domain
{
    public class CarPrice
    {
        public CarTypeEnum CarType { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal PriceWithTaxes => BasePrice * (1 + TaxPercentage / 100);
    }
}
