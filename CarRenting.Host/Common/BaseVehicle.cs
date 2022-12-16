using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRenting.Host.Common
{
    public abstract class BaseVehicle : BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }


        public abstract void Rent();
        public abstract void Return();

        public override string? ToString()
        {
            return base.ToString() + ", " +  Make +  ", " + Model + ", " + Year;
        }
    }
}
