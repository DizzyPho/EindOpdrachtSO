using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListBL.Domain
{
    public class Todo
    {
        public Todo(string title, string description, bool isCompleted, string responsibleUserId, DateTime creationDate, string id = null)
            : this(title, description, isCompleted, responsibleUserId, creationDate, creationDate, id)
        {
        }

        public Todo(string title, string description, bool isCompleted, string responsibleUserId, DateTime creationDate, DateTime lastChangeDate, string id = null)

        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            ResponsibleUserId = responsibleUserId;
            CreationDate = creationDate;
            LastModifiedDate = lastChangeDate;

            if (id == null)
                Id = Guid.NewGuid().ToString();
            else
                Id = id;

        }

        public string Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreationDate { get; init; }
        public DateTime LastModifiedDate { get; set; }
        public string ResponsibleUserId { get; set; }
    }
}
