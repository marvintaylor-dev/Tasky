using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tasky.Server.Data;
using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Server.Data.TaskRepository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TaskRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NoteModel> AddTask(NoteModel newTask)
        {
            var firstStatus = await _context.Statuses.OrderBy(x => x.StatusOrder).FirstAsync();
            if(newTask.Status == null)
            {
                newTask.Status = firstStatus.StatusId;
            }
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
            if (result == null)
            {
                throw new Exception("No Tasks were found");
            }
            else
            {
                
                return result;
            }
        }

        public async Task<List<NoteModel>> GetAllTasksInOrder()
        {
            var result = await _context.Tasks.OrderBy(x => x.Order ?? x.TaskId).ToListAsync();
            if (result == null)
            {
                throw new Exception("No Tasks were found");
            }
            else
            {

                return result;
            }
        }

        public async Task<List<NoteModel>> GetAllSubtasks()
        {
            var result = await _context.Tasks.Where(x => x.isSubTask == true).ToListAsync();
            if (result == null)
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
            _mapper.Map(model, result);

            await _context.SaveChangesAsync();
            return result;
        }

       
    }
}
