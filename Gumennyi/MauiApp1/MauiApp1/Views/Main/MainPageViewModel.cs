using System;
using System.Windows.Input;
using YourNamespace.ViewModels;
using Microsoft.Maui.Controls;

namespace YourNamespace.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private string _randomNumber;
        public string RandomNumber
        {
            get => _randomNumber;
            set
            {
                _randomNumber = value;
                OnPropertyChanged();
            }
        }

        public ICommand RandomCommand { get; }

        public MainPageViewModel()
        {
            RandomCommand = new Command(GenerateRandomNumber);
        }

        private void GenerateRandomNumber()
        {
            Random random = new Random();
            RandomNumber = $"Число: {random.Next(1, 100)}";
        }
    }
}
