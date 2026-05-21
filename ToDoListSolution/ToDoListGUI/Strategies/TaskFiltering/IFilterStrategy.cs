using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListGUI.Strategies.TaskFiltering
{
    public interface IFilterStrategy
    {
        public List<Todo> Filter(List<Todo> tasks);
    }
}
