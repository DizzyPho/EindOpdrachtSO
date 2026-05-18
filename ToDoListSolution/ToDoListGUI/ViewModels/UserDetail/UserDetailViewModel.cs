using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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
            GoBackCommand = new Command(OnGoBack);
        }
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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("id", out object oId) && oId is string id)
            {
                DeleteEnabled = true;
            }
            else
            {
                DeleteEnabled = false;
            }
        }

        public void OnGoBack()
        {
            _navigation.GoBackAsync();
        }
    }
}
