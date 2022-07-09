using Tasky.Shared;

namespace Tasky.Client.Services
{
    public interface ITagService
    {
        Task<List<Tag>> GetAllTags();
        Task<Tag> GetTagById(int tagId);
        Task<Tag> AddTag(Tag addTag);
        Task<Tag> UpdateTag(Tag updateTag);
        Task<Tag> DeleteTag(int id);
    }
}
