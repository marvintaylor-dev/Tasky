using Microsoft.EntityFrameworkCore;
using Tasky.Shared;

namespace Tasky.Server.Data.SectionRepository
{
    public class SectionRepository : ISectionRepository
    {

        private readonly AppDbContext _db;

        public SectionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Section> CreateSection(Section section)
        {
            var newSection = await _db.Sections.AddAsync(section);
            await _db.SaveChangesAsync();
            return newSection.Entity;
            
        }

        public async Task<Section> DeleteSection(int Id)
        {
            Section result = await _db.Sections.FirstOrDefaultAsync(s => s.SectionId == Id) ?? throw new Exception("Could not find section id");

            if (result != null)
            {
                _db.Sections.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            else
            {
                throw new Exception($"Section with Id = {Id} not found");
            }

        }

        public async Task<Section> GetSectionById(int Id)
        {
            Section singleSection = await _db.Sections.FirstOrDefaultAsync(s => s.SectionId.Equals(Id)) ?? throw new Exception("Could not find section id");

            if(singleSection != null)
            {
                return singleSection;
            }
            else
            {
                throw new Exception($"Section with an Id of {Id} was not found");
            }
        }

        public async Task<List<Section>> GetSections()
        {
            var result = await _db.Sections.ToListAsync();
            if (result == null)
            {
                throw new Exception("No Sections were found");
            }
            else
            {
                return result;
            }
        }

        public async Task<Section> UpdateSection(Section section)
        {
            Section result = _db.Sections.FirstOrDefault(s => s.SectionId == section.SectionId) ?? throw new Exception($"Could not find id");

            result.SectionId = section.SectionId;
            result.SectionName = section.SectionName;
            
            await _db.SaveChangesAsync();
            return result;
        }
    }
}
