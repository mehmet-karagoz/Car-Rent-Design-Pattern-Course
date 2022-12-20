using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using CarRenting.Host.PricingStrategyCreation;
using CarRenting.Host.RentalService;
using Entities;

namespace CarRenting.Host.Features.Rents.Commands.RentCar
{
    public class RentCarCommand : ICommand<RentalAgreement>
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        private readonly ICarRentalService _carRentalService;
        private  IPricingStrategy _pricingStrategy;
        private readonly CarRentalSystem _carRentalSystem;


        public RentCarCommand(int carId, DateTime startDate, DateTime endDate, string name, string email, string phone, string address)
        {
            CarId = carId;
            StartDate = startDate;
            EndDate = endDate;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            _carRentalService = new CarRentalService();
            _carRentalSystem = CarRentalSystem.Instance;

        }

        public Response<RentalAgreement> Execute()
        {
            Customer customer = new Customer
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                Address = Address
            };
            try
            {
                Car? car = _carRentalSystem.GetCars().Where(c => c.Id == CarId).FirstOrDefault();
                _pricingStrategy = PricingStrategyFactory.CreatePricingStrategy(car!.CarType);

                RentalAgreement rentalAgreement = _carRentalService.RentCar(CarId, StartDate, EndDate, customer);
                int days = (EndDate - StartDate).Days;

                double rentalPrice = _pricingStrategy.CalculatePrice(days);

                rentalAgreement.RentalPrice = rentalPrice;
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
