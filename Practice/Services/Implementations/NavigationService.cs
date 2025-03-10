using Practice.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.Services.Implementations;

public class NavigationService : INavigationService
{
    public async Task NavigateAsync(string route, CancellationToken cancellationToken = default)
    {
        await Shell.Current.GoToAsync(route, true);
    }
}