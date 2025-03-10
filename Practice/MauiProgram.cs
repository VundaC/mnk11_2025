using Microsoft.Extensions.DependencyInjection;
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
        builder.Services.AddTransient<SettingsPage>(); 
        builder.Services.AddTransient<SettingsPageViewModel>(); 
        

        return builder.Build();
    }
}