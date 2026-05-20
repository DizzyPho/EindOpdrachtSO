using LiteDB;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using ToDoListBL.Interfaces;
using ToDoListBL.Services;
using ToDoListDL.Connections;
using ToDoListDL.Repositories;
using ToDoListGUI.Pages;
using ToDoListGUI.Routes;
using ToDoListGUI.Services;
using ToDoListGUI.ViewModels.UserDetail;

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
            builder.Services.AddTransient<NavigationService>();
            builder.Services.AddTransient<MessageService>();

            builder.Services.AddTransient<UserDetailViewModel>();
            return builder;
        }

        public static MauiAppBuilder RegisterRoutes(this MauiAppBuilder builder)
        {
            RegisterRoute<TaskDetailPage>();
            RegisterRoute<UserListPage>();
            RegisterRoute<UserDetailPage>();
            return builder;
        }
        public static void RegisterRoute<T>()
            where T : ContentPage
        {
            Type type = typeof(T);
            string name = type.Name;
            Routing.RegisterRoute(name, type);
        }
    }
}
