using CarRenting.Host.Common;
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


        [HttpPost]
        public void CreateCar([FromBody] CreateCarCommand command)
        {
               
            CommandExecutor.Execute(command);
        }

    }
}