using Microsoft.Extensions.DependencyInjection;
using YourNamespace.Views.Main;
using YourNamespace.ViewModels;
using YourNamespace;

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
            });

        // Реєстрація залежностей
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
