using Microsoft.AspNetCore.Mvc;
using Clinic.Application.People.Commands;
using Clinic.Application.Masters.Queries;
using Clinic.Application.Models;

namespace Clinic.API.Controllers
{
    [Route("people/")]
    public class PeopleController : ApiController
    {
        [HttpGet("getDoctors")]
        public async Task<List<PeopleDTO>> GetDoctors()
        {
            return await Mediator.Send(new GetDoctorsQuery());
        }

        [HttpPost("createUpdate")]
        public async Task<ActionResult> CreateUpdatePeople(CreateUpdatePeopleCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
