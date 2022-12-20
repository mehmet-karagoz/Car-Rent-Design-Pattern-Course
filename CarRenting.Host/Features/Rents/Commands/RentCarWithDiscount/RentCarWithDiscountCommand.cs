using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using CarRenting.Host.PricingStrategyCreation;
using CarRenting.Host.RentalService;
using Entities;

namespace CarRenting.Host.Features.Rents.Commands.RentCarWithDiscount
{
    public class RentCarWithDiscountCommand : ICommand<RentalAgreement>
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public CarType CarType { get; set; }
        private int _discountAmount;
        private readonly IPricingStrategy _pricingStrategy;
        private ICarRentalService _carRentalService;


        public RentCarWithDiscountCommand(int carId, DateTime startDate, DateTime endDate, string name, string email, string phone, string address, CarType carType)
        {
            CarId = carId;
            StartDate = startDate;
            EndDate = endDate;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            CarType = carType;
            _pricingStrategy = PricingStrategyFactory.CreatePricingStrategy(carType);
        }
        public void SetDiscountAmount(int discountAmount)
        {
            _discountAmount = discountAmount;
            _carRentalService = new DiscountDecorator(_discountAmount);
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
                if (_discountAmount < 0 || _discountAmount > 100)
                {
                    throw new Exception("Discount must be between 0 and 100");
                }
                RentalAgreement rentalAgreement = _carRentalService.RentCar(CarId, StartDate, EndDate, customer);
                int days = (EndDate - StartDate).Days;
                double rentalPrice = _pricingStrategy.CalculatePrice(days);
                rentalAgreement.RentalPrice = rentalPrice - (rentalPrice * rentalAgreement.DiscountAmount) / 100;
                CarRentalSystem.Instance.AddRentalAgreement(rentalAgreement);
                return new Response<RentalAgreement>(rentalAgreement);
            }
            catch (Exception e)
            {

                return new Response<RentalAgreement>(e.Message.ToString());
            }
        }
    }
}
