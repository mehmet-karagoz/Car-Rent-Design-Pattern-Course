using CarRenting.Host.Entities;

namespace CarRenting.Host
{
    public static class CarRentalSystem
    {
        private static readonly List<Car> _cars = new List<Car>();

        public static void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public static void RemoveCar(Car car)
        {
            _cars.Remove(car);
        }

        public static IEnumerable<Car> GetCars()
        {
            return _cars;
        }

        // Other methods for handling rentals and returns could go here
    }

}
