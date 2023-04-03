﻿using Tasky.Shared;

namespace Tasky.Client.Services.TaskService
{
    public interface ITaskService
    {
        Task<List<NoteModel>> GetTasks();
        Task<List<NoteModel>> GetTasksInOrder();

        Task<List<NoteModel>> GetSubtasks();
        Task<NoteModel> GetTaskById(int? taskId);
        Task<NoteModel> AddTask(NoteModel addTask);
        Task<NoteModel> UpdateTask(NoteModel updateTask);
        Task<NoteModel> DeleteTask(int taskId);

        public int WorkInProgress(NoteModel task);
    }
}