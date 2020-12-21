using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.UserAggregate
{
    public class UserEntity : Entity, IAggregateRoot
    {
        public UserEntity(string name, string surname, string email) 
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.ActiveTaskCount = 0;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public int ActiveTaskCount { get; private set; }

        public void IncrementTaskCount() 
        {
            this.ActiveTaskCount++;
        }

        public void DecrementTaskCount()
        {
            this.ActiveTaskCount--;
        }
    }
}
