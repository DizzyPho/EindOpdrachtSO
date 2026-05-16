using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
