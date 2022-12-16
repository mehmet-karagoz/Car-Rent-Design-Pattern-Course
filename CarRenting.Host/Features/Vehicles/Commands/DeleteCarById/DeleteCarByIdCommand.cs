using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;

namespace CarRenting.Host.Features.Vehicles.Commands.DeleteCarById
{
    public class DeleteCarByIdCommand : ICommand
    {
        public int Id { get; set; }

        public DeleteCarByIdCommand(int id)
        {
            Id = id;
        }

        public void Execute()
        {
            Car? car = CarRentalSystem.GetCars().FirstOrDefault(c => c.Id == Id);
            if (car == null)
            {
                throw new Exception("Car not found.");
            }
            CarRentalSystem.RemoveCar(car);
        }
    }
}
