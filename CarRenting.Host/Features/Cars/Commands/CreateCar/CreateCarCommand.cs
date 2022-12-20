using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;

namespace CarRenting.Host.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommand : ICommand<int>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarType CarType { get; set; }
        private readonly CarRentalSystem _carRentalSystem;

        public CreateCarCommand(string make, string model, int year, CarType carType)
        {
            Make = make;
            Model = model;
            Year = year;
            CarType = carType;
            _carRentalSystem = CarRentalSystem.Instance;
        }

        public Response<int> Execute()
        {
            // Create a new car with the specified make, model, and year
            Car car = new Car
            {
                Id = _carRentalSystem.GetCars().Any() ? _carRentalSystem.GetCars().Last().Id + 1 : 0,
                Make = Make,
                Model = Model,
                Year = Year,
                IsAvailable = true,
                CarType = CarType
            };
            // Add the new car to the car rental system
            _carRentalSystem.AddCar(car);

            return new Response<int>(car.Id);
        }
    }
}
