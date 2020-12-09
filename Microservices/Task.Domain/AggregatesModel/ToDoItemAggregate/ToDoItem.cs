﻿using System;
using System.Collections.Generic;
using System.Text;
using Task.Domain.SeedWork;

namespace Task.Domain.AggregatesModel.ToDoItemAggregate
{
    public class ToDoItem : Entity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
