using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Domain.AggregatesModel.ToDoItemAggregate;
using Task.Infrastructure;

namespace Task.API.Application.Queries
{
    public class TaskQueries : ITaskQueries
    {
        private ITaskDbContext _dbContext { get; set; }
        
        public TaskQueries(ITaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ToDoItemViewModel>> GetTasksAsync()
        {
            var data = await _dbContext.Query<ToDoItem>().Select(x => new ToDoItemViewModel
            {
                Id = x.Id,
                Description = x.Description,
                DueDate = x.DueDate,
                Title = x.Title
            }).ToListAsync();

            return data;
        }
    }
}
