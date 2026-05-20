using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;
using ToDoListBL.Interfaces;
using ToDoListBL.Messages;

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

        public void UpdateTaskCompleted(Todo todo)
        {
            _repo.Upsert(todo);
        }
        public void UpdateTask(Todo todo)
        {
            _repo.Upsert(todo);
            _messageService.Send<TaskUpdatedMessage>(new TaskUpdatedMessage(todo));
        }

        public void UpdateUser(User user)
        {
            _repo.Upsert(user);
            _messageService.Send<UserUpdatedMessage>(new UserUpdatedMessage(user));
        }

        public void SaveNewUser(User user)
        {
            _repo.Upsert(user);
            _messageService.Send<NewUserMessage>(new NewUserMessage(user));
        }

        public void SaveNewTask(Todo task)
        {
            _repo.Upsert(task);
            _messageService.Send<NewTaskMessage>(new NewTaskMessage(task));
        }

        public Todo GetTaskById(string id)
        {
            return _repo.GetTaskById(id);
        }
    }
}
