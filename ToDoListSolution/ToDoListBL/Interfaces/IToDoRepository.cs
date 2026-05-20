using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListBL.Interfaces
{
    public interface IToDoRepository
    {
        public List<Todo> GetTasks();
        User GetUserById(string id);
        List<User> GetUsers();
        public void UpdateTask(Todo todo);
        void Upsert(User user);
        void Upsert(Todo todo);
    }
}
