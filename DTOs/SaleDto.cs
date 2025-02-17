using CarFactory.Helper.Types;

namespace CarFactory.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public CarTypeEnum CarType { get; set; }
        public string CarTypeName => CarType.ToString();
        public string DistributionCenterName { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
