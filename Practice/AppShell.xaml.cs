using Practice.Views;

namespace Practice
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("editprofile", typeof(EditProfilePage));
        }
    }
}
