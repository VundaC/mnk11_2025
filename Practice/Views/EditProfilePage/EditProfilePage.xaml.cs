namespace Practice.Views;

public partial class EditProfilePage : ContentPage
{
    public EditProfilePage(EditProfilePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}