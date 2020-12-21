using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Infrastructure.EntitiesConfigurations;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.SeedWork;

namespace User.Infrastructure
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public const string DEFAULT_SCHEMA = "user";
        protected DbSet<UserEntity> Users { get; set; }

        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
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
