using System;
using System.Collections.Generic;
using System.Text;
using Task.Domain.SeedWork;

namespace Task.Domain.AggregatesModel.ToDoItemAggregate
{
    public class ToDoItem : Entity, IAggregateRoot
    {
        public ToDoItem(string title, string description, DateTime dueDate) 
        {
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;
            this.UserId = 0;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public int UserId { get; private set; }
    }
}
