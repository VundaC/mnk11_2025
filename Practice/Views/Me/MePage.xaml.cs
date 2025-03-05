namespace Practice.Views.Me
{
    public partial class MePage : ContentPage
    {
        public MePage()
        {
            InitializeComponent();
            BindingContext = new MePageViewModel(); 
        }
    }
}
