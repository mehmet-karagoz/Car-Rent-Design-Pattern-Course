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
        public ActionResult<Car> GetCarById(int id)
        {
            var car = CarRentalSystem.Instance.GetCars().FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return car;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            var cars = CarRentalSystem.Instance.GetCars();
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

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCar(int id)
        {
            DeleteCarByIdCommand command = new DeleteCarByIdCommand(id);
            CommandExecutor.Execute(command);
            return new ActionResult<string>("Successfully deleted.");
        }
    }
}