using Practice.Interfaces;
using Practice.Services.Implementations;

namespace Practice.Services;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<INavigationService, NavigationService>()
            .AddSingleton<IDialogService, DialogService>();
    }
}