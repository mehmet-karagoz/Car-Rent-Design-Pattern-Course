using CarRenting.Host.Interfaces;

namespace CarRenting.Host.PricingStrategy
{
    public class SportPricingStrategy : IPricingStrategy
    {
        private readonly int pricePerDay = 100;

        public double CalculatePrice(int numberOfDays)
        {
            return numberOfDays * pricePerDay * 2;
        }
    }
}
