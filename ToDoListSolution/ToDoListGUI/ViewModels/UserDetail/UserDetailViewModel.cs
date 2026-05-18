using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Services;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.UserDetail
{
    public class UserDetailViewModel : BaseViewModel
    {
        NavigationService _navigation;
        ToDoService _toDoService;
        public string FirstName 
        {
            get => Get<String>(); 
            set => Set(value); 
        }
        public string LastName
        {
            get => Get<String>();
            set => Set(value);
        }
        public string ImageUrl
        {
            get => Get<String>();
            set => Set(value);
        }
        public DateTime DateOfBirth
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        public UserDetailViewModel(string id, ToDoService toDoService, NavigationService navigationService) 
            : this(toDoService, navigationService)
        {
        }

        public UserDetailViewModel(ToDoService toDoService, NavigationService navigationService)
        {
            _toDoService = toDoService;
            _navigation = navigationService;
        }
    }
}
