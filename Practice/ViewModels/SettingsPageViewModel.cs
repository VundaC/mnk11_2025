using System.Windows.Input;
using Practice.Services.Interfaces;

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
            await _dialogService.ShowDialogAsync("About", "This is a practice app! Version 1.0");
        });
    }
}