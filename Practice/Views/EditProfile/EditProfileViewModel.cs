using CommunityToolkit.Mvvm.Input;
using Practice.Interfaces;
using System.Windows.Input;

namespace Practice.Views
{
    public class EditProfileViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private readonly IPreference _preferencesService;
        public ICommand SaveCommand { get; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName =  value;
                //_preferencesService.Save("FirstName", value);
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
               // _preferencesService.Save("FirstName", value);
                OnPropertyChanged();
            }
        }
        public EditProfileViewModel(IPreference preferencesService)
        {
            _preferencesService = preferencesService;

            _firstName = _preferencesService.Get("FirstName", "Bogdan");
            _lastName = _preferencesService.Get("LastName", "Ivanov");

            SaveCommand = new RelayCommand(SavePreferences);
        }

        private void SavePreferences()
        {
            _preferencesService.Save("FirstName", _firstName);
            _preferencesService.Save("LastName", _lastName);
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
        }
       
    }
}
