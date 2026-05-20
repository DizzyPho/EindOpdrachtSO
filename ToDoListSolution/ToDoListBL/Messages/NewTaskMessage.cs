using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListBL.Messages
{
    public class NewTaskMessage
    {
        public NewTaskMessage(Todo newTask)
        {
            NewTask = newTask;
        }

        public Todo NewTask { get; init; }
    }
}
