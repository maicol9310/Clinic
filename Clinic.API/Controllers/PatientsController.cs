using Clinic.Application.Models;
using Clinic.Application.Patients.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("patients/")]
    public class PatientsController : ApiController
    {
        [HttpGet("getPatients")]
        public async Task<List<PatientsDTO>> GetPatients()
        {
            return await Mediator.Send(new GetPatientsQuery());
        }
    }
}
