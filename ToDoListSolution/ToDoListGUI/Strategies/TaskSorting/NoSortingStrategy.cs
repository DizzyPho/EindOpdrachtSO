using System;
using System.Collections.Generic;
using System.Text;
using ToDoListGUI.ViewModels.TaskList;

namespace ToDoListGUI.Strategies.TaskSorting
{
    public class NoSortingStrategy : IComparer<TaskViewModel>
    {
        public int Compare(TaskViewModel? x, TaskViewModel? y)
        {
            return 0;
        }
    }
}
