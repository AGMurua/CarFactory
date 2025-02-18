using CarFactory.Helper.Types;

namespace CarFactory.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public CarTypeEnum CarType { get; set; }
        public string CarTypeName => CarType.ToString();
        public CenterDto Center { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public SaleDto(CarTypeEnum type, CenterDto center, decimal price)
        {
            CarType = type;
            Center = center;
            Price = price;
            Date = DateTime.Now;
        }
    }
}
