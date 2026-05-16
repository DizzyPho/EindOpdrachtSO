using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Interfaces;

namespace ToDoListDL.Repositories
{
    public class LiteDBToDoRepository : IToDoRepository
    {
        public LiteDatabase _db;

        public LiteDBToDoRepository(LiteDatabase db)
        {
            _db = db;
        }
    }
}
