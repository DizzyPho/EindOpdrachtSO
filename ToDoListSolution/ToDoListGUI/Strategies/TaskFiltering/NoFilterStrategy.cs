using System;
using System.Collections.Generic;
using System.Text;
using ToDoListGUI.ViewModels.TaskList;

namespace ToDoListGUI.Strategies.TaskFiltering
{
    public class NoFilterStrategy : IFilterStrategy
    {
        public List<TaskViewModel> Filter(List<TaskViewModel> tasks)
        {
            return new List<TaskViewModel>(tasks);
        }

        public bool PassesFilter(TaskViewModel task)
        {
            return true;
        }
    }
}
