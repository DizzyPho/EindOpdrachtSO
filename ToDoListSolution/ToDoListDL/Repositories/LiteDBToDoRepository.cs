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
            _db.GetCollection<Todo>().Insert(new Todo(1, "test", "this is a test", false, 1));
            _db.GetCollection<Todo>().Insert(new Todo(2, "test", "this is a test", false, 1));
            _db.GetCollection<Todo>().Insert(new Todo(3, "test", "this is a test", false, 1));
            _db.GetCollection<Todo>().Insert(new Todo(4, "test", "this is a test", false, 1));
            _db.GetCollection<Todo>().Insert(new Todo(4, "test", "this is a test", false, 1));
            _db.GetCollection<Todo>().Insert(new Todo(5, "test", "this is a test", false, 1));
        }

        public List<Todo> GetTasks()
        {
            return _db.GetCollection<Todo>().FindAll().ToList();
        }
    }
}
