using Tasky.Shared;

namespace Tasky.Server.Data.EstimationRepository
{
    public interface IEstimationRepository
    {
        Task<List<EstimationGroup>> GetEstimationGroups();
        Task<RelativeEstimation> GetSingleEstimate(int id);
        Task<EstimationGroup> GetEstimationGroupById(int id);
        Task<List<RelativeEstimation>> GetAllEstimationValues();
        Task<List<RelativeEstimation>> GetEstimationValuesByGroup(int estimationGroupId);
    }
}
