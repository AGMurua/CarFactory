namespace CarFactory.Domain
{
    public class Sale
    {
        public int Id { get; set; }
        public CarTypeEnum CarType { get; set; }
        public int DistributionCenterId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

    }
}
