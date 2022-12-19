using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
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
        private readonly CarRentalService carRentalService;

        public RentCarCommand(int carId, DateTime startDate, DateTime endDate, string name, string email, string phone, string address)
        {
            CarId = carId;
            StartDate = startDate;
            EndDate = endDate;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            carRentalService = new CarRentalService();
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
            return new Response<RentalAgreement>(carRentalService.RentCar(CarId, StartDate, EndDate, customer));
        }
    }
}
