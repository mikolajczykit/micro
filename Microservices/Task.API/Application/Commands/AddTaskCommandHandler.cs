using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Task.Domain.AggregatesModel.ToDoItemAggregate;
using Task.Infrastructure;

namespace Task.API.Application.Commands
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, bool>
    {
        private readonly ITaskDbContext _dbContext;
        public AddTaskCommandHandler(ITaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(AddTaskCommand command, CancellationToken cancellationToken)
        {
            var todoItem = new ToDoItem
            {
                Description = command.Description,
                DueDate = command.DueDate,
                Title = command.Title
            };

            await _dbContext.Query<ToDoItem>().AddAsync(todoItem);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }

}
