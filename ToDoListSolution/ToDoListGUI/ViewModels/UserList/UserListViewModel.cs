using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ToDoListBL.Services;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.UserList
{
    public class UserListViewModel : BaseViewModel
    {
        ToDoService _toDoService;
        NavigationService _navigation;

        public ObservableCollection<UserViewModel> Users { get; init; }
        public UserViewModel SelectedUser
        {
            get => Get<UserViewModel>();
            set
            {
                Set(value);
                if(value != null)
                {
                    OnUserClicked(value);
                    SelectedUser = null;
                }
            }
        }
        public UserListViewModel(ToDoService toDoService, NavigationService navigationService) 
        {
            _toDoService = toDoService;
            _navigation = navigationService;
            var userList = _toDoService.GetUsers();
            Users = new ObservableCollection<UserViewModel>(userList.Select(user => new UserViewModel(user)));

            NewUserCommand = new Command(OnNewUser);
        }
        public ICommand NewUserCommand { get; init; }
        public void OnNewUser()
        {
            _navigation.NewUserPageAsync();
        }
        public void OnUserClicked(UserViewModel user)
        {
            _navigation.EditUserPage(user.Id);
        }
    }
}
