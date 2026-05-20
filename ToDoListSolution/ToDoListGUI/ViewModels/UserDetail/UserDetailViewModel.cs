using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ToDoListBL.Domain;
using ToDoListBL.Services;
using ToDoListGUI.Services;

namespace ToDoListGUI.ViewModels.UserDetail
{
    public class UserDetailViewModel : BaseViewModel, IQueryAttributable
    {
        NavigationService _navigation;
        ToDoService _toDoService;
        public UserDetailViewModel(ToDoService toDoService, NavigationService navigationService)
        {
            _toDoService = toDoService;
            _navigation = navigationService;
            GoBackCommand = new Command(async() => await OnGoBack());
            SaveCommand = new Command(async () => await OnSave());
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
        public bool DeleteEnabled { get; set; }
        public ICommand GoBackCommand { get; init; }
        public ICommand SaveCommand { get; init; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("id", out object oId) && oId is string id)
            {
                User user = _toDoService.GetUserById(id);
                FirstName = user.FirstName;
                LastName = user.LastName;
                DateOfBirth = user.BirthDate;
                ImageUrl = user.PictureURL;
                Id = user.Id;
                DeleteEnabled = true;
            }
            else
            {
                DeleteEnabled = false;
            }
        }

        public async Task OnGoBack()
        {
            await _navigation.GoBackAsync();
        }
        public async Task OnSave()
        {
            // make new object or store one on creation of page?
            User user = new User(FirstName, LastName, DateOfBirth, ImageUrl, Id);
            _toDoService.Upsert(user);
            await _navigation.GoBackAsync();
        }
    }
}
