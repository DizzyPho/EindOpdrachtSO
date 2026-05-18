using System;
using System.Collections.Generic;
using System.Text;
using ToDoListGUI.Pages;

namespace ToDoListGUI.Routes
{
    public static class Routes
    {
        public const string TaskDetailRoute = "TaskDetailPage";
        public const string TaskListRoute= "TaskListPage";
        public const string UserDetailRoute = "UserDetailPage";
        public const string UserListRoute = "UserListPage";

        public static Type TaskDetailType = typeof(TaskDetailPage);
        public static Type TaskListType = typeof(TaskListPage);
        public static Type UserDetailType = typeof(UserDetailPage);
        public static Type UserListType = typeof(UserDetailPage);
    }
}
