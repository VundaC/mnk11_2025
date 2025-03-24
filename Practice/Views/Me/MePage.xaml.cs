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
    }
}
