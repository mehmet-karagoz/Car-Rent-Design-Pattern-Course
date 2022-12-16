using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Executor;
using CarRenting.Host.Features.Vehicles.Commands.CreateCar;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarRenting.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarRentalController : ControllerBase
    {
      
        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = CarRentalSystem.GetCars().FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return car;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            var cars = CarRentalSystem.GetCars();
            if (cars == null)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<Car>>(cars);
        }

        [HttpPost]
        public ActionResult<string> CreateCar([FromBody] CreateCarCommand command)
        {

            CommandExecutor.Execute(command);
            return new ActionResult<string>("Successfully created.");
        }

    }
}