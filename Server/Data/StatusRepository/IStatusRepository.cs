using Tasky.Shared;

namespace Tasky.Server.Data.StatusRepository
{
    public interface IStatusRepository
    {
        Task<List<StatusNew>> GetAllStatuses();
        Task<StatusNew> AddStatus(StatusNew status);
        Task<StatusNew> GetStatusById(int id);
        Task<StatusNew> UpdateStatus(StatusNew status);
        Task<StatusNew> DeleteStatus(int id);

    }
}
