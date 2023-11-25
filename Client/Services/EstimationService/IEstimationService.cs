namespace Tasky.Client.Services.EstimationService
{
    public interface IEstimationService
    {
        List<EstimationGroup> EstimationGroups { get; set; }
        List<RelativeEstimation> AllEstimationValues { get; set; }
        List<RelativeEstimation> EstimationValuesByGroup { get; set; }
        EstimationGroup EstimationGroup { get; set; }
         
        RelativeEstimation Estimate { get; set; }

        Task GetEstimationGroups();
        Task GetEstimationGroupById(int id);

        Task GetEstimateById(int id);
        Task GetAllEstimationValues();
        Task GetEstimationValuesByGroup(int id);
    }
}
