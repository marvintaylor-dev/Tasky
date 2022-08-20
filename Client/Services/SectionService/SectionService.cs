namespace Tasky.Client.Services.SectionService
{
    public class SectionService : ISectionService
    {

        private readonly HttpClient _httpClient;

        public SectionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Section> CreateSection(Section addSection)
        {
            var result = await _httpClient.PostAsJsonAsync("api/sections", addSection);
            var sections = await result.Content.ReadFromJsonAsync<Section>();
            return sections;
        }

        public async Task<Section> DeleteSection(int Id)
        {
            var result = await _httpClient.DeleteAsync($"api/sections/{Id}");
            var deletedSection = await result.Content.ReadFromJsonAsync<Section>();
            return deletedSection;
        }

        public async Task<Section> GetSectionById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<Section>($"api/sections/{Id}");
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<Section>> GetSections()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Section>>("api/sections");
            if(result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<Section> UpdateSection(Section updateSection)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/sections", updateSection);
            var section = await result.Content.ReadFromJsonAsync<Section>();
            return section;
        }
    }
}
