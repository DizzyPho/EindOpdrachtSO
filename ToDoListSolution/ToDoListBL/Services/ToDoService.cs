using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
