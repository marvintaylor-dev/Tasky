using Tasky.Shared;

namespace Tasky.Server.Data.SectionRepository
{
    public interface ISectionRepository
    {
        Task<List<Section>> GetSections();
        Task<Section> GetSectionById(int Id);
        Task<Section> CreateSection(Section section);
        Task<Section> UpdateSection(Section section);
        Task<Section> DeleteSection(int Id);
    }
}
