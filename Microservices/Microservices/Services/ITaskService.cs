using Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<ToDoItemViewModel>> GetTasksAsync();

        Task<bool> AddTaskAsync(CreateToDoListItemViewModel viewModel);

        Task<bool> DeleteTaskAsync(int id);
    }
}
