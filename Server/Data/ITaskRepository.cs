using Tasky.Shared;

namespace Tasky.Server.Services
{
    public interface ITaskRepository
    {
       Task<List<NoteModel>> GetAllTasks();
       Task<NoteModel> GetTaskById(int id);

       Task<NoteModel> AddTask(NoteModel model);
       Task<NoteModel> UpdateTask(NoteModel model);
       Task<NoteModel> DeleteTask(int id);
    }
}
