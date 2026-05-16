using LiteDB;
using Microsoft.Extensions.Logging;
using ToDoListBL.Interfaces;
using ToDoListDL.Connections;
using ToDoListDL.Repositories;

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
                ;

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static void RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<LiteDBConnection>();
            builder.Services.AddTransient<IToDoRepository, LiteDBToDoRepository>();
        }
    }
}
