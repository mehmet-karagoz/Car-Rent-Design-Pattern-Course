using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;

namespace CarRenting.Host.RentalService
{
    public class CarRentalService : ICarRentalService
    {
        public List<Car> GetAvailableCars()
        {
            throw new NotImplementedException();
        }

        public RentalAgreement RentCar(int carId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void ReturnCar(int rentalId)
        {
            throw new NotImplementedException();
        }
    }
}
