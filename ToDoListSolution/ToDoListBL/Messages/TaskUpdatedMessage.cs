using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListBL.Messages
{
    public class TaskUpdatedMessage
    {
        public TaskUpdatedMessage(Todo updatedTask)
        {
            UpdatedTask = updatedTask;
        }

        public Todo UpdatedTask { get; init; }
    }
}
