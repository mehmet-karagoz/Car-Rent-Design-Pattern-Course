using CarRenting.Host.Common;

namespace CarRenting.Host.Entities
{
    public class Car : BaseEntity
    {

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
        public CarType CarType { get; set; }

        public override string? ToString()
        {
            return base.ToString() + ", " + Make + ", " + Model + ", " + Year;
        }
    }
}
