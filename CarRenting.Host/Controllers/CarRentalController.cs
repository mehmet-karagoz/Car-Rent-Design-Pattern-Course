using CarRenting.Host.Common;
using CarRenting.Host.Executor;
using CarRenting.Host.Features.Vehicles.Commands.RentVehicle;
using CarRenting.Host.Features.Vehicles.Commands.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;

namespace CarRenting.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarRentalController
    {
        private readonly CommandExecutor _commandExecutor;

        public CarRentalController(CommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        [HttpPost("RentVehicle")]
        public void RentVehicle(BaseVehicle baseVehicle)
        {
            RentVehicleCommand command = new RentVehicleCommand(baseVehicle);
            _commandExecutor.ExecuteCommand(command);
        }

        [HttpPost("ReturnVehicle")]
        public void ReturnVehicle(BaseVehicle baseVehicle)
        {
            ReturnVehicleCommand command = new ReturnVehicleCommand(baseVehicle);
            _commandExecutor.ExecuteCommand(command);
        }
    }
}