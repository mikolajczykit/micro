using Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<ToDoItemViewModel>> GetTasksAsync();

        Task<bool> AddTaskAsync(CreateToDoListItemViewModel viewModel);
    }
}
