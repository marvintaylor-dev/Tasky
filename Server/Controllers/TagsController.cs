using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasky.Server.Data.TagRepository;
using Tasky.Shared;

namespace Tasky.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _repository;

        public TagsController(ITagRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Tag>> GetAllTags()
        {
            try
            {
                var tags = await _repository.GetAllTags();
                return Ok(tags);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTagById(int tagId)
        {
            try
            {
                var tag = await _repository.GetTagById(tagId);
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> AddTask(Tag tag)
        {
            try
            {
                Tag addedTag = await _repository.AddTag(tag);
                if (addedTag== null)
                {
                    return BadRequest();
                }
                return Ok(addedTag);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Tag>> UpdateTag(Tag tag)
        {
            try
            {
                Tag tagToUpdate = await _repository.GetTagById(tag.TagId);

                if (tagToUpdate == null)
                {
                    return NotFound($"Could not find task.");
                }

                await _repository.UpdateTag(tag);
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Tag>> DeleteTag(int id)
        {
            try
            {

                Tag FindDeletedTag = await _repository.GetTagById(id);
                if (FindDeletedTag == null)
                {
                    return NotFound($"Cannot delete task with an id of {id}, as it was not found");
                }

                Tag deletedTag = await _repository.DeleteTag(id);
                return Ok(deletedTag);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
