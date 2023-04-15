using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tasky.Shared;

namespace Tasky.Server.Data.SprintRepository
{
    public class SprintRepository : ISprintRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public SprintRepository(AppDbContext context, IMapper mapper)
        {
            _appDbContext = context;
            _mapper = mapper;
        }

        public async Task<List<SprintModel>> GetSprints()
        {
            var result = await _appDbContext.Sprints.ToListAsync();
            return result;
        }

        public async Task<SprintModel> GetSprintById(int id)
        {
            var result = await _appDbContext.Sprints.FirstOrDefaultAsync(x => x.SprintId == id);
            if (result == null)
            {
                throw new Exception($"Could not find sprint id of {id}");
            }
            return result;
        }

        public async Task<SprintModel> AddSprint(SprintModel newSprint)
        {
            if (newSprint == null)
            {
                throw new Exception("Could not add new sprint as it was null");
            }

            await _appDbContext.Sprints.AddAsync(newSprint);
            await _appDbContext.SaveChangesAsync();
            return newSprint;
        }

        public async Task<SprintModel> DeleteSprintById(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Id given was equal to 0");
                }

                var result = await _appDbContext.Sprints.FirstOrDefaultAsync(x => x.SprintId == id);
                if (result == null)
                {
                    throw new Exception($"Could not find a sprint with id of {id}");
                }

                _appDbContext.Sprints.Remove(result);
                await _appDbContext.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<SprintModel> UpdateSprint(SprintModel updateSprint)
        {
            var result = await _appDbContext.Sprints.FirstOrDefaultAsync(x => x.SprintId == updateSprint.SprintId);
            if (result == null)
            {
                throw new Exception($"Could not update {updateSprint.SprintNumber}");
            }
            _mapper.Map(updateSprint, result);
            await _appDbContext.SaveChangesAsync();
            return updateSprint;
        }
    }
    
}
