using Tasky.Shared;

namespace Tasky.Server.Data.SectionNoteModelRepository
{
    public interface ISectionNoteModelRepository
    {
        Task<sectionNoteModel> GetLinks();
        Task<sectionNoteModel> GetLinkBySection(int sectionId);

        Task<sectionNoteModel> GetLinkByTask(int taskId);

        Task<sectionNoteModel> RemoveTask(int taskId);
    }
}
