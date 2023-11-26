using Tasky.Shared.DTOs;

namespace Tasky.Client.Services.SprintService
{
    public class SprintService : ISprintService
    {
        private readonly HttpClient _httpClient;

        public SprintService(HttpClient client)
        {
            _httpClient = client;
        }
        public List<SprintModel> Sprints { get; set; } = new();
        public SprintModel Sprint { get; set; } = new();

        public async Task<SprintModel> AddSprint(SprintModel newSprint)
        {
            var result = await _httpClient.PostAsJsonAsync<SprintModel>("api/sprint", newSprint);
            var response = await result.Content.ReadFromJsonAsync<SprintModel>();
            if (response == null) throw new Exception();
            return response;
        }

        public async Task<SprintModel> DeleteSprint(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/sprint/{id}");
            var response = await result.Content.ReadFromJsonAsync<SprintModel> (); 
            if (response == null) throw new Exception();
            return response;
        }

        public async Task GetSprintById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<SprintModel>($"api/sprint/{id}");
            if (result == null) throw new Exception();
            Sprint = result;
        }

        public async Task GetSprints()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SprintModel>>("api/sprint");
            if (result == null) throw new Exception();
            Sprints = result;
        }


        public async Task<SprintModel> UpdateSprint(SprintModel sprintToUpdate)
        {
            var result = await _httpClient.PutAsJsonAsync<SprintModel>("api/sprint", sprintToUpdate);
            var response = await result.Content.ReadFromJsonAsync<SprintModel>();
            if (response == null) throw new Exception();
            return response;
        }


        public async Task<SprintTaskDTO> LinkSprint(SprintTaskDTO sprintTask)
        {
            var result = await _httpClient.PostAsJsonAsync<SprintTaskDTO>("api/sprint/link", sprintTask);
            var response = await result.Content.ReadFromJsonAsync<SprintTaskDTO>();
            if (response == null) throw new Exception();
            return response;
        }

        public async Task<SprintTaskDTO> DeleteSprintTaskRelationship(int taskId, int sprintId)
        {
            var result = await _httpClient.DeleteAsync($"api/sprint/link/{taskId}/{sprintId}");
            var response = await result.Content.ReadFromJsonAsync<SprintTaskDTO>();
            if (response == null) throw new Exception();
            return response;
        }


    }
}
