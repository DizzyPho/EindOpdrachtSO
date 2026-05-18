using System;
using System.Collections.Generic;
using System.Text;
using ToDoListGUI.Pages;

namespace ToDoListGUI.Routes
{
    public static class RouteDefinitions
    {
        public static string TaskDetailRoute = nameof(TaskDetailPage);
        public static string TaskListRoute= nameof(TaskListPage);
        public static string UserDetailRoute = nameof(UserDetailPage);
        public static string UserListRoute = nameof(UserListPage);

        public static Type TaskDetailType = typeof(TaskDetailPage);
        public static Type TaskListType = typeof(TaskListPage);
        public static Type UserDetailType = typeof(UserDetailPage);
        public static Type UserListType = typeof(UserDetailPage);
    }
}
