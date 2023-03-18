using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasky.Shared;

namespace Tasky.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusNew>>> GetAllStatuses()
        {
            var result = await _statusRepository.GetAllStatuses();
            if (result == null)
            {
                return BadRequest("Could not get statuses");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusNew>> GetStatusById(int id)
        {
            var result = await _statusRepository.GetStatusById(id);
            if (result == null)
            {
                return BadRequest($"Status {id} was not found");
            }
            return result;
        }


        [HttpPost]
        public async Task<ActionResult<StatusNew>> AddStatus(StatusNew status)
        {
            var result = await _statusRepository.AddStatus(status);
            if (result == null)
            {
                return BadRequest("Could not add a status");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StatusNew>> UpdateStatus(StatusNew status)
        {
            var result = await _statusRepository.UpdateStatus(status);
            if(result == null)
            {
                return BadRequest("No status to update");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusNew>> DeleteStatus(int id)
        {
            var result = await _statusRepository.DeleteStatus(id);  
            if(result == null)
            {
                return BadRequest("Could not delete");
            }
            return Ok(result);
        }


    }
}
