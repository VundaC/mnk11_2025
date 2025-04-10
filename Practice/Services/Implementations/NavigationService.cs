using Practice.Interfaces;

namespace Practice.Services.Implementations;

public class NavigationService : INavigationService
{
    public async Task NavigateAsync(string route, Dictionary<string, object> parameters = null, CancellationToken cancellationToken = default)
    {
        if(parameters == null)
            await Shell.Current.GoToAsync(route, animate: true);
        else
            await Shell.Current.GoToAsync(route, animate: true, parameters: parameters);
    }        

}