using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Task.Domain.AggregatesModel.ToDoItemAggregate;
using Task.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Task.API.Application.Commands
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITaskDbContext _dbContext;
        public DeleteTaskCommandHandler(ITaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Query<ToDoItem>().FirstOrDefaultAsync(x => x.Id == command.Id);
            if (item != null) 
            {
                _dbContext.Query<ToDoItem>().Remove(item);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? true : false;
            }
            
            return false;
        }
    }

}
