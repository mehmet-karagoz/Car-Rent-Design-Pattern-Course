using CarRenting.Host.Entities;
using Entities;

namespace CarRenting.Host.Interfaces
{
    public interface ICarRentalService
    {
        List<Car> GetAvailableCars();
        RentalAgreement RentCar(int carId, DateTime startDate, DateTime endDate, Customer customer);
        void ReturnCar(int rentalId);
    }
}
