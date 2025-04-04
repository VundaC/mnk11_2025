namespace Practice.Views
{
    public partial class MePage : ContentPage
    {
        private readonly MePageViewModel _viewModel;
        public MePage(MePageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadPreferences(); // Refresh data when page appears
        }
    }
}
