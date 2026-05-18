using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Services;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.UserList
{
    public class UserListViewModel
    {
        ToDoService _toDoService;
        NavigationService _navigation;
        public UserListViewModel(ToDoService toDoService, NavigationService navigationService) 
        {
            _toDoService = toDoService;
            _navigation = navigationService;
        }
    }
}
