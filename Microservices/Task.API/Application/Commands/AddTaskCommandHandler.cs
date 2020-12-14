using Dapper.Contrib.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Task.Domain.AggregatesModel.ToDoItemAggregate;

namespace Task.API.Application.Commands
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, bool>
    {
        private readonly ILogger<AddTaskCommandHandler> _logger;
        private readonly IConfiguration _configuration;

        public AddTaskCommandHandler(IConfiguration configuration, ILogger<AddTaskCommandHandler> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> Handle(AddTaskCommand command, CancellationToken cancellationToken)
        {
            var todoItem = new ToDoItem
            {
                Description = command.Description,
                DueDate = command.DueDate,
                Title = command.Title
            };
            try
            {
                using (SqlConnection connection = new SqlConnection(@_configuration.GetConnectionString("Task")))
                {
                    var result = await connection.InsertAsync<ToDoItem>(todoItem);
                    return result > 0;
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }

}
