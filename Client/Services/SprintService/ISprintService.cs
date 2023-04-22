using Tasky.Shared.DTOs;

namespace Tasky.Client.Services.SprintService
{
    public interface ISprintService
    {
        List<SprintModel> Sprints { get; set; }

        SprintModel Sprint { get; set; }

        Task GetSprints();
        Task GetSprintById(int id);
        Task<SprintModel> AddSprint(SprintModel newSprint);
        Task<SprintModel> DeleteSprint(int id);
        Task<SprintModel> UpdateSprint(SprintModel newSprint);

        Task<SprintTaskDTO> LinkSprint(SprintTaskDTO sprintTask);

    }
}
