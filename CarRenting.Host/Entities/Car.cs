using CarRenting.Host.Common;

namespace CarRenting.Host.Entities
{
    public class Car : BaseEntity
    {

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }


        public void Rent()
        {
        }
        public  void Return()
        {

        }

        public override string? ToString()
        {
            return base.ToString() + ", " + Make + ", " + Model + ", " + Year;
        }
    }
}
