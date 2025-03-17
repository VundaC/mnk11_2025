using Practice.Interfaces;

namespace Practice.Views
{
    public partial class MePageViewModel : BaseViewModel
    {
        private string _firstName = "Bogdan";
        private string _lastName = "Nazarchuk";
        private readonly IPreference _preferencesService;
        public string FirstName
        {
            get =>  _firstName;
            set
            {
                _firstName = value;
                _preferencesService.Get("FirstName", value);
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                _preferencesService.Get("FirstName", value);
                OnPropertyChanged();
            }
        }

    }
}
