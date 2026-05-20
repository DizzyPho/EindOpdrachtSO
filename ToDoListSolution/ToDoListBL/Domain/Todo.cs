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

        public string Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string ResponsibleUserId { get; set; }
    }
}
