using Dapper;
using Dapper.Contrib.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Task.Domain.AggregatesModel.ToDoItemAggregate;

namespace Task.API.Application.Commands
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly IConfiguration _configuration;
        public DeleteTaskCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
        {
            string sql = "DELETE FROM task.ToDoItems Where Id = @Id";
            var @params = new { Id = command.Id };
            
            using (SqlConnection connection = new SqlConnection(@_configuration.GetConnectionString("Task")))
            {
                var result = await connection.ExecuteAsync(sql, @params);

                return result > 0;
            }
        }
    }

}
