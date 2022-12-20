using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using Entities;

namespace CarRenting.Host.Features.Customers.Commands.DeleteCustomerById
{
    public class DeleteCustomerByIdCommand : ICommand<int>
    {
        public int Id { get; set; }
        private readonly CarRentalSystem _carRentalSystem;

        public DeleteCustomerByIdCommand(int id)
        {
            Id = id;
            _carRentalSystem = CarRentalSystem.Instance;

        }

        public Response<int> Execute()
        {
            Customer? customer = _carRentalSystem.GetCustomers().FirstOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                return new Response<int>("Customer not found.");
            }
            _carRentalSystem.RemoveCustomer(customer);

            return new Response<int>(customer.Id);
        }
    }
}
