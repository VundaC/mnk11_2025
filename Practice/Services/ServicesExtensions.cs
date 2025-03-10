using Microsoft.Extensions.DependencyInjection;
using Practice.Services.Implementation;
using Practice.Services.Interfaces;

namespace Practice.Services;

public static class ServicesExtensions
{
    public static IServiceCollection AddPracticeServices(this IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IDialogService, DialogService>();
        return services;
    }
}