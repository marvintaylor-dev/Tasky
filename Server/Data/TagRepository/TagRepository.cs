using Microsoft.EntityFrameworkCore;
using Tasky.Shared;

namespace Tasky.Server.Data.TagRepository
{
    public class TagRepository : ITagRepository
    {

        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> AddTag(Tag addTag)
        {
            var tag = await _context.Tags.AddAsync(addTag);
            await _context.SaveChangesAsync();
            return tag.Entity;
        }

        public async Task<Tag> DeleteTag(int id)
        {
            Tag result = await _context.Tags.FirstOrDefaultAsync(t => t.TagId == id) ?? throw new Exception("Could not find id");

            if (result != null)
            {
                _context.Tags.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            else
            {
                throw new Exception($"Task with id {id} not found");
            }
        }

        public async Task<List<Tag>> GetAllTags()
        {
            var result = await _context.Tags.ToListAsync();

            if (result == null)
            {
                throw new Exception("No Tasks were found");
            }
            else
            {
                return result;
            }
        }

        public async Task<Tag> GetTagById(int tagId)
        {
            Tag singleTag = await _context.Tags.FirstOrDefaultAsync(t => t.TagId == tagId) ?? throw new Exception("Could not find id");
            if (singleTag != null)
            {
                return singleTag;
            }
            else
            {
                throw new Exception($"Task {tagId} was not found");
            }
        }

        public async Task<Tag> UpdateTag(Tag updateTag)
        {
            Tag result = await _context.Tags.FirstOrDefaultAsync(t => t.TagId == updateTag.TagId) ?? throw new Exception("Could not find id");

            result.TagName = updateTag.TagName;
            result.Color = updateTag.Color;

            await _context.SaveChangesAsync();
            return result;
        }
    }
}
