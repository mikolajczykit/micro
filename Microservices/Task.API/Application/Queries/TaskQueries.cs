using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Domain.AggregatesModel.ToDoItemAggregate;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Task.API.Application.Queries
{
    public class TaskQueries : ITaskQueries
    {        
        private readonly IConfiguration _configuration;
        public TaskQueries(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ToDoItemViewModel>> GetTasksAsync()
        {
            string sql = "SELECT * FROM task.ToDoItems";
            
            using (SqlConnection connection = new SqlConnection(@_configuration.GetConnectionString("Task")))
            {
                var result = await connection.QueryAsync<ToDoItem>(sql);
                var data = result.Select(x => new ToDoItemViewModel
                {
                    Description = x.Description,
                    DueDate = x.DueDate,
                    Title = x.Title,
                    Id = x.Id
                }).AsList();
                return data;
            }
        }
    }
}
