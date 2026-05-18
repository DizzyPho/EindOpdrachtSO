using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;
using ToDoListBL.Interfaces;

namespace ToDoListBL.Services
{
    public class ToDoService
    {
        private IToDoRepository _repo;

        public ToDoService(IToDoRepository repo)
        {
            _repo = repo;
        }

        public List<Todo> GetTasks()
        {
            return _repo.GetTasks();
        }

        public List<User> GetUsers()
        {
            return _repo.GetUsers();
        }

        public void UpdateTask(Todo todo)
        {
            _repo.UpdateTask(todo);
        }

        public void Upsert(User user)
        {
            _repo.Upsert(user);
        }
    }
}
