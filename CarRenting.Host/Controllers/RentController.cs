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

        //[HttpPost]
        //public ActionResult<Response<int>> CreateRentalAgreement([FromBody] CreateRentalAgreementCommand command)
        //{

        //    return CommandExecutor<int>.Execute(command);
        //}

        //[HttpDelete("{id}")]
        //public ActionResult<Response<int>> DeleteRentalAgreement(int id)
        //{
        //    DeleteRentalAgreementByIdCommand command = new DeleteRentalAgreementByIdCommand(id);
        //    return CommandExecutor<int>.Execute(command);
        //}
    }
}