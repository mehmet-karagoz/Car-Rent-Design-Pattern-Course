using CarRenting.Host.Common;

namespace CarRenting.Host.Features.Vehicles.Commands.RentVehicle
{
    public class RentVehicleCommand : BaseCommand
    {
        private readonly BaseVehicle _baseVehicle;

        public RentVehicleCommand(BaseVehicle baseVehicle)
        {
            _baseVehicle = baseVehicle;
        }

        public override void Execute()
        {
            _baseVehicle.Rent();
        }
    }
}
