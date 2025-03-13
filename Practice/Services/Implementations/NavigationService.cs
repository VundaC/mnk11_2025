using Practice.Interfaces;

namespace Practice.Services.Implementations;

public class NavigationService : INavigationService
{
    public async Task NavigateAsync(string route, CancellationToken cancellationToken = default)
    {
        await Shell.Current.GoToAsync(route, true);
    }
}