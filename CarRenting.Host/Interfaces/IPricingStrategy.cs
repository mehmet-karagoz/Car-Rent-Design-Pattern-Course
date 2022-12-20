namespace CarRenting.Host.Interfaces
{
    public interface IPricingStrategy
    {
        double CalculatePrice(int numberOfDays);
    }
}
