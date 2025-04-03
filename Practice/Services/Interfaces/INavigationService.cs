namespace Practice.Interfaces;

public interface INavigationService
{
    Task NavigateAsync(string route, Dictionary<string, object> parameters = null, CancellationToken cancellationToken = default);
}