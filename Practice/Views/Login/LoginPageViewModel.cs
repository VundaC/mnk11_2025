using CommunityToolkit.Mvvm.Input;
using Practice.Interfaces;
using System.Windows.Input;

namespace Practice.Views
{
    public partial class LoginPageViewModel : BaseViewModel
    {
      
       
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly Dictionary<string, string> _users = new()
        {
            { "Class", "secret1" },
            { "Personal", "1password" }
        };

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public LoginPageViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        
            #if DEBUG
            Username = "Class";
            Password = "secret1";
            #endif
        }

        [RelayCommand]
        private async Task Login()
        {
            var window = Application.Current?.Windows.FirstOrDefault();
            if (!_users.TryGetValue(Username, out var validPassword) || Password != validPassword)
            {
                await window.Page.DisplayAlert("Error", "Invalid username or password", "OK");
                return;
            }

            await Task.Delay(1000); 

           
            if (window is not null)
            {
                window.Page = new AppShell();
            }

            await _navigationService.NavigateAsync("///MainPage");
        }
    }
}
