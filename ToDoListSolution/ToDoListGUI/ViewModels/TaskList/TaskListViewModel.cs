using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoListBL.Services;

namespace ToDoListGUI.ViewModels.TaskList
{
    public class TaskListViewModel
    {
        public TaskListViewModel(ToDoService toDoService)
        {
            Tasks = new ObservableCollection<TaskViewModel>(
                                            toDoService.GetTasks()
                                            .Select(todo => new TaskViewModel(todo)));
        }

        public ObservableCollection<TaskViewModel> Tasks { get; }
    }
}
