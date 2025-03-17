using System.Windows.Input;
using Practice.Interfaces;

namespace Practice.ViewModels;

public class SettingsPageViewModel
{
    private const string ThemePreferenceKey = "AppTheme";

    public ICommand AboutCommand { get; }
    public ICommand ToggleThemeCommand { get; }
    private readonly IDialogService _dialogService;
    private readonly IPreference _preferenceService;
    public string Version { get; }
    
    private bool _isDarkTheme;
    public bool IsDarkTheme
    {
        get => _isDarkTheme;
        set
        {
            if (_isDarkTheme != value)
            {
                _isDarkTheme = value;
                _preferenceService.Save(ThemePreferenceKey, value);
                OnThemeChanged();
            }
        }
    }

    public SettingsPageViewModel(IDialogService dialogService, IPlatformService platformService, IPreference preferenceService)
    {
        _dialogService = dialogService;
        _preferenceService = preferenceService;
        Version = $"Version: {platformService.AppVersion}";

        _isDarkTheme = _preferenceService.Get(ThemePreferenceKey, false);

        AboutCommand = new Command(async () =>
        {
            await _dialogService.ShowAlertAsync("About", $"This is a practice app! {Version}");
        });

        ToggleThemeCommand = new Command(() =>
        {
            IsDarkTheme = !IsDarkTheme;
        });
    }

    private void OnThemeChanged()
    {
        Application.Current.UserAppTheme = _isDarkTheme ? AppTheme.Dark : AppTheme.Light;
    }
}
