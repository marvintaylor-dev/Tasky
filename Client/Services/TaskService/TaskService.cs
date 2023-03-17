using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Tasky.Shared;

namespace Tasky.Client.Services.TaskService
{
    public class TaskService : ITaskService
    {

        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

        public async Task<NoteModel?> GetTaskById(int? taskId)
        {
            if (taskId == null)
            {
                return null;
            }
            var result = await _httpClient.GetFromJsonAsync<NoteModel>($"api/notemodels/{taskId}");
            if(result == null )
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



        public async Task<NoteModel> UpdateTask(NoteModel updateTask)
        {
            Console.WriteLine($"Update requested: Change name to {updateTask.Name}");
            var result = await _httpClient.PutAsJsonAsync($"api/notemodels", updateTask);
            var task = await result.Content.ReadFromJsonAsync<NoteModel>();
            Console.WriteLine(task?.Name);
            return task;
        }


        public int WorkInProgress(NoteModel task)
        {
            TimeSpan WorkInProgress = TimeSpan.Zero;
            if (task == null)
            {
                return WorkInProgress.Days;
            }
            else if(task.status == Status.Completed)
            {
                return WorkInProgress.Days;
            }
            else
            {
                WorkInProgress = DateTime.Now - task.StartDate;
                return WorkInProgress.Days;
            }
        }
    }
}
