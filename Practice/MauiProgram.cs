using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
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
            .AddSingleton<EditProfilePage>()
            .AddSingleton<EditProfilePageViewModel>()
            .AddTransient<SettingsPage>()
            .AddTransient<SettingsPageViewModel>();

        builder.Logging
            .ClearProviders()
            .AddNLog();
        NLog.LogManager.Setup().RegisterMauiLog()
    .LoadConfigurationFromAssemblyResource(typeof(App).Assembly);

        return builder.Build();
    }
}
