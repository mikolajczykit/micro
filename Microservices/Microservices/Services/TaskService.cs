using Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Infrastructure;

namespace Web.Services
{
    public class TaskService : ITaskService
    {
        private readonly string _baseMicroserviceUrl;
        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient, IConfiguration configuration)
        {
            _baseMicroserviceUrl = configuration.GetValue<string>(AppSettings.TaskApi);
            _httpClient = httpClient;
        }

        public async Task<bool> AddTaskAsync(CreateToDoListItemViewModel viewModel)
        {
            var microserviceAddTaskUrl = API.Task.AddTask(_baseMicroserviceUrl);
            var taskContent = new StringContent(JsonConvert.SerializeObject(viewModel), System.Text.Encoding.UTF8, "application/json");

            var responseObject = await _httpClient.PostAsync(microserviceAddTaskUrl, taskContent);

            return responseObject.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ToDoItemViewModel>> GetTasksAsync()
        {
            var microserviceGetTasksUrl = API.Task.GetAllTasks(_baseMicroserviceUrl);

            var responseString = await _httpClient.GetStringAsync(microserviceGetTasksUrl);

            var response = JsonConvert.DeserializeObject<IEnumerable<ToDoItemViewModel>>(responseString);
            return response;
        }
    }
}
