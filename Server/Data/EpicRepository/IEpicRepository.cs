using Tasky.Shared;

namespace Tasky.Server.Data.EpicRepository
{
    public interface IEpicRepository
    {
        Task<List<Epic>> GetAllEpics();
        Task<Epic> GetEpicById(int Id);
        Task<Epic> CreateEpic(Epic epic);
        Task<Epic> UpdateEpic(Epic epic);
        Task<Epic> DeleteEpic(int Id);
    }
}
