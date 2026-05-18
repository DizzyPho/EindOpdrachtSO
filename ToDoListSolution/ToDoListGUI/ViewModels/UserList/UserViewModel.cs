using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListGUI.ViewModels.UserList
{
    public class UserViewModel : BaseViewModel
    {
        public UserViewModel(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            // possible to make age int and format 
            var diff = (DateTime.Now - user.BirthDate);
            Age = user.GetAge();
        }
        public string Id { get; init; }
        public string FirstName
        {
            get => Get<string>();
            set => Set(value);
        }

        public string LastName
        {
            get => Get<string>();
            set => Set(value);
        }

        public int Age
        {
            get => Get<int>();
            set => Set(value);
        }
    }
}
