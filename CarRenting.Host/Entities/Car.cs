using CarRenting.Host.Common;

namespace CarRenting.Host.Entities
{
    public class Car : BaseVehicle
    {
        public int NumberOfDoors { get; set; }

        public override void Rent()
        {
            // code to rent a car
        }

        public override void Return()
        {
           // 
        }
    }
}
