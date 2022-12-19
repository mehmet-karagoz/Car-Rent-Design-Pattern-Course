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
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = CarRentalSystem.Instance.GetCustomers().FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = CarRentalSystem.Instance.GetCustomers();
            if (customers == null)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<Customer>>(customers);
        }

        [HttpPost]
        public ActionResult<string> CreateCustomer([FromBody] CreateCustomerCommand command)
        {

            CommandExecutor.Execute(command);
            return new ActionResult<string>("Successfully created.");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCustomer(int id)
        {
            DeleteCustomerByIdCommand command = new DeleteCustomerByIdCommand(id);
            CommandExecutor.Execute(command);
            return new ActionResult<string>("Successfully deleted.");
        }
    }
}