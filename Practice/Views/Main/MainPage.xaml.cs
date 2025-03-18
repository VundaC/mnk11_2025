using MauiApp.ViewModels.Main;

namespace MauiApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; 
    }
}
