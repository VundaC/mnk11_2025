using System.Threading;
using System.Threading.Tasks;

namespace Practice.Services;

public interface IDialogService
{
    Task ShowAlertAsync(string title, string message, CancellationToken cancellationToken = default);
}