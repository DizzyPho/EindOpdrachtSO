using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListGUI.Commands
{
    public partial class AsyncCommand : Command
    {
        public AsyncCommand(Func<Task> action) : base(async () => await action())
        {
            
        }
    }
}
