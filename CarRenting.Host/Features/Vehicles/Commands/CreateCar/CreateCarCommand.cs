using CarRenting.Host.Entities;
using CarRenting.Host.Executor;
using CarRenting.Host.Interfaces;

namespace CarRenting.Host.Features.Vehicles.Commands.CreateCar
{
    public  class CreateCarCommand : ICommand
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
            Car car = new Car();
            car.Id = CarRentalSystem.GetCars().Count() != 0 ? CarRentalSystem.GetCars().Last().Id + 1 : 0;
            car.Make = Make;
            car.Model = Model;
            car.Year = Year;
            car.NumberOfDoors= NumberOfDoors;
            Console.WriteLine(car);
            // Add the new car to the car rental system
            CarRentalSystem.AddCar(car);
        }
    }
}
