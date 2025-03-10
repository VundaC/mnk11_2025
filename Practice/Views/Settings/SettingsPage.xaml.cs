using Microsoft.Maui.Controls;
using Practice.Services.Interfaces;
using Practice.ViewModels;

namespace Practice.Views.Settings;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(IDialogService dialogService)
    {
        InitializeComponent();
        BindingContext = new SettingsPageViewModel(dialogService);
    }
}