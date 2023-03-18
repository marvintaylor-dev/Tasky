namespace Tasky.Client.Services.StatusService
{
    public interface IStatusService
    {
        Task<List<StatusNew>> GetAllStatuses();
        Task<StatusNew> AddStatus(StatusNew status);
        Task<StatusNew> GetStatusById(int id);
        Task<StatusNew> UpdateStatus(StatusNew status);
        Task<StatusNew> DeleteStatus(int id);
    }
}
