using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Executor;
using CarRenting.Host.Features.Customers.Commands.CreateCustomer;
using CarRenting.Host.Features.Customers.Commands.DeleteCustomerById;
using CarRenting.Host.Features.Rents.Commands.RentCar;
using CarRenting.Host.Features.Rents.Commands.RentCarWithCustomerId;
using CarRenting.Host.Features.Rents.Commands.ReturnCar;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarRenting.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult<Response<RentalAgreement>> GetRentalAgreementById(int id)
        {
            var RentalAgreement = CarRentalSystem.Instance.GetRentalAgreements().FirstOrDefault(c => c.Id == id);
            if (RentalAgreement == null)
            {
                return new Response<RentalAgreement>("RentalAgreement not found");
            }
            return new Response<RentalAgreement>(RentalAgreement);
        }

        [HttpGet]
        public ActionResult<Response<IEnumerable<RentalAgreement>>> GetAllRentalAgreements()
        {
            var RentalAgreements = CarRentalSystem.Instance.GetRentalAgreements();
            if (RentalAgreements == null)
            {
                return new Response<IEnumerable<RentalAgreement>>("RentalAgreements not found");
            }
            return new Response<IEnumerable<RentalAgreement>>(RentalAgreements);
        }

        [HttpPost("RentCarWithCustomerId")]
        public ActionResult<Response<RentalAgreement>> RentCarWithCustomerId([FromBody] RentCarWithCustomerIdCommand command)
        {

            return CommandExecutor<RentalAgreement>.Execute(command);
        }

        [HttpPost("RentCar")]
        public ActionResult<Response<RentalAgreement>> RentCar([FromBody] RentCarCommand command)
        {

            return CommandExecutor<RentalAgreement>.Execute(command);
        }

        [HttpPost("ReturnCar")]
        public ActionResult<Response<int>> ReturnCar(int rentalId)
        {
            ReturnCarCommand returnCarCommand = new ReturnCarCommand(rentalId);
           return CommandExecutor<int>.Execute(returnCarCommand);
            
        }
    }
}