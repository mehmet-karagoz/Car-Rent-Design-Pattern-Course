using CarRenting.Host.Entities;

namespace CarRenting.Host.Interfaces
{
    public interface ICarRentalService
    {
        List<Car> GetAvailableCars();
        RentalAgreement RentCar(int carId, DateTime startDate, DateTime endDate);
        void ReturnCar(int rentalId);
    }
}
