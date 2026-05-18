using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListGUI.Services
{
    public class NavigationService
    {
        public async Task Navigate(string route, Dictionary<string, object>? parameters)
        {
            await Shell.Current.GoToAsync(route, parameters);
        }
        public async Task GoBack(Dictionary<string, object> parameters)
        {
            await Navigate("..", parameters);
        }
    }
}
