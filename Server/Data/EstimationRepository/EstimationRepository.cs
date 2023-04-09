using Microsoft.EntityFrameworkCore;
using Tasky.Shared;

namespace Tasky.Server.Data.EstimationRepository
{
    public class EstimationRepository : IEstimationRepository
    {
        private readonly AppDbContext _context;

        public EstimationRepository(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<EstimationGroup> GetEstimationGroupById(int id)
        {
            var result = await _context.EstimationGroups.FirstOrDefaultAsync(x => x.EstimationGroupId == id);
            return result;
        }

        public async Task<List<EstimationGroup>> GetEstimationGroups()
        {
            var result = await _context.EstimationGroups.ToListAsync();
            return result;
        }

        public async Task<List<RelativeEstimation>> GetAllEstimationValues()
        {
            var result = await _context.RelativeEstimates.ToListAsync();
            return result;
        }

        public async Task<List<RelativeEstimation>> GetEstimationValuesByGroup(int estimationGroupId)
        {
            var result = await _context.RelativeEstimates.Where(x => x.EstimationGroup == estimationGroupId).ToListAsync();

            return result;
        }

    }
}
