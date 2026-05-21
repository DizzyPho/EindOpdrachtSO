using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListGUI.Strategies.TaskFiltering
{
    public class UnfinishedFilterStrategy : IFilterStrategy
    {
        public List<Todo> Filter(List<Todo> tasks)
        {
            return tasks.Where(task => task.IsCompleted == false).ToList();
        }
    }
}
