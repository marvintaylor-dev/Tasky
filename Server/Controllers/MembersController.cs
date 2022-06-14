using Microsoft.AspNetCore.Mvc;
using Tasky.Server.Data;
using Tasky.Server.Services;
using Tasky.Shared;

namespace Tasky.Server.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class MembersController : ControllerBase
        {
            private readonly IMemberRepository _repository;

            public MembersController(IMemberRepository repo)
            {
                _repository = repo;
            }

            [HttpGet]
            public async Task<ActionResult<Member>> GetMembers()
            {
                try
                {
                    return Ok(await _repository.GetMembers());
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database.");
                }
            }
        }
    
}
