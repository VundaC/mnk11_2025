using Practice.Interfaces;
using Practice.Services.Implementations;

namespace Practice.Services;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<IPlatformService, PlatformService>();
        return services;
    }
}