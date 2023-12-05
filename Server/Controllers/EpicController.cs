using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasky.Client.Services.TaskService;
using Tasky.Server.Data.EpicRepository;
using Tasky.Shared;

namespace Tasky.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicController : ControllerBase
    {

        private readonly IEpicRepository _repository;

        public EpicController(IEpicRepository repo)
        {
            _repository = repo;
        }


        [HttpGet]
        public async Task<ActionResult<List<Epic>>> GetEpics()
        {
            try
            {
                var result = await _repository.GetAllEpics();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpGet("{EpicId:int}")]
        public async Task<ActionResult<Epic>> GetEpic(int EpicId)
        {
            try
            {
                var result = await _repository.GetEpicById(EpicId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Epic>> CreateEpic(Epic Epic)
        {
            try
            {
                var result = await _repository.CreateEpic(Epic);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Epic>> UpdateEpic(Epic Epic)
        {
            try
            {
                var findEpic = await _repository.GetEpicById(Epic.EpicId);

                if (findEpic == null)
                {
                    return NotFound($"Could not find Epic.");
                }

                var result = await _repository.UpdateEpic(Epic);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Epic>> DeleteEpic(int Id)
        {
            try
            {
                var FindDeletedEpic = await _repository.GetEpicById(Id);
                if (FindDeletedEpic == null)
                {
                    return NotFound($"Cannot delete task with an id of {Id}, as it was not found");
                }
               
                Epic deletedEpic = await _repository.DeleteEpic(Id);
                return Ok(deletedEpic);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
