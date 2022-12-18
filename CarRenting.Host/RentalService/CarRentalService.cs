using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using Entities;

namespace CarRenting.Host.RentalService
{
    public class CarRentalService : ICarRentalService
    {
        private CarRentalSystem _carRentalSystem;

        public CarRentalService()
        {
            _carRentalSystem = CarRentalSystem.Instance;
        }

        public List<Car> GetAvailableCars()
        {
            return _carRentalSystem.GetCars().Where(c => c.IsAvailable).ToList();
        }

        public RentalAgreement RentCar(int carId, DateTime startDate, DateTime endDate, Customer customer)
        {
            Car? car = GetAvailableCars().FirstOrDefault(c => c.Id == carId);

            if (car == null)
            {
                throw new Exception("This car is not availiable");
            }

            List<RentalAgreement> isRented = _carRentalSystem.GetRentalAgreements().Where(predicate: d => startDate >= d.StartDate
            && startDate <= d.EndDate
            && endDate >= d.StartDate
            && endDate <= d.EndDate).Where(c => c.RentedCar.Id == carId).ToList();

            if (isRented.Count > 0)
            {
                throw new Exception("The car is busy given dates");
            }
            Car? updateCar = _carRentalSystem.GetCars()
                            .FirstOrDefault(c => c.Id == carId);
            if (updateCar != null)
            {
                updateCar.IsAvailable = false;
            }

            RentalAgreement rentalAgreement = new RentalAgreement
            {
                RentedCar = car,
                StartDate = startDate,
                EndDate = endDate,
                Customer = customer,
                DiscountAmount = 0,
                RentalPrice = 10,
            };
            _carRentalSystem.AddRentalAgreement(rentalAgreement);
            return rentalAgreement;
        }

        public void ReturnCar(int rentalId)
        {
            var date = DateTime.Now;
            var rentalAgreement = _carRentalSystem.GetRentalAgreements().Where(r => r.Id == rentalId).FirstOrDefault();
            if (rentalAgreement != null)
            {
                var car = _carRentalSystem.GetCars().Where(c => c.Id == rentalAgreement.RentedCar.Id).FirstOrDefault();
                car.IsAvailable = true;

                rentalAgreement.EndDate = date;
            }
        }
    }
}
