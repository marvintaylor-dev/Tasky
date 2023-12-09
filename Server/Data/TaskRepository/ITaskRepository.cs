using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Server.Data.TaskRepository
{
    public interface ITaskRepository
    {
        Task<List<NoteModel>> GetAllTasks();
        Task<List<NoteModel>> GetAllTasksInOrder();
        Task<List<NoteModel>> GetAllSubtasks();
        Task<List<NoteModel>> GetAllSubtasksByParentId(int parentId);
        Task<NoteModel> GetTaskById(int id);
        Task<NoteModel> AddTask(NoteModel model);
        Task<NoteModel> UpdateTask(NoteModel model);
        Task<NoteModel> DeleteTask(int id);
    }
}
