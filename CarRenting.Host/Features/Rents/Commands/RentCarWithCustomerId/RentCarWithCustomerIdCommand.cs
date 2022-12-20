using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using CarRenting.Host.PricingStrategyCreation;
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
        private readonly ICarRentalService _carRentalService;
        private  IPricingStrategy _pricingStrategy;
        private readonly CarRentalSystem _carRentalSystem;


        public RentCarWithCustomerIdCommand(int carId, DateTime startDate, DateTime endDate, int customerId)
        {
            CarId = carId;
            StartDate = startDate;
            EndDate = endDate;
            CustomerId = customerId;
            _carRentalService = new CarRentalService();
            _carRentalSystem = CarRentalSystem.Instance;

        }

        public Response<RentalAgreement> Execute()
        {
            Customer? customer = _carRentalSystem.GetCustomers().Where(c => c.Id == CustomerId).FirstOrDefault();
            if (customer == null)
            {
                return new Response<RentalAgreement>("Customer not found");
            }
            try
            {
                Car? car = _carRentalSystem.GetCars().Where(c => c.Id == CarId).FirstOrDefault();
                _pricingStrategy = PricingStrategyFactory.CreatePricingStrategy(car!.CarType);
                RentalAgreement rentalAgreement = _carRentalService.RentCar(CarId, StartDate, EndDate, customer);
                int days = (EndDate - StartDate).Days;
                rentalAgreement.RentalPrice = _pricingStrategy.CalculatePrice(days);
                _carRentalSystem.AddRentalAgreement(rentalAgreement);
                return new Response<RentalAgreement>(rentalAgreement);
            }
            catch (Exception e)
            {

                return new Response<RentalAgreement>(e.Message.ToString());
            }
        }
    }
}
