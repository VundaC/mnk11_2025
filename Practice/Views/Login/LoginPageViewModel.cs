using CommunityToolkit.Mvvm.Input;
using Practice.Interfaces;
using System.Windows.Input;

namespace Practice.Views
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
        private readonly INavigationService _navigationService;

        public LoginPageViewModel(INavigationService navigationService, IPreference preferenceService)
        {
            _navigationService = navigationService;
            LoginCommand = new AsyncRelayCommand(Login);
        }
         
        private async Task Login()
        {
            // Simulate a login process
            await Task.Delay(1000);
            // Navigate to the main page after login
            await _navigationService.NavigateAsync("mainpage");
        }
    }
}
