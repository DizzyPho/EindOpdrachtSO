using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListBL.Interfaces
{
    public interface IToDoRepository
    {
        public List<Todo> GetTasks();
        List<User> GetUsers();
        public void UpdateTask(Todo todo);
    }
}
