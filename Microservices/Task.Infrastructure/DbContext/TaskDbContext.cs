using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Domain.AggregatesModel.ToDoItemAggregate;
using Task.Domain.SeedWork;
using Task.Infrastructure.EntitiesConfigurations;

namespace Task.Infrastructure
{
    public class TaskDbContext : DbContext, ITaskDbContext
    {
        public const string DEFAULT_SCHEMA = "task";
        protected DbSet<ToDoItem> ToDoItems { get; set; }

        public TaskDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoItemEntityTypeConfiguration());
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public new DbSet<T> Query<T>() where T : Entity
        {
            return base.Set<T>();
        }
    }
}
