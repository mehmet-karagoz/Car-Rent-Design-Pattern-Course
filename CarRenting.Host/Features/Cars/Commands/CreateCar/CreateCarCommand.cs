using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;

namespace CarRenting.Host.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommand : ICommand
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int NumberOfDoors { get; set; }

        public CreateCarCommand(string make, string model, int year, int numberOfDoors)
        {
            Make = make;
            Model = model;
            Year = year;
            NumberOfDoors = numberOfDoors;
        }

        public void Execute()
        {
            // Create a new car with the specified make, model, and year
            Car car = new Car
            {
                Id = CarRentalSystem.Instance.GetCars().Any() ? CarRentalSystem.Instance.GetCars().Last().Id + 1 : 0,
                Make = Make,
                Model = Model,
                Year = Year
            };
            // Add the new car to the car rental system
            CarRentalSystem.Instance.AddCar(car);
        }
    }
}
