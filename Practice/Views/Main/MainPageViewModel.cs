using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Practice.Views;

namespace Practice.Views
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private string _randomNumber;
        public string RandomNumber
        {
            get => _randomNumber;
            set => SetProperty(ref _randomNumber, value);
        }

        public ICommand RandomCommand { get; }

        public MainPageViewModel()
        {
            RandomCommand = new RelayCommand(GenerateRandomNumber);
        }

        private void GenerateRandomNumber()
        {
            Random random = new Random();
            RandomNumber = random.Next(1, 100).ToString();
        }
    }
}
