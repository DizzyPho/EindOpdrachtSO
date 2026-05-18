using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListGUI.Services
{
    public class NavigationService
    {
        public async Task GoToAsync<T>(Dictionary<string, object>? parameters = null)
            where T : ContentPage
        {
            string name = typeof(T).Name;
            if (parameters == null)
            {
                await Shell.Current.GoToAsync(name);
            }
            else
            {
                await Shell.Current.GoToAsync(name, parameters);
            }
        }
        public async Task GoBackAsync(Dictionary<string, object>? parameters = null)
        {
            await Shell.Current.GoToAsync("..", parameters);
        }
    }
}
