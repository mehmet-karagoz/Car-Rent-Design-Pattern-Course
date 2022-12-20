using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using Entities;

namespace CarRenting.Host.RentalService
{
    public class DiscountDecorator : ICarRentalService
    {
        private readonly int Discount;
        private readonly ICarRentalService _decoratedService;

        public DiscountDecorator(int discount)
        {
            _decoratedService = new CarRentalService();
            Discount = discount;
        }

        public List<Car> GetAvailableCars()
        {
            return _decoratedService.GetAvailableCars();
        }

        public RentalAgreement RentCar(int carId, DateTime startDate, DateTime endDate, Customer customer)
        {
            
            RentalAgreement agreement = _decoratedService.RentCar(carId, startDate, endDate,customer);
            agreement.DiscountAmount = Discount;
            return agreement;
        }

        public void ReturnCar(int rentalId)
        {
            _decoratedService.ReturnCar(rentalId);
        }
    }
}
