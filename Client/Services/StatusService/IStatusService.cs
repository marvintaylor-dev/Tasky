using Tasky.Shared.DTOs;

namespace Tasky.Client.Services.StatusService
{
    public interface IStatusService
    {
        Task<List<StatusDTO>> GetAllStatuses();
        Task<StatusDTO> AddStatus(StatusDTO status);
        Task<StatusDTO> GetStatusById(int id);
        Task<StatusDTO> UpdateStatus(StatusDTO status);
        Task<StatusDTO> DeleteStatus(int id);
        Task<StatusDTO> GetStatusByName(string statusName);

        Task<StatusDTO> GetLastStatus();
        Task<StatusDTO> GetFirstStatus();

        Task<StatusDTO> GetSecondStatus();
    }
}
