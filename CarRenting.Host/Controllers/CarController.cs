using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Executor;
using CarRenting.Host.Features.Cars.Commands.CreateCar;
using CarRenting.Host.Features.Cars.Commands.DeleteCarById;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarRenting.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult<Response<Car>> GetCarById(int id)
        {
            var car = CarRentalSystem.Instance.GetCars().FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return new Response<Car>("Car not found");
            }
            return new Response<Car>(car);
        }

        [HttpGet("GetAllCars")]
        public ActionResult<Response<IEnumerable<Car>>> GetAllCars()
        {
            var cars = CarRentalSystem.Instance.GetCars();
            if (cars == null)
            {
                return new Response<IEnumerable<Car>>("Cars not found");
            }
            return new Response<IEnumerable<Car>>(cars);
        }

        [HttpGet("GetAllAvailableCars")]
        public ActionResult<Response<IEnumerable<Car>>> GetAllAvailableCars()
        {
            var cars = CarRentalSystem.Instance.GetCars().Where(c => c.IsAvailable);
            if (cars == null)
            {
                return new Response<IEnumerable<Car>>("Cars not found");
            }
            return new Response<IEnumerable<Car>>(cars);
        }

        [HttpPost("CreateCar")]
        public ActionResult<Response<int>> CreateCar([FromBody] CreateCarCommand command)
        {

            return CommandExecutor<int>.Execute(command);
        }

        [HttpDelete("DeleteCar/{id}")]
        public ActionResult<Response<int>> DeleteCar(int id)
        {
            DeleteCarByIdCommand command = new DeleteCarByIdCommand(id);
            return CommandExecutor<int>.Execute(command);
        }
    }
}