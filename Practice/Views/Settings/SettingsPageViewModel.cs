using System.Windows.Input;
using Practice.Interfaces;

namespace Practice.ViewModels;

public class SettingsPageViewModel
{
    public ICommand AboutCommand { get; }
    private readonly IDialogService _dialogService;
    public string Version { get; } 

    public SettingsPageViewModel(IDialogService dialogService, IPlatformService platformService)
    {
        _dialogService = dialogService;
        Version = $"Version: {platformService.AppVersion}";

        AboutCommand = new Command(async () =>
        {
            await _dialogService.ShowAlertAsync("About", $"This is a practice app! {Version}");
        });
    }
}
