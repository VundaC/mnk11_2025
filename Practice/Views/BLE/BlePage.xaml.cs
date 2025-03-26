namespace Practice.Views
{
    public partial class BlePage
    {
        public BlePage(BlePageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}