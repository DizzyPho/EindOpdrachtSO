using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListGUI.Services
{
    public class NavigationService
    {
        public async Task GoToAsync(string route, Dictionary<string, object>? parameters = null)
        {
            if (parameters == null)
            {
                await Shell.Current.GoToAsync(route);
            }
            else
            {
                await Shell.Current.GoToAsync(route, parameters);
            }
        }
        public async Task GoBack(Dictionary<string, object>? parameters = null)
        {
            await GoToAsync("..", parameters);
        }
    }
}
