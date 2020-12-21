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
    public class DecrementTaskCountCommandHandler : IRequestHandler<DecrementTaskCountCommand, bool>
    {
        private readonly IUserDbContext _dbContext;
        public DecrementTaskCountCommandHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DecrementTaskCountCommand command, CancellationToken cancellationToken)
        {
            var user = _dbContext.Query<UserEntity>().Where(x => x.Id == command.Id).SingleOrDefault();

            if (user != null) 
            {
                user.DecrementTaskCount();
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? true : false;
            }

            return false;
        }
    }

}
