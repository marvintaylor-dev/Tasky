using Microsoft.EntityFrameworkCore;
using Tasky.Server.Data;
using Tasky.Shared;

namespace Tasky.Server.Services
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<NoteModel> AddTask(NoteModel newTask)
        {
            var task = await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();
            return task.Entity;
        }

        public async Task<NoteModel> DeleteTask(int id)
        {
            NoteModel result = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == id) ?? throw new Exception("Could not find id");

            if (result != null)
            {
                _context.Tasks.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            else
            {
                throw new Exception($"Task with id {id} not found");
            }
        }

        public async Task<List<NoteModel>> GetAllTasks()
        {
            var result = await _context.Tasks.ToListAsync();

            if(result == null)
            {
                throw new Exception("No Tasks were found");
            }
            else
            {
            return result;
            }
        }

        public async Task<NoteModel> GetTaskById(int id)
        {
            NoteModel singleTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == id) ?? throw new Exception("Could not find id");
            if (singleTask != null)
            {
                return singleTask;
            }
            else
            {
                throw new Exception($"Task {id} was not found");
            }
        }

        public async Task<NoteModel> UpdateTask(NoteModel model)
        {
            NoteModel result = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == model.TaskId) ?? throw new Exception("Could not find id");

            result.Name = model.Name;
            result.Assignee = model.Assignee;
            result.PriorityLevel = model.PriorityLevel;
            result.DueDate = model.DueDate;
            result.Note = model.Note;
            result.status = model.status;
          
            await _context.SaveChangesAsync();
            return result;

        }
    }
}
