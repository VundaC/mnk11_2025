using System.Threading;
using System.Threading.Tasks;

namespace Practice.Services.Interfaces;

public interface IDialogService
{
    Task ShowDialogAsync(string title, string message, CancellationToken cancellationToken = default);
}