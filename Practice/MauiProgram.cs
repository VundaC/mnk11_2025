using Microsoft.Extensions.Logging;
using Practice.Services;
using Practice.ViewModels;
using Practice.Views;
using CommunityToolkit.Maui;


namespace Practice;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddServices();

        builder.Services
            .AddSingleton<MePageViewModel>()
            .AddSingleton<MePage>()
            .AddTransientWithShellRoute<EditProfilePage, EditProfilePageViewModel>("editprofile")
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
