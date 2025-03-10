using Practice.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.Services.Implementation;

public class DialogService : IDialogService
{
    public async Task ShowDialogAsync(string title, string message, CancellationToken cancellationToken = default)
    {
        await Shell.Current.DisplayAlert(title, message, "OK");
    }
}