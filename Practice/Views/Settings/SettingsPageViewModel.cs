using System.Windows.Input;
using Practice.Interfaces;

namespace Practice.ViewModels;

public class SettingsPageViewModel
{
    public ICommand AboutCommand { get; }
    private readonly IDialogService _dialogService;

    public SettingsPageViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
        AboutCommand = new Command(async () =>
        {
            await _dialogService.ShowAlertAsync("About", "This is a practice app! Version 1.0");
        });
    }
}