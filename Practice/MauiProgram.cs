using Microsoft.Extensions.Logging;
using Practice.Services;
using Practice.ViewModels;
using Practice.Views;

namespace Practice;

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
            .AddTransient<SettingsPageViewModel>();
            .AddSingleton<MainPageViewModel>();
            .AddSingleton<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
