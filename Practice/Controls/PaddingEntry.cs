using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Practice.Controls;

public class PaddingEntry : Entry
{
    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler is not null)
            UpdatePadding();
    }

    private void UpdatePadding()
    {
        var platformView = (Handler as EntryHandler)?.PlatformView;
        if (platformView == null) return;
        int paddingLeftDp = 32;
#if ANDROID
        platformView.SetPadding(paddingLeftDp, 0, 0, 0);
#elif IOS || MACCATALYST
        (platformView).LeftView = new UIKit.UIView(new CoreGraphics.CGRect(0, 0, paddingLeftDp, 0));
        (platformView).LeftViewMode = UIKit.UITextFieldViewMode.Always;
#elif WINDOWS
                platformView.Padding = new Microsoft.UI.Xaml.Thickness(paddingLeftDp, 0, 0, 0);
#endif
    }
}