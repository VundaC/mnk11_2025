using Practice.Interfaces;

namespace Practice.Services.Implementations;

public class DialogService : IDialogService
{
    public Task ShowAlertAsync(string title, string message, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}