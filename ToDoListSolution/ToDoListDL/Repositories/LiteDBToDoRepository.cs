using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;
using ToDoListBL.Interfaces;
using ToDoListDL.Connections;

namespace ToDoListDL.Repositories
{
    public class LiteDBToDoRepository : IToDoRepository
    {
        public LiteDBConnection _db;

        public LiteDBToDoRepository(LiteDBConnection db)
        {
            _db = db;
        }

        public Todo GetTaskById(string id)
        {
            return _db.GetCollection<Todo>().FindById(id);
        }

        public List<Todo> GetTasks()
        {
            return _db.GetCollection<Todo>().FindAll().ToList();
        }

        public User GetUserById(string id)
        {
            return _db.GetCollection<User>().FindById(id);
        }

        public List<User> GetUsers()
        {
            return _db.GetCollection<User>().FindAll().ToList();
        }

        public void Upsert(User user)
        {
            _db.GetCollection<User>().Upsert(user);
        }

        public void Upsert(Todo todo)
        {
            _db.GetCollection<Todo>().Upsert(todo);
        }
    }
}
