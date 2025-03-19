using CommunityToolkit.Mvvm.Input;
using Practice.Interfaces;
using System.Windows.Input;

namespace Practice.Views
{
    public class EditProfilePageViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private readonly IPreference _preferencesService;
        private readonly IDialogService _dialogService;
        public ICommand SaveCommand { get; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                _preferencesService.Save("FirstName", value);
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                 _preferencesService.Save("LastName", value);
                OnPropertyChanged();
            }
        }
        public EditProfilePageViewModel(IPreference preferencesService, IDialogService dialogService)
        {
            _preferencesService = preferencesService;
            _dialogService = dialogService;

            _firstName = _preferencesService.Get("FirstName", "Bogdan");
            _lastName = _preferencesService.Get("LastName", "Ivanov");

            SaveCommand = new RelayCommand(SavePreferences);
        }

        private async void SavePreferences()
        {
            _preferencesService.Save("FirstName", _firstName);
            _preferencesService.Save("LastName", _lastName);
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            await _dialogService.ShowAlertAsync("Success!", "Name successfully saved!");
        }

    }
}