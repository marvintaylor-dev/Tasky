using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasky.Server.Data;
using Tasky.Server.Services;
using Tasky.Shared;

namespace Tasky.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteModelsController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public NoteModelsController(ITaskRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult<NoteModel>> GetAllTasks()
        {
            try
            {
                var tasks = await _repository.GetAllTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteModel>> GetTaskById(int taskId)
        {
            try
            {
                var task = await _repository.GetTaskById(taskId);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<NoteModel>> AddTask(NoteModel task)
        {
            try
            {
                NoteModel addedTask = await _repository.AddTask(task);
                if(addedTask == null)
                {
                    return BadRequest();
                }
                return Ok(addedTask);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<NoteModel>> UpdateTask(NoteModel task)
        {

            if (task == null)
            {
                return NotFound($"Could not find task.");
            }
            else
            {
                try
                {
                    var updatedTask = await _repository.GetTaskById(task.TaskId);
                    await _repository.UpdateTask(updatedTask);
                    return Ok(updatedTask);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<NoteModel>> DeleteTask(int id)
        {
            try
            {

                NoteModel FindDeletedTask = await _repository.GetTaskById(id);
                if (FindDeletedTask == null)
                {
                    return NotFound($"Cannot delete task with an id of {id}, as it was not found");
                }
               
               NoteModel deletedTask = await _repository.DeleteTask(id);
               return Ok(deletedTask);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
