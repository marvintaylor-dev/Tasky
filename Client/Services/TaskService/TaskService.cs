using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Client.Services.TaskService
{
    public class TaskService : ITaskService
    {

        private readonly HttpClient _httpClient;
        private readonly IStatusService _statusService;
        public TaskService(HttpClient httpClient, IStatusService statusService)
        {
            _httpClient = httpClient;
            _statusService = statusService;
        }

        public async Task<NoteModel> AddTask(NoteModel addTask)
        {
            var result = await _httpClient.PostAsJsonAsync("api/notemodels", addTask);
            var tasks = await result.Content.ReadFromJsonAsync<NoteModel>();
            return tasks;
        }

        public async Task<NoteModel> DeleteTask(int taskId)
        {
            var result = await _httpClient.DeleteAsync($"api/notemodels/{taskId}");
            var deletedTask = await result.Content.ReadFromJsonAsync<NoteModel>();
            return deletedTask;
        }

        public async Task<List<NoteModel>> GetSubtasks()
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<NoteModel>>("api/notemodels/subtasks");
            if (tasks == null)
            {
                return null;
            }
            var tasksInOrder = tasks.OrderBy(x => x.Order ?? x.TaskId).ToList();
            return tasksInOrder;
        }

        public async Task<NoteModel?> GetTaskById(int? taskId)
        {
            if (taskId == null)
            {
                return null;
            }
            var result = await _httpClient.GetFromJsonAsync<NoteModel>($"api/notemodels/{taskId}");
            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<List<NoteModel>> GetTasks()
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<NoteModel>>("api/notemodels");
            if (tasks == null)
            {
                return null;
            }

            return tasks;
        }

        public async Task<List<NoteModel>> GetTasksInOrder()
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<NoteModel>>("api/notemodels/inorder");
            if (tasks == null)
            {
                return null;
            }

            return tasks;
        }

        public async Task<NoteModel> UpdateTask(NoteModel updateTask)
        {
            Console.WriteLine($"Update requested: Change name to {updateTask.Name}");
            var result = await _httpClient.PutAsJsonAsync($"api/notemodels", updateTask);
            var task = await result.Content.ReadFromJsonAsync<NoteModel>();
            Console.WriteLine(task?.Name);
            return task;
        }


        public int WorkInProgress(NoteModel task, StatusDTO firstStatus, StatusDTO lastStatus)
        {
            TimeSpan? WorkInProgress = TimeSpan.Zero;
            if (task == null || task.Status == firstStatus.StatusId)
            {
                WorkInProgress = TimeSpan.Zero;
                return WorkInProgress.GetValueOrDefault().Days;
            }
            else if (task.Status != lastStatus.StatusId)
            {
                WorkInProgress = DateTime.Now - task.StartDate;
                return WorkInProgress.GetValueOrDefault().Days;
            }
            else if(task.Status == lastStatus.StatusId)
            {
                if(task.EndDate != null)
                {
                   WorkInProgress = task.EndDate - task.StartDate;
                }
                else
                {
                    task.EndDate = DateTime.Today;
                    WorkInProgress = task.EndDate - task.StartDate;
                }
                return WorkInProgress.GetValueOrDefault().Days; 
            }
            else
            {
                return WorkInProgress.GetValueOrDefault().Days;
            }
        }
    }
}
