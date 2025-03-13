using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp.ViewModels.Main
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string randomNumber;

        public ICommand RandomCommand { get; }

        public MainPageViewModel()
        {
            RandomCommand = new RelayCommand(GenerateRandomNumber);
        }
        private void GenerateRandomNumber()
        {
            Random random = new Random();
            RandomNumber = random.Next(1, 1000).ToString();
        }
    }
}
