using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListBL.Messages
{
    public class UserDeletedMessage
    {
        public UserDeletedMessage(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; init; }
    }
}
