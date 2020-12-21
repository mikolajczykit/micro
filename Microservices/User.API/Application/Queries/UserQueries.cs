using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.UserAggregate;
using User.Infrastructure;

namespace User.API.Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private IUserDbContext _dbContext { get; set; }
        
        public UserQueries(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            var data = await _dbContext.Query<UserEntity>().Select(x => new UserViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                ActiveTaskCount = x.ActiveTaskCount
            }).ToListAsync();

            return data;
        }
    }
}
