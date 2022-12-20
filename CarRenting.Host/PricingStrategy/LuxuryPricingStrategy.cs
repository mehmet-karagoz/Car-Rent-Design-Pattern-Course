using CarRenting.Host.Interfaces;

namespace CarRenting.Host.PricingStrategy
{
    public class LuxuryPricingStrategy : IPricingStrategy
    {
        private readonly int pricePerDay = 75;

        public double CalculatePrice(int numberOfDays)
        {
            return numberOfDays * pricePerDay * 1.5;
        }
    }
}
