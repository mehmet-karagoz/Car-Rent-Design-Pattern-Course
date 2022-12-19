using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using CarRenting.Host.RentalService;
using Entities;

namespace CarRenting.Host.Features.Rents.Commands.RentCarWithCustomerId
{
    public class RentCarWithCustomerIdCommand : ICommand<RentalAgreement>
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerId { get; set; }
        private readonly CarRentalService carRentalService;

        public RentCarWithCustomerIdCommand(int carId, DateTime startDate, DateTime endDate,int customerId)
        {
            CarId = carId;
            StartDate = startDate;
            EndDate = endDate;
            CustomerId = customerId;
            carRentalService = new CarRentalService();
        }

        public Response<RentalAgreement> Execute()
        {
            Customer? customer = CarRentalSystem.Instance.GetCustomers().Where(c => c.Id == CustomerId).FirstOrDefault();
            if (customer == null)
            {
                return new Response<RentalAgreement>("Customer not found");
            }
            try
            {
                RentalAgreement rentalAgreement = carRentalService.RentCar(CarId, StartDate, EndDate, customer);
                return new Response<RentalAgreement>(rentalAgreement);
            }
            catch (Exception e)
            {

                return new Response<RentalAgreement>(e.Message.ToString());
            }
        }
    }
}
