using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ToDoListBL.Domain;
using ToDoListBL.Services;
using ToDoListGUI.Commands;
using ToDoListGUI.PageStates;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.TaskDetail
{
    public class TaskDetailViewModel : BaseViewModel, IQueryAttributable
    {
        ToDoService _toDoService;
        NavigationService _navigationService;
        MessageService _messageService;
        Todo? _currentTask;
        public PageState State { get; private set; }

        public TaskDetailViewModel(ToDoService toDoService, NavigationService navigationService, MessageService messageService)
        {
            _toDoService = toDoService;
            _navigationService = navigationService;
            _messageService = messageService;

            var users = _toDoService.GetUsers();
            UserNames = new List<UserNameViewModel>(users.Select(user => new UserNameViewModel(user)));

            GoBackCommand = new AsyncCommand(OnGoBack);
            SaveCommand = new AsyncCommand(OnSave);
        }

        public string Title
        {
            get => Get<string>();
            set => Set(value);
        }
        public string Description
        {
            get => Get<string>();
            set => Set(value);
        }
        public bool IsCompleted
        {
            get => Get<bool>(); 
            set => Set(value);
        }
        public ICommand GoBackCommand { get; init; }
        public ICommand SaveCommand { get; init; }
        public List<UserNameViewModel> UserNames { get; init; }
        public UserNameViewModel SelectedUser
        {
            get => Get<UserNameViewModel>();
            set => Set(value);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if(query.TryGetValue("id", out object oId) && oId is string id)
            {
                _currentTask = _toDoService.GetTaskById(id);
                Title = _currentTask.Title;
                Description = _currentTask.Description;
                IsCompleted = _currentTask.IsCompleted;
                SelectedUser = UserNames.First(user => user.Id == _currentTask.ResponsibleUserId);
            }
            else
            {
                State = PageState.AddNew;
            }
        }

        public async Task OnGoBack()
        {
            await _navigationService.GoBackAsync();
        }
        public async Task OnSave()
        {
            if(State == PageState.AddNew)
            {
                _currentTask = new Todo(Title, Description, IsCompleted, SelectedUser.Id, DateTime.Now);
                _toDoService.SaveNewTask(_currentTask);
            }
            else if (State == PageState.Edit && _currentTask != null)
            {
                _currentTask.Title = Title;
                _currentTask.Description = Description;
                _currentTask.IsCompleted = IsCompleted;
                _currentTask.ResponsibleUserId = SelectedUser.Id;
                _toDoService.UpdateTask(_currentTask);
            }
            await _navigationService.GoBackAsync();
        }
    }
}
