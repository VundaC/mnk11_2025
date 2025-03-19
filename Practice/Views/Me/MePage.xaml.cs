namespace Practice.Views
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
