using Microsoft.Extensions.Logging;
using MauiApp.Services;
using MauiApp.ViewModels;
using MauiApp.Views;
using MauiApp.Views.Main;

namespace MauiApp;

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

        builder.Services.AddServices();

        builder.Services
            .AddSingleton<MePageViewModel>()
            .AddSingleton<MePage>()
            .AddTransient<SettingsPage>()
            .AddTransient<SettingsPageViewModel>()
            .AddSingleton<MainPageViewModel>()
            .AddSingleton<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
