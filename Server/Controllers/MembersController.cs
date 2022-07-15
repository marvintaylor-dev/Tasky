using Microsoft.AspNetCore.Mvc;
using Tasky.Server.Data.MemberRepository;
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
            public async Task<ActionResult<ServiceResponse<List<Member>>>> GetMembers()
            {
               var result = await _repository.GetMembers();
                return Ok(result);
            }
        }
    
}
