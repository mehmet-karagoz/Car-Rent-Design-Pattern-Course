using CarRenting.Host.Common;

namespace CarRenting.Host.Features.Vehicles.Commands.ReturnVehicle
{
    public class ReturnVehicleCommand : BaseCommand
    {
        private readonly BaseVehicle _baseVehicle;

        public ReturnVehicleCommand(BaseVehicle baseVehicle)
        {
            _baseVehicle = baseVehicle;
        }

        public override void Execute()
        {
            _baseVehicle.Return();
        }
    }
}
