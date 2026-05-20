using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListBL.Messages
{
    public class NewUserMessage
    {
        public NewUserMessage(User newUser)
        {
            NewUser = newUser;
        }

        public User NewUser { get; init; }
    }
}
