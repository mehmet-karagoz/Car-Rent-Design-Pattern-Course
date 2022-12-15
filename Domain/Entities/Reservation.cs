using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Car Car { get; set; } // reserved car
        public virtual Customer Customer { get; set; } // customer who reserved the car
        public double RentalPrice { get; set; }
    }
}
