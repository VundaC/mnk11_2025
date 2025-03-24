namespace Practice.Views
{
    public partial class MePage : ContentPage
    {
        private readonly MePageViewModel _viewModel;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public MePage(MePageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
            try
            {
                Logger.Info("Page loaded");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Goodbye cruel world");
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadPreferences(); // Refresh data when page appears
        }
    }
}
