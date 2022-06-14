﻿using System.Net.Http.Json;
using Tasky.Shared;

namespace Tasky.Client.Services
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
            var result = await _httpClient.PostAsJsonAsync<NoteModel>("api/notemodels", addTask);
            var tasks = await result.Content.ReadFromJsonAsync<NoteModel>();
            return tasks;
        }

        public async Task<NoteModel> DeleteTask(int taskId)
        {
           var result = await _httpClient.DeleteAsync($"api/notemodels/{taskId}");
            var deletedTask = await result.Content.ReadFromJsonAsync<NoteModel>();
            return deletedTask;
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
    }
}
