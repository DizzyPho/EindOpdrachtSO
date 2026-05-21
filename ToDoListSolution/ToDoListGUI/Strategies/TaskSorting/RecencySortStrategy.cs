using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;
using ToDoListGUI.ViewModels.TaskList;

namespace ToDoListGUI.Strategies.TaskSorting
{
    internal class RecencySortStrategy : IComparer<TaskViewModel>
    {
        public int Compare(TaskViewModel? x, TaskViewModel? y)
        {
            return DateTime.Compare(x.CreationDate, y.CreationDate);
        }
    }
}
