using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ToDoListBL.Services;
using ToDoListGUI.Pages;
using ToDoListGUI.Routes;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.TaskList
{
    public class TaskListViewModel
    {
        NavigationService _navigation;
        public TaskListViewModel(ToDoService toDoService, NavigationService navigationService)
        {
            Tasks = new ObservableCollection<TaskViewModel>(
                                            toDoService.GetTasks()
                                            .Select(todo => new TaskViewModel(todo, toDoService)));
            _navigation = navigationService;

            NewTaskCommand = new Command(OnNewTask);
            
        }

        public ObservableCollection<TaskViewModel> Tasks { get; }
        public ICommand NewTaskCommand { get; init; }

        public void OnNewTask()
        {
            // task.run causes COMexception
            _navigation.GoToAsync<TaskDetailPage>();
        }
    }
}
