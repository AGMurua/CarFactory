using CarFactory.DTOs;
using CarFactory.Helper.Types;

namespace CarFactory.Domain
{
    public class Sale
    {
        public int Id { get; set; }
        public CarTypeEnum CarType { get; set; }
        public string DistributionCenterName { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }


        public Sale(CarTypeEnum type, string distributionCenterName, decimal price)
        {
            CarType = type;
            DistributionCenterName = distributionCenterName;
            Price = price;
            Date = DateTime.Now;
        }
    }
}
