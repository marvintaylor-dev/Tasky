using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasky.Server.Data.SectionRepository;
using Tasky.Shared;

namespace Tasky.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {

        private readonly ISectionRepository _repository;

        public SectionsController(ISectionRepository repo)
        {
            _repository = repo;
        }


        [HttpGet]
        public async Task<ActionResult<List<Section>>> GetSections()
        {
            try
            {
                var result = await _repository.GetSections();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Section>> GetSection(int sectionId)
        {
            try
            {
                var result = await _repository.GetSectionById(sectionId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Section>> CreateSection(Section section)
        {
            try
            {
                var result = await _repository.CreateSection(section);
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
        public async Task<ActionResult<Section>> UpdateSection(Section section)
        {
            try
            {
                var result = await _repository.GetSectionById(section.SectionId);

                if (result == null)
                {
                    return NotFound($"Could not find section.");
                }

                await _repository.UpdateSection(section);
                return Ok(section);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Section>> DeleteSection(int Id)
        {
            try
            {

                var FindDeletedSection = await _repository.GetSectionById(Id);
                if (FindDeletedSection == null)
                {
                    return NotFound($"Cannot delete task with an id of {Id}, as it was not found");
                }

                Section deletedSection = await _repository.DeleteSection(Id);
                return Ok(deletedSection);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
