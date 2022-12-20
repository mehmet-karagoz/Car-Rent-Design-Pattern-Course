using CarRenting.Host.Common;
using CarRenting.Host.Interfaces;
using CarRenting.Host.RentalService;

namespace CarRenting.Host.Features.Rents.Commands.ReturnCar
{
    public class ReturnCarCommand : ICommand<int>
    {
        public int RentalId { get; set; }
        private readonly ICarRentalService _carRentalService;
        public ReturnCarCommand(int rentalId)
        {
            RentalId = rentalId;
            _carRentalService = new CarRentalService();
        }

        public Response<int> Execute()
        {
            try
            {
            _carRentalService.ReturnCar(RentalId);
                return new Response<int>(RentalId);

            }
            catch (Exception e)
            {

                return new Response<int>(e.Message.ToString());
            }
        }
    }
}
