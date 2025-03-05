using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Views.Me
{
    class MePageViewModel : BaseViewModel
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
                //OnPropertyChanged(nameof(FullName));
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
