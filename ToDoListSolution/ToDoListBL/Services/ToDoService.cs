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
        private MessageService _messageService;

        public ToDoService(IToDoRepository repo, MessageService messageService)
        {
            _repo = repo;
            _messageService = messageService;
        }

        public List<Todo> GetTasks()
        {
            return _repo.GetTasks();
        }

        public User GetUserById(string id)
        {
            return _repo.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return _repo.GetUsers();
        }

        public void UpdateTask(Todo todo)
        {
            _repo.UpdateTask(todo);
        }

        public void UpdateUser(User user)
        {
            _repo.Upsert(user);
        }

        public void SaveNewUser(User user)
        {
            _repo.Upsert(user);
        }
    }
}
