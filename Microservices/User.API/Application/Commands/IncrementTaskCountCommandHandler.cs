using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.UserAggregate;
using User.Infrastructure;

namespace User.API.Application.Commands
{
    public class IncrementTaskCountCommandHandler : IRequestHandler<IncrementTaskCountCommand, bool>
    {
        private readonly IUserDbContext _dbContext;
        public IncrementTaskCountCommandHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(IncrementTaskCountCommand command, CancellationToken cancellationToken)
        {
            var user = _dbContext.Query<UserEntity>().Where(x => x.Id == command.Id).SingleOrDefault();

            if (user != null) 
            {
                user.IncrementTaskCount();
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? true : false;
            }

            return false;
        }
    }

}
