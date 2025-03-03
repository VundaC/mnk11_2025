using Microsoft.Maui.Controls;
using YourNamespace.Views.Main;

namespace YourNamespace
{
    public partial class App : Application
    {
        public App(MainPage mainPage)
        {
           
            MainPage = new NavigationPage(mainPage);
        }
    }
}
