using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using Entities;

namespace CarRenting.Host.RentalService
{
    public class DiscountDecorator : ICarRentalService
    {
        private readonly ICarRentalService _decoratedService;

        public DiscountDecorator(ICarRentalService decoratedService)
        {
            _decoratedService = decoratedService;
        }

        public List<Car> GetAvailableCars()
        {
            return _decoratedService.GetAvailableCars();
        }

        public RentalAgreement RentCar(int carId, DateTime startDate, DateTime endDate, Customer customer)
        {
            // Calculate the discount amount
            // ...
            var discountAmount = 2;
            RentalAgreement agreement = _decoratedService.RentCar(carId, startDate, endDate,customer);
            agreement.DiscountAmount = discountAmount;
            return agreement;
        }

        public void ReturnCar(int rentalId)
        {
            _decoratedService.ReturnCar(rentalId);
        }
    }
}
