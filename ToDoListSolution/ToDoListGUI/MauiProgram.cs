using LiteDB;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using ToDoListBL.Interfaces;
using ToDoListBL.Services;
using ToDoListDL.Connections;
using ToDoListDL.Repositories;
using ToDoListGUI.Routes;

namespace ToDoListGUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterServices()
                .RegisterRoutes()
                ;

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<LiteDBConnection>();
            builder.Services.AddTransient<IToDoRepository, LiteDBToDoRepository>();
            builder.Services.AddTransient<ToDoService>();
            return builder;
        }

        public static MauiAppBuilder RegisterRoutes(this MauiAppBuilder builder)
        {
            Routing.RegisterRoute(RouteDefinitions.TaskListRoute, RouteDefinitions.TaskListType);
            Routing.RegisterRoute(RouteDefinitions.TaskDetailRoute, RouteDefinitions.TaskDetailType);
            Routing.RegisterRoute(RouteDefinitions.UserListRoute, RouteDefinitions.UserListType);
            Routing.RegisterRoute(RouteDefinitions.UserDetailRoute, RouteDefinitions.UserDetailType);
            return builder;
        }
    }
}
