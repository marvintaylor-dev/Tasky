using Tasky.Shared;

namespace Tasky.Server.Data.SprintRepository
{
    public interface ISprintRepository
    {
        Task<List<SprintModel>> GetSprints();
        Task<SprintModel> GetSprintById(int id);
        Task<SprintModel> AddSprint(SprintModel newSprint);
        Task<SprintModel> DeleteSprintById(int id);
        Task<SprintModel> UpdateSprint(SprintModel updateSprint);

    }
}
