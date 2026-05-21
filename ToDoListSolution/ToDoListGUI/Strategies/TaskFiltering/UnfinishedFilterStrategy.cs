using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;
using ToDoListGUI.ViewModels.TaskList;

namespace ToDoListGUI.Strategies.TaskFiltering
{
    public class UnfinishedFilterStrategy : IFilterStrategy
    {
        public List<TaskViewModel> Filter(List<TaskViewModel> tasks)
        {
            return tasks.Where(task => task.IsCompleted == false).ToList();
        }

        public bool PassesFilter(TaskViewModel task)
        {
            return task.IsCompleted == false;
        }
    }
}
