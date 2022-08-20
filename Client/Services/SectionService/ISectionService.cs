namespace Tasky.Client.Services.SectionService
{
    public interface ISectionService
    {
        Task<List<Section>> GetSections();
        Task<Section> GetSectionById(int Id);
        Task<Section> CreateSection(Section section);
        Task<Section> UpdateSection(Section section);
        Task<Section> DeleteSection(int Id);
         
    }
}
