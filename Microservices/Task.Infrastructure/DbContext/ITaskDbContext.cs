using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Domain.SeedWork;

namespace Task.Infrastructure
{
    public interface ITaskDbContext
    {
        DbSet<T> Query<T>() where T : Entity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
