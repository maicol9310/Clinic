using Microsoft.AspNetCore.Mvc;
using Clinic.Application.People.Commands;

namespace Clinic.API.Controllers
{
    public class PeopleController : ApiController
    {
        [HttpPost("createUpdate/people")]
        public async Task<ActionResult> CreateUpdatePeople(CreateUpdatePeopleCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
