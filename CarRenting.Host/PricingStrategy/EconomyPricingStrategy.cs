using CarRenting.Host.Interfaces;

namespace CarRenting.Host.PricingStrategy
{
    public class EconomyPricingStrategy : IPricingStrategy
    {
        private readonly int pricePerDay = 50;
        public double CalculatePrice(int numberOfDays)
        {
            return numberOfDays * pricePerDay;
        }
    }
}
