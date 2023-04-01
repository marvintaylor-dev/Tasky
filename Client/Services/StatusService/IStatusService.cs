using Tasky.Shared.DTOs;

namespace Tasky.Client.Services.StatusService
{
    public interface IStatusService
    {
        Task<List<StatusDTO>> GetAllStatuses();
        Task<StatusDTO> AddStatus(StatusDTO status);
        Task<StatusDTO> GetStatusById(int id);
        Task<StatusDTO> UpdateStatus(StatusDTO status);
        Task<StatusDTO> DeleteStatus(string statusName);
        Task<StatusDTO> GetStatusByName(string statusName);
    }
}
