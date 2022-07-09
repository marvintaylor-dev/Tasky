using Tasky.Shared;

namespace Tasky.Server.Data
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllTags();
        Task<Tag> GetTagById(int tagId);
        Task<Tag> AddTag(Tag addTag);
        Task<Tag> UpdateTag(Tag updateTag);
        Task<Tag> DeleteTag(int id);
    }
}
