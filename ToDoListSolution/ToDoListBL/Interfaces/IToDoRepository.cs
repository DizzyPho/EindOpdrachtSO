using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListBL.Interfaces
{
    public interface IToDoRepository
    {
        Todo GetTaskById(string id);
        public List<Todo> GetTasks();
        User GetUserById(string id);
        List<User> GetUsers();
        void Upsert(User user);
        void Upsert(Todo todo);
        public void DeleteUser(string id);
    }
}
