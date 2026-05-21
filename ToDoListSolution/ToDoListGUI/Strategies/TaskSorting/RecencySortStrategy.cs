using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListGUI.Strategies.TaskSorting
{
    internal class RecencySortStrategy : IComparer<Todo>
    {
        public int Compare(Todo? x, Todo? y)
        {
            return DateTime.Compare(x.CreationDate, y.CreationDate);
        }
    }
}
