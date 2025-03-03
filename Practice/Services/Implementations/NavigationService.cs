using Practice.Interfaces;

namespace Practice.Services.Implementations;

public class NavigationService : INavigationService
{
    public Task NavigateAsync(string route, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}