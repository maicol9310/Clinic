using Clinic.Application.Masters.Queries;
using Clinic.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("masters/")]
    public class MastersController : ApiController
    {
        [HttpGet("getSex")]
        public async Task<List<MasterDataDTO>> GetSex()
        {
            return await Mediator.Send(new GetTypeGenderQuery());
        }

        [HttpGet("getTypePeople")]
        public async Task<List<MasterDataDTO>> GetTypePeople()
        {
            return await Mediator.Send(new GetTypePeopleQuery());
        }
    }
}
