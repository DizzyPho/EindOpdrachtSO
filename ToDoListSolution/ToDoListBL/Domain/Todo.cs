using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListBL.Domain
{
    public class Todo
    {
        public Todo(string title, string description, bool isCompleted, string responsibleUserId, string id = null)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            ResponsibleUserId = responsibleUserId;

            if(id == null)
                Id = Guid.NewGuid().ToString();
            else
                Id = id;
                
        }

        public string Id {  get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public bool IsCompleted { get; set; }
        public string ResponsibleUserId { get; init; }
    }
}
