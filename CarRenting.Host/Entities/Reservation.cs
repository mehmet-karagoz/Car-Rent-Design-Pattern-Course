using CarRenting.Host.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reservation : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual BaseVehicle Vehicle { get; set; } // reserved car
        public virtual Customer Customer { get; set; } // customer who reserved the car
        public double RentalPrice { get; set; }
    }
}
