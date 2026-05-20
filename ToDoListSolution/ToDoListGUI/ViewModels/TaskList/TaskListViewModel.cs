using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ToDoListBL.Services;
using ToDoListGUI.Commands;
using ToDoListGUI.Pages;
using ToDoListGUI.Routes;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.TaskList
{
    public class TaskListViewModel : BaseViewModel
    {
        NavigationService _navigation;
        public TaskListViewModel(ToDoService toDoService, NavigationService navigationService)
        {
            Tasks = new ObservableCollection<TaskViewModel>(
                                            toDoService.GetTasks()
                                            .Select(todo => new TaskViewModel(todo, toDoService)));
            _navigation = navigationService;

            NewTaskCommand = new AsyncCommand(OnNewTask);
            ShowUsersCommand = new AsyncCommand(OnShowUsers);            
        }

        public ObservableCollection<TaskViewModel> Tasks { get; }
        public TaskViewModel SelectedTask
        {
            get => Get<TaskViewModel>();
            set
            {
                Set(value);
                if (SelectedTask != null)
                {
                    OnTaskClicked(value).ConfigureAwait(false);
                    SelectedTask = null;
                }
            }
        }
        public ICommand NewTaskCommand { get; init; }
        public ICommand ShowUsersCommand { get; init; }

        public async Task OnNewTask()
        {
            await _navigation.GoToAsync<TaskDetailPage>();
        }
        public async Task OnShowUsers()
        {
            await _navigation.GoToAsync<UserListPage>();
        }
        public async Task OnTaskClicked(TaskViewModel task)
        {
            await _navigation.EditTaskPage(task.Id);
        }
    }
}
