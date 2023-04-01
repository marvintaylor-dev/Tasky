using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusController(IStatusRepository statusRepository,IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusDTO>>> GetAllStatuses()
        {
            var result = await _statusRepository.GetAllStatuses();
            if (result == null)
            {
                return BadRequest("Could not get statuses");
            }
            return Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Status>> GetStatusIdByName(string name)
        {
            var result = await _statusRepository.GetStatusIdByName(name);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatusById(int id)
        {
            var result = await _statusRepository.GetStatusById(id);
            if (result == null)
            {
                return BadRequest($"Status {id} was not found");
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<Status>> AddStatus(StatusDTO status)
        {
            var result = await _statusRepository.AddStatus(status);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Status>> UpdateStatus(StatusDTO status)
        {
            
            var result = await _statusRepository.UpdateStatus(status);
            if (result == null)
            {
                return BadRequest("No status to update");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> DeleteStatus(int id)
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
