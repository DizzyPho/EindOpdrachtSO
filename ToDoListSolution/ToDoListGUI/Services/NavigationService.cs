using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;
using ToDoListGUI.Pages;

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
            // pass param like newly added user???
            if (parameters == null)
            {
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.GoToAsync("..", parameters);
            }
        }
        public async Task NewUserPageAsync()
        {
            await GoToAsync<UserDetailPage>();
        }

        public async Task EditUserPage(string userId)
        {
            Dictionary<string, object>? parameters = new Dictionary<string, object>{ ["id"] = userId };
            await GoToAsync<UserDetailPage>(parameters);
        }

        public async Task EditTaskPage(string taskId)
        {
            Dictionary<string, object>? parameters = new Dictionary<string, object> { ["id"] = taskId };
            await GoToAsync<TaskDetailPage>(parameters);
        }
    }
}
