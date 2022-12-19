using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using Entities;

namespace CarRenting.Host.Features.Customers.Commands.DeleteCustomerById
{
    public class DeleteCustomerByIdCommand : ICommand<int>
    {
        public int Id { get; set; }

        public DeleteCustomerByIdCommand(int id)
        {
            Id = id;
        }

        public Response<int> Execute()
        {
            Customer? customer = CarRentalSystem.Instance.GetCustomers().FirstOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                return new Response<int>("Customer not found.");
            }
            CarRentalSystem.Instance.RemoveCustomer(customer);

            return new Response<int>(customer.Id);
        }
    }
}
