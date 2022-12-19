using CarRenting.Host.Entities;
using Entities;

namespace CarRenting.Host
{
    public class CarRentalSystem
    {
        private static readonly List<Car> _cars = new List<Car>();
        private static readonly List<Customer> _customers = new List<Customer>();
        private static readonly List<RentalAgreement> _rentalAgreements = new List<RentalAgreement>();
        private static CarRentalSystem? _instance;
        private CarRentalSystem() { }
        public static CarRentalSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CarRentalSystem();
                }
                return _instance;
            }
        }
        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public void RemoveCar(Car car)
        {
            _cars.Remove(car);
        }

        public IEnumerable<Car> GetCars()
        {
            return _cars;
        }

        public void AddRentalAgreement(RentalAgreement rentalAgreement)
        {
            _rentalAgreements.Add(rentalAgreement);
        }

        public void RemoveRentalAgreement(RentalAgreement rentalAgreement)
        {
            _rentalAgreements.Remove(rentalAgreement);
        }

        public IEnumerable<RentalAgreement> GetRentalAgreements()
        {
            return _rentalAgreements;
        }

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            _customers.Remove(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }

        // Other methods for handling rentals and returns could go here
    }

}
