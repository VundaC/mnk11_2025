namespace Practice.Services.Interfaces;

public interface INavigationService
{
    Task NavigateAsync(string route, CancellationToken cancellationToken = default);
}