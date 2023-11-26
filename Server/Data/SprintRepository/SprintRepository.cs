using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tasky.Shared;
using Tasky.Shared.DTOs;

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
            var result = await _appDbContext.Sprints.Include(x => x.TasksSprints).ToListAsync();
            return result;
        }

        public async Task<SprintModel> GetSprintById(int id)
        {
            var result = await _appDbContext.Sprints.Include(x => x.TasksSprints).FirstOrDefaultAsync(x => x.SprintId == id);
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
            var result = await _appDbContext.Sprints.Include(x => x.TasksSprints).FirstOrDefaultAsync(x => x.SprintId == updateSprint.SprintId);
            if (result == null)
            {
                throw new Exception($"Could not update {updateSprint.SprintNumber}");
            }
            _mapper.Map(updateSprint, result);
            await _appDbContext.SaveChangesAsync();
            return updateSprint;
        }


        public async Task<SprintModel> LinkSprint(SprintTaskDTO sprintUpdate)
        {
            var sprint = await _appDbContext.Sprints.Include(x => x.TasksSprints).FirstOrDefaultAsync(x => x.SprintId == sprintUpdate.SprintId);
            TasksSprints taskSprint = new();
            if (sprint == null)
            {
                throw new Exception("Could not link sprint to task");
            }

            var task = await _appDbContext.Tasks.Include(x => x.TasksSprints).FirstOrDefaultAsync(x => x.TaskId == sprintUpdate.TaskId);
            if (task == null)
            {
                throw new Exception("Could not link sprint to task");
            }

            //sprint.AssignedTasks.Add(task);
            //task.AssignedToSprint.Add(sprint);
            taskSprint.SprintId = sprint.SprintId;
            taskSprint.TaskId = task.TaskId;
            sprint.TasksSprints.Add(taskSprint);
            task.TasksSprints.Add(taskSprint);
            await _appDbContext.SaveChangesAsync();

            return sprint;
        }

        public async Task<SprintTaskDTO> DeleteSprintTaskRelationship(int taskId, int sprintId)
        {
            var relationship = await _appDbContext.TasksSprints.SingleOrDefaultAsync(x => x.TaskId == taskId && x.SprintId == sprintId);

            if(relationship != null)
            {
                _appDbContext.TasksSprints.Remove(relationship);
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Could not delete relationship.");
            }

            SprintTaskDTO sprintTask = new();
            sprintTask.TaskId = relationship.TaskId;
            sprintTask.SprintId = relationship.SprintId;

            return sprintTask;
        }


    }

}
