using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Application.Queries
{
    public interface ITaskQueries
    {
        Task<List<ToDoItemViewModel>> GetTasksAsync();
    }
}
