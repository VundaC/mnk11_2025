namespace Practice.Interfaces;

public interface IDialogService
{
    Task ShowAlertAsync(string title, string message, CancellationToken cancellationToken = default);
}