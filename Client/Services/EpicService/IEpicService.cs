namespace Tasky.Client.Services.EpicService
{
    public interface IEpicService
    {
        Task<List<Epic>> GetAllEpics();
        Task<Epic> GetEpicById(int Id);
        Task<Epic> CreateEpic(Epic Epic);
        Task<Epic> UpdateEpic(Epic Epic);
        Task<Epic> DeleteEpic(int Id);
         
    }
}
