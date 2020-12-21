using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using User.Domain.SeedWork;

namespace User.Infrastructure
{
    public interface IUserDbContext
    {
        DbSet<T> Query<T>() where T : Entity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
