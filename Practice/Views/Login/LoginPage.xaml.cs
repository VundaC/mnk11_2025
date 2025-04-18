using Microsoft.Maui.Handlers;

namespace Practice.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginPageViewModel viewModel)
        {
            InitializeComponent();
            SetLeftPadding();
            BindingContext = viewModel;
        }
        public static void SetLeftPadding(int paddingLeftDp = 32)
        {
            EntryHandler.Mapper.AppendToMapping("LeftPadding", (handler, view) =>
            {
#if ANDROID
        handler.PlatformView.SetPadding(paddingLeftDp, 0, 0, 0);
#elif IOS || MACCATALYST
        handler.PlatformView.LeftView = new UIKit.UIView(new CoreGraphics.CGRect(0, 0, paddingLeftDp, 0));
        handler.PlatformView.LeftViewMode = UIKit.UITextFieldViewMode.Always;
#elif WINDOWS
                handler.PlatformView.Padding = new Microsoft.UI.Xaml.Thickness(paddingLeftDp, 0, 0, 0);
#endif
            });
        }


    }
}