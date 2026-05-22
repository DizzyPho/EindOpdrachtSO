using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ToDoListBL.Domain;
using ToDoListBL.Messages;
using ToDoListBL.Services;
using ToDoListGUI.Commands;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.UserList
{
    public class UserListViewModel : BaseViewModel
    {
        ToDoService _toDoService;
        NavigationService _navigation;
        MessageService _messageService;

        public ObservableCollection<UserViewModel> Users { get; init; }
        public UserViewModel SelectedUser
        {
            get => Get<UserViewModel>();
            set
            {
                Set(value);
                if(value != null)
                {
                    OnUserClicked(value).ConfigureAwait(false);
                    SelectedUser = null;
                }
            }
        }
        public UserListViewModel(ToDoService toDoService, NavigationService navigationService, MessageService messageService) 
        {
            _toDoService = toDoService;
            _navigation = navigationService;
            _messageService = messageService;

            RegisterMessages();

            var userList = _toDoService.GetUsers();
            Users = new ObservableCollection<UserViewModel>(userList.Select(user => new UserViewModel(user)));

            NewUserCommand = new AsyncCommand(OnNewUser);
        }
        public ICommand NewUserCommand { get; init; }
        public async Task OnNewUser()
        {
            await _navigation.NewUserPageAsync();
        }
        public async Task OnUserClicked(UserViewModel user)
        {
            await _navigation.EditUserPage(user.Id);
        }

        public void RegisterMessages()
        {
            _messageService.Register<UserUpdatedMessage>(this, (sender, message) => OnUserUpdated(message.User));
            _messageService.Register<NewUserMessage>(this, (sender, message) => Users.Add(new UserViewModel(message.NewUser)));
            _messageService.Register<UserDeletedMessage>(this, (sender, message) => Users.Remove(Users.First(user => user.Id == message.UserId)));
        }

        public void OnUserUpdated(User user)
        {
            UserViewModel userVM = Users.First<UserViewModel>(viewmodel => viewmodel.Id == user.Id);

            if (userVM != null)
            {
                userVM.FirstName = user.FirstName;
                userVM.LastName = user.LastName;
                userVM.Age = user.GetAge();
            }

        }
    }
}
