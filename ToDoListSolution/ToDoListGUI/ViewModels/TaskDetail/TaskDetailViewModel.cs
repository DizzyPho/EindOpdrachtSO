using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;
using ToDoListBL.Services;
using ToDoListGUI.PageStates;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.TaskDetail
{
    public class TaskDetailViewModel : BaseViewModel, IQueryAttributable
    {
        ToDoService _toDoService;
        NavigationService _navigationService;
        MessageService _messageService;
        Todo _currentTask;
        public PageState State { get; private set; }

        public TaskDetailViewModel(ToDoService toDoService, NavigationService navigationService, MessageService messageService)
        {
            _toDoService = toDoService;
            _navigationService = navigationService;
            _messageService = messageService;

            var users = _toDoService.GetUsers();
            UserNames = new List<UserNameViewModel>(users.Select(user => new UserNameViewModel(user)));
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

            }
            else
            {
                State = PageState.AddNew;
            }
        }


    }
}
