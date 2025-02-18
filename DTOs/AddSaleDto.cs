using CarFactory.Helper.Types;

namespace CarFactory.DTOs
{
    public class AddSaleDto
    {
        public CarTypeEnum CarType { get; set; }
        public int CenterId{ get; set; }
    }
}
