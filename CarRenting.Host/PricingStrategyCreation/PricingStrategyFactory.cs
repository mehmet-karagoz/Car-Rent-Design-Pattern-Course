using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using CarRenting.Host.PricingStrategy;

namespace CarRenting.Host.PricingStrategyCreation
{
    public class PricingStrategyFactory
    {
        public static IPricingStrategy CreatePricingStrategy(CarType carType)
        {
            switch (carType)
            {
                case CarType.Economy:
                    return new EconomyPricingStrategy();
                case CarType.Luxury:
                    return new LuxuryPricingStrategy();
                case CarType.Sports:
                    return new SportPricingStrategy();
                default:
                    throw new ArgumentException("Invalid pricing strategy type.");
            }
        }
    }
}
