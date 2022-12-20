using CarRenting.Host.Common;
using Entities;

namespace CarRenting.Host.Entities
{
    public class RentalAgreement : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double RentalPrice { get; set; }
        public double DiscountAmount { get; set; }
        public Car RentedCar { get; set; }
        public Customer Customer { get; set; }
    }
}
