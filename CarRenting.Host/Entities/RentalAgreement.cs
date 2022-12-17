using CarRenting.Host.Common;
using Entities;

namespace CarRenting.Host.Entities
{
    public class RentalAgreement : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public Car RentedCar { get; set; }
        public Customer Customer { get; set; }
    }
}
