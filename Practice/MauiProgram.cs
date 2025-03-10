using Microsoft.Extensions.DependencyInjection;
using Practice.Services;
using Practice.Views.Settings; // Додано для SettingsPage

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

        builder.Services.AddPracticeServices();
        builder.Services.AddTransient<SettingsPage>(); 

        return builder.Build();
    }
}