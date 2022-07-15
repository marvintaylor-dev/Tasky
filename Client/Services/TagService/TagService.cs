using System.Net.Http.Json;
using Tasky.Shared;

namespace Tasky.Client.Services.TagService
{
    public class TagService : ITagService
    {

        private readonly HttpClient _httpClient;

        public TagService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Tag> AddTag(Tag addTag)
        {
            var result = await _httpClient.PostAsJsonAsync("api/tags", addTag);
            var tags = await result.Content.ReadFromJsonAsync<Tag>();
            return tags;
        }

        public async Task<Tag> DeleteTag(int tagId)
        {
            var result = await _httpClient.DeleteAsync($"api/tags/{tagId}");
            var deletedTag = await result.Content.ReadFromJsonAsync<Tag>();
            return deletedTag;
        }

        public async Task<List<Tag>> GetAllTags()
        {
            var tags = await _httpClient.GetFromJsonAsync<List<Tag>>("api/tags");
            if (tags == null)
            {
                return null;
            }
            return tags;
        }

        public async Task<Tag> GetTagById(int tagId)
        {
            var result = await _httpClient.GetFromJsonAsync<Tag>($"api/tags/{tagId}");
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<Tag> UpdateTag(Tag updateTag)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/tags", updateTag);
            var tag = await result.Content.ReadFromJsonAsync<Tag>();
            return tag;
        }
    }
}
