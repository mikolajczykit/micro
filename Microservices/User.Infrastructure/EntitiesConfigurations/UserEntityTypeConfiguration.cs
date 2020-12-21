using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregatesModel.UserAggregate;
using User.Infrastructure;

namespace Task.Infrastructure.EntitiesConfigurations
{
    public class UserEntityTypeConfiguration
     : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> userConfiguration)
        {
            userConfiguration.ToTable("Users", UserDbContext.DEFAULT_SCHEMA);

            userConfiguration.HasKey(o => o.Id);

            userConfiguration.Property<string>(x => x.Name)
                .IsRequired();

            userConfiguration.Property<string>(x => x.Surname)
                .IsRequired();

            userConfiguration.Property<string>(x => x.Email)
                .IsRequired();

            userConfiguration.Property<int>(x => x.ActiveTaskCount)
                .IsRequired();
        }
    }
}