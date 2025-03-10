namespace Practice.Views.Me
{
    public class MePageViewModel : BaseViewModel
    {
        private string _firstName = "Bogdan";
        private string _lastName = "Nazarchuk";

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

    }
}
