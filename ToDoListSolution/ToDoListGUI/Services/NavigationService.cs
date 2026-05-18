using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListGUI.Services
{
    public class NavigationService
    {
        private Shell _shell;

        public NavigationService()
        {
            _shell = Shell.Current;
        }

        public async Task Navigate(string route, Dictionary<string, object> parameters)
        {
            await _shell.GoToAsync(route, parameters);
        }
        public async Task GoBack(Dictionary<string, object> parameters)
        {
            await Navigate("..", parameters);
        }
    }
}
