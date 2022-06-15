using Tasky.Shared;

namespace Tasky.Client.Services
{
    public interface ITaskService
    {
        Task<List<NoteModel>> GetTasks();
        Task<NoteModel> AddTask(NoteModel addTask);
        Task<NoteModel> UpdateTask(NoteModel updateTask);
        Task<NoteModel> DeleteTask(int taskId);
    }
}
