using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ToDoListBL.Domain;
using ToDoListBL.Messages;
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
        ToDoService _toDoService;
        public TaskListViewModel(ToDoService toDoService, NavigationService navigationService, MessageService messageService)
        {
            Tasks = new ObservableCollection<TaskViewModel>(
                                            toDoService.GetTasks()
                                            .Select(todo => new TaskViewModel(todo, toDoService)));
            _navigation = navigationService;
            _toDoService = toDoService;

            NewTaskCommand = new AsyncCommand(OnNewTask);
            ShowUsersCommand = new AsyncCommand(OnShowUsers);

            messageService.Register<NewTaskMessage>(this, (o, message) => OnNewTask(message.NewTask));
            messageService.Register<TaskUpdatedMessage>(this, (o, message) => OnTaskUpdated(message.UpdatedTask));

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

        public void OnTaskUpdated(Todo task)
        {
            TaskViewModel taskVM = Tasks.First(vm => task.Id == vm.Id);
            taskVM.Title = task.Title;
            taskVM.Description = task.Description;
            taskVM.IsCompleted = task.IsCompleted;
        }

        public void OnNewTask(Todo task)
        {
            Tasks.Add(new TaskViewModel(task, _toDoService));
        }
    }
}
