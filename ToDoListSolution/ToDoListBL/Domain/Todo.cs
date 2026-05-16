using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListBL.Domain
{
    public class Todo
    {
        public Todo(int id, string title, string description, bool isCompleted, int responsibleUserId)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            ResponsibleUserId = responsibleUserId;
        }

        public int Id {  get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public bool IsCompleted { get; init; }
        public int ResponsibleUserId { get; init; }
    }
}
