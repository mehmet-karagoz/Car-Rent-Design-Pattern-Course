using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Executor;
using CarRenting.Host.Features.Customers.Commands.CreateCustomer;
using CarRenting.Host.Features.Customers.Commands.DeleteCustomerById;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarRenting.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult<Response<Customer>> GetCustomerById(int id)
        {
            var customer = CarRentalSystem.Instance.GetCustomers().FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return new Response<Customer>("Customer not found");
            }
            return new Response<Customer>(customer);
        }

        [HttpGet]
        public ActionResult<Response<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = CarRentalSystem.Instance.GetCustomers();
            if (customers == null)
            {
                return new Response<IEnumerable<Customer>>("Customers not found");
            }
            return new Response<IEnumerable<Customer>>(customers);
        }

        [HttpPost]
        public ActionResult<Response<int>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {

            return CommandExecutor<int>.Execute(command);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<int>> DeleteCustomer(int id)
        {
            DeleteCustomerByIdCommand command = new DeleteCustomerByIdCommand(id);
            return CommandExecutor<int>.Execute(command);
        }
    }
}