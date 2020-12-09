using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Task.Domain.AggregatesModel.ToDoItemAggregate;

namespace Task.Infrastructure.EntitiesConfigurations
{
    public class ToDoItemEntityTypeConfiguration
     : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> todoItemConfiguration)
        {
            todoItemConfiguration.ToTable("ToDoItems", TaskDbContext.DEFAULT_SCHEMA);

            todoItemConfiguration.HasKey(o => o.Id);

            todoItemConfiguration.Property<string>(x => x.Title)
                .IsRequired();

            todoItemConfiguration.Property<string>(x => x.Description)
                .IsRequired();

            todoItemConfiguration.Property<DateTime>(x => x.DueDate)
                .IsRequired();
        }
    }
}