using CommunityToolkit.Mvvm.Input;
using Practice.Interfaces;
using System.Windows.Input;
using Practice.Services.Implementations;

namespace Practice.Views
{
    public class EditProfilePageViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private readonly IPreference _preferencesService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private EditProfileNavigationModel _navigationModel;
        public ICommand SaveCommand { get; }
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
        public EditProfilePageViewModel(
            INavigationService navigationService,
            IPreference preferencesService, IDialogService dialogService)
        {
            _preferencesService = preferencesService;
            _dialogService = dialogService;
            _navigationService = navigationService;

            _firstName = _preferencesService.Get("FirstName", "Bogdan");
            _lastName = _preferencesService.Get("LastName", "Ivanov");

            SaveCommand = new RelayCommand(SavePreferences);
        }

        public override void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue(nameof(EditProfileNavigationModel), out var value))
                _navigationModel = (EditProfileNavigationModel)value;
        }

        private async void SavePreferences()
        {    
            _preferencesService.Save("FirstName", _firstName);
            _preferencesService.Save("LastName", _lastName);
            _navigationModel?.DataWasUpdated?.Invoke();
            await _navigationService.NavigateAsync("..");
            await _dialogService.ShowAlertAsync("Success", "Preferences saved");
        }

    }
}