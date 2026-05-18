using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoListBL.Services;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.UserList
{
    public class UserListViewModel
    {
        ToDoService _toDoService;
        NavigationService _navigation;

        public ObservableCollection<UserViewModel> Users { get; init; }
        public UserListViewModel(ToDoService toDoService, NavigationService navigationService) 
        {
            _toDoService = toDoService;
            _navigation = navigationService;
            var userList = _toDoService.GetUsers();
            Users = new ObservableCollection<UserViewModel>(userList.Select(user => new UserViewModel(user)));
        }
    }
}
