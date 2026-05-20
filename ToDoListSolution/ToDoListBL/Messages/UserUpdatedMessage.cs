using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListBL.Messages
{
    public class UserUpdatedMessage
    {
        public UserUpdatedMessage(User user)
        {
            User = user;
        }

        public User User { get; init; }
    }
}
