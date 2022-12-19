using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;

namespace CarRenting.Host.Features.Cars.Commands.DeleteCarById
{
    public class DeleteCarByIdCommand : ICommand<int>
    {
        public int Id { get; set; }

        public DeleteCarByIdCommand(int id)
        {
            Id = id;
        }

        public Response<int> Execute()
        {
            Car? car = CarRentalSystem.Instance.GetCars().FirstOrDefault(c => c.Id == Id);
            if (car == null)
            {
                return new Response<int>("Car not found.");
            }
            CarRentalSystem.Instance.RemoveCar(car);

            return new Response<int>(car.Id);
        }
    }
}
