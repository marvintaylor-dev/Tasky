using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasky.Shared;

namespace Tasky.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelativeEstimationController : ControllerBase
    {

        private readonly IEstimationRepository _estimationRepository;

        public RelativeEstimationController(IEstimationRepository estimationRepository)
        {
            _estimationRepository = estimationRepository;
        }

        [HttpGet]
        [Route("groups")]
        public async Task<ActionResult<List<EstimationGroup>>> GetEstimationGroups()
        {
            var result = await _estimationRepository.GetEstimationGroups();
            return Ok(result);
        }

        [HttpGet]
        [Route("groups/{id}")]
        public async Task<ActionResult<EstimationGroup>> GetEstimationGroupById(int id)
        {
            var result = await _estimationRepository.GetEstimationGroupById(id);
            return Ok(result);
        }

       
        [HttpGet]
        [Route("values/{id}")]
        public async Task<ActionResult<List<RelativeEstimation>>> GetEstimationValuesByGroup(int id)
        {
            
            var result = await _estimationRepository.GetEstimationValuesByGroup(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("single-estimate/{id}")]
        public async Task<ActionResult<List<RelativeEstimation>>> GetEstimateById(int id)
        {

            var result = await _estimationRepository.GetSingleEstimate(id);
            return Ok(result);
        }


        [HttpGet]
        [Route("values")]
        public async Task<ActionResult<List<RelativeEstimation>>> GetAllEstimationValues()
        {
            var result = await _estimationRepository.GetAllEstimationValues();
            return Ok(result);
        }



    }
}
