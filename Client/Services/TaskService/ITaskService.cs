using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Client.Services.TaskService
{
    public interface ITaskService
    {
        Task<List<NoteModel>> GetTasks();
        Task<List<NoteModel>> GetTasksInOrder();

        Task<List<NoteModel>> GetSubtasks();
        Task<List<NoteModel>> GetSubtasksByParentId(int parentId);
        Task<NoteModel> GetTaskById(int? taskId);
        Task<NoteModel> AddTask(NoteModel addTask);
        Task<List<NoteModel>> AddMultipleTasks(List<NoteModel> tasks);
        Task<NoteModel> UpdateTask(NoteModel updateTask);
        Task<NoteModel> DeleteTask(int taskId);

        public int WorkInProgress(NoteModel task, StatusDTO firstStatus, StatusDTO lastStatus);
    }
}
