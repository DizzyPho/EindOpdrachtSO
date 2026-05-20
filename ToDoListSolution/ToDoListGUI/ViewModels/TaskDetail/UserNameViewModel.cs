using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListGUI.ViewModels.TaskDetail
{
    public class UserNameViewModel : BaseViewModel
    {
        public UserNameViewModel(User user)
        {
            Id = user.Id;
            UserName = user.FirstName + " " + user.LastName;
        }   

        public string Id { get; init; }
        public string UserName { get; init; }
    }
}
