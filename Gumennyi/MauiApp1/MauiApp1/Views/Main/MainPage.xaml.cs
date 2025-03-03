using Microsoft.Maui.Controls;
using YourNamespace.ViewModels;

namespace YourNamespace.Views.Main
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent(); // Цей рядок працюватиме, якщо XAML коректний
            BindingContext = viewModel;
        }
    }
}
