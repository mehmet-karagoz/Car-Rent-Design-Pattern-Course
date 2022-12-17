using CarRenting.Host.Entities;

namespace CarRenting.Host
{
    public  class CarRentalSystem
    {
        private static readonly List<Car> _cars = new List<Car>();
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
        public  void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public  void RemoveCar(Car car)
        {
            _cars.Remove(car);
        }

        public  IEnumerable<Car> GetCars()
        {
            return _cars;
        }

        // Other methods for handling rentals and returns could go here
    }

}
