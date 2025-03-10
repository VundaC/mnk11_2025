namespace Practice.Views.Me
{
    public partial class MePage : ContentPage
    {
        public MePage(MePageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }
    }
}
