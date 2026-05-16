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

        public List<Todo> GetTasks()
        {
            return _db.GetCollection<Todo>().FindAll().ToList();
        }
    }
}
