using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Practice.Views;

namespace Practice.Views
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private 

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
