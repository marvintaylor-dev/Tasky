namespace Tasky.Client.Services.EstimationService
{
    public class EstimationService : IEstimationService
    {

        private readonly HttpClient _httpClient;
        public EstimationService(HttpClient client)
        {
            _httpClient = client;
        }
        public List<EstimationGroup> EstimationGroups { get; set; } = new();
        public List<RelativeEstimation> AllEstimationValues { get; set; } = new();  
        public List<RelativeEstimation> EstimationValuesByGroup { get; set; } = new();
        public EstimationGroup EstimationGroup { get; set;} = new();

        public async Task GetAllEstimationValues()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RelativeEstimation>>("api/relativeestimation/values");
            if(result == null) 
            {
                throw new Exception("Null response");
            }
            AllEstimationValues = result.ToList(); 
        }

        public async Task GetEstimationGroupById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EstimationGroup>($"api/relativeestimation/groups/{id}");
            if (result == null)
            {
                throw new Exception("Null response");
            }
            EstimationGroup = result;
        }

        public async Task GetEstimationGroups()
        {
            var result = await _httpClient.GetFromJsonAsync<List<EstimationGroup>>("api/relativeestimation/groups");
            if (result == null)
            {
                throw new Exception("Null response");
            }
            EstimationGroups = result;
        }

        public async Task GetEstimationValuesByGroup(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<RelativeEstimation>>($"api/relativeestimation/values/{id}");
            if (result == null)
            {
                throw new Exception("Null response");
            }
            EstimationValuesByGroup = result;
        }
    }
}
