using HW2.View;
using HW2.ViewModel;
using Microsoft.Extensions.Logging;

namespace HW2
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
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<Main>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<CreateDepartment>();
            builder.Services.AddTransient<CreateDepartmentViewModel>();
            return builder.Build();
        }
    }
}