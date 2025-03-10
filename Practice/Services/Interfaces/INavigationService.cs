namespace Practice.Services;

public interface INavigationService
{
    Task NavigateAsync(string route, CancellationToken cancellationToken = default);
}