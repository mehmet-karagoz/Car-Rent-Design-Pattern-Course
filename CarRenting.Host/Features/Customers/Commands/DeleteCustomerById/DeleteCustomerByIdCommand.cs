using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using Entities;

namespace CarRenting.Host.Features.Customers.Commands.DeleteCustomerById
{
    public class DeleteCustomerByIdCommand : ICommand
    {
        public int Id { get; set; }

        public DeleteCustomerByIdCommand(int id)
        {
            Id = id;
        }

        public void Execute()
        {
            Customer? customer = CarRentalSystem.Instance.GetCustomers().FirstOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }
            CarRentalSystem.Instance.RemoveCustomer(customer);
        }
    }
}
