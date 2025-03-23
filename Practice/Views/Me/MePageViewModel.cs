using CommunityToolkit.Mvvm.Input;
using Practice.Interfaces;
using System.Windows.Input;

namespace Practice.Views
{
    public class MePageViewModel : BaseViewModel
    {
        public ICommand EditProfileCommand { get; }
        private string _firstName;
        private string _lastName;
        private readonly INavigationService _navigationService;
        private readonly IPreference _preferencesService;
        public MePageViewModel(INavigationService navigationService, IPreference preferenceService)
        {
            _navigationService = navigationService;
            _preferencesService = preferenceService;
            
            EditProfileCommand = new AsyncRelayCommand(NavigateToEditProfile);
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        private async Task NavigateToEditProfile()
        {
            await _navigationService.NavigateAsync("editprofile");

        }
        public void LoadPreferences()
        {
            FirstName = _preferencesService.Get("FirstName", "Bogdan");
            LastName = _preferencesService.Get("LastName", "Ivanov");
        }

    }
}
