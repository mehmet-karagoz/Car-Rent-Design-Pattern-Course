using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;

namespace CarRenting.Host.Features.Cars.Commands.DeleteCarById
{
    public class DeleteCarByIdCommand : ICommand<int>
    {
        public int Id { get; set; }
        private readonly CarRentalSystem _carRentalSystem;


        public DeleteCarByIdCommand(int id)
        {
            Id = id;
            _carRentalSystem = CarRentalSystem.Instance;

        }

        public Response<int> Execute()
        {
            Car? car = _carRentalSystem.GetCars().FirstOrDefault(c => c.Id == Id);
            if (car == null)
            {
                return new Response<int>("Car not found.");
            }
            _carRentalSystem.RemoveCar(car);

            return new Response<int>(car.Id);
        }
    }
}
