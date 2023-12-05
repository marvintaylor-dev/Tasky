namespace Tasky.Client.Services.EpicService
{
    public class EpicService : IEpicService
    {

        private readonly HttpClient _httpClient;

      

        public EpicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Epic> CreateEpic(Epic addEpic)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Epic", addEpic);
            var Epics = await result.Content.ReadFromJsonAsync<Epic>();
            return Epics;
        }

        public async Task<Epic> DeleteEpic(int Id)
        {
            var result = await _httpClient.DeleteAsync($"api/Epic/{Id}");
            var deletedEpic = await result.Content.ReadFromJsonAsync<Epic>();
            return deletedEpic;
        }

        public async Task<Epic> GetEpicById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<Epic>($"api/Epic/{Id}");
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<Epic>> GetAllEpics()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Epic>>("api/Epic");
            if(result == null)
            {
                return null;
            }
            
            return result;
        }

        public async Task<Epic> UpdateEpic(Epic updateEpic)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Epic", updateEpic);
            var Epic = await result.Content.ReadFromJsonAsync<Epic>();
            return Epic;
        }
    }
}
