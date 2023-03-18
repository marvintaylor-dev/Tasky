namespace Tasky.Client.Services.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly HttpClient _httpClient;

        public StatusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<StatusNew> AddStatus(StatusNew status)
        {
            var result = await _httpClient.PostAsJsonAsync("api/status", status);
            var response = await result.Content.ReadFromJsonAsync<StatusNew>();

            if (response == null)
            {
                throw new Exception("Could not add new status.");
            }

            return response;
        }

        public async Task<StatusNew> DeleteStatus(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/status/{id}");
            var response = await result.Content.ReadFromJsonAsync<StatusNew>();

            if (response == null)
            {
                throw new Exception("Could not delete status.");
            }
            return response;
        }

        public async Task<List<StatusNew>> GetAllStatuses()
        {
            var result = await _httpClient.GetFromJsonAsync<List<StatusNew>>("api/status");
            if(result == null)
            {
                throw new Exception("No Statuses found.");
            }
            return result;
        }

        public async Task<StatusNew> GetStatusById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<StatusNew>($"api/status/{id}");
            if(result == null)
            {
                throw new Exception($"No status by id of {id} were found.");
            }
            return result;
        }

        public async Task<StatusNew> UpdateStatus(StatusNew status)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/status", status);
            var response = await result.Content.ReadFromJsonAsync<StatusNew>();
            if (response == null)
            {
                throw new Exception("Status not updated");
            }
            return response;
        }
    }
}
