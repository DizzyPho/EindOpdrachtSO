using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ToDoListBL.Domain;
using ToDoListBL.Services;
using ToDoListGUI.Commands;
using ToDoListGUI.PageStates;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.UserDetail
{
    public class UserDetailViewModel : BaseViewModel, IQueryAttributable
    {
        NavigationService _navigation;
        ToDoService _toDoService;
        User _currentUser;
        public PageState State { get; set; }
        public UserDetailViewModel(ToDoService toDoService, NavigationService navigationService)
        {
            _toDoService = toDoService;
            _navigation = navigationService;
            GoBackCommand = new AsyncCommand(OnGoBack);
            SaveCommand = new AsyncCommand(OnSave);
            DeleteCommand = new AsyncCommand(OnDeleteUser);
        }
        public string Id { get; private set; }
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
        public bool DeleteEnabled 
        { 
            get => Get<bool>();
            set => Set(value);
        }
        public ICommand GoBackCommand { get; init; }
        public ICommand DeleteCommand { get; init; }
        public ICommand SaveCommand { get; private set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("id", out object oId) && oId is string id)
            {
                _currentUser = _toDoService.GetUserById(id);
                FirstName = _currentUser.FirstName;
                LastName = _currentUser.LastName;
                DateOfBirth = _currentUser.BirthDate;
                ImageUrl = _currentUser.ImageURL;
                Id = _currentUser.Id;
                State = PageState.Edit;
                DeleteEnabled = true;
            }
            else
            {
                DeleteEnabled = false;
                State = PageState.AddNew;
            }
        }

        public async Task OnGoBack()
        {
            await _navigation.GoBackAsync();
        }
        public async Task OnSave()
        {
            if(State == PageState.Edit)
            {
                // make new object or store one on creation of page?
                _currentUser.FirstName = FirstName;
                _currentUser.LastName = LastName;
                _currentUser.BirthDate = DateOfBirth;
                _currentUser.ImageURL = ImageUrl;
                _toDoService.UpdateUser(_currentUser);
            }
            else if (State == PageState.AddNew)
            {
                _currentUser = new User(FirstName, LastName, DateOfBirth, ImageUrl, DateTime.Now);
                _toDoService.SaveNewUser(_currentUser);
            }


            await _navigation.GoBackAsync();
        }

        public async Task OnDeleteUser()
        {
            _toDoService.DeleteUser(Id);
            await _navigation.GoBackAsync();
        }

    }
}
