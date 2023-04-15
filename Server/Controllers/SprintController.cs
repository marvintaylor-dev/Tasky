using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasky.Shared;

namespace Tasky.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        private readonly ISprintRepository _sprintRepository;

        public SprintController(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SprintModel>>> GetSprints()
        {
            var result = await _sprintRepository.GetSprints();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SprintModel>> GetSprintById(int id)
        {
            var result = await _sprintRepository.GetSprintById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SprintModel>> AddSprint(SprintModel newSprint)
        {
            var result = await _sprintRepository.AddSprint(newSprint);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SprintModel>> DeleteSprint(int id)
        {
            var result = await _sprintRepository.DeleteSprintById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<SprintModel>> UpdateSprint(SprintModel sprintToUpdate)
        {
            var result = await _sprintRepository.UpdateSprint(sprintToUpdate);
            return Ok(result);
        }
    }
}
