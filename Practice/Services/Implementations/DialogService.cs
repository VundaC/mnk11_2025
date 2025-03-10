using Practice.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.Services.Implementations;

public class DialogService : IDialogService
{
    public async Task ShowAlertAsync(string title, string message, CancellationToken cancellationToken = default)
    {
        await Shell.Current.DisplayAlert(title, message, "OK");
    }
}