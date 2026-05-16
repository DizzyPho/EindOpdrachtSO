using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListDL.Connections
{
    public class LiteDBConnection
    {
        private string _connectionString = "todolist.db";
        private LiteDatabase _db;

        public LiteDBConnection()
        {
            _db = new LiteDatabase(_connectionString);
        }

        public ILiteCollection<T> GetCollection<T>()
        {
            return _db.GetCollection<T>();
        }
    }
}
