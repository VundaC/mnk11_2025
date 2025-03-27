namespace Practice.Views.Controls;

public partial class RoundCircleImage : ContentView
{
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
        nameof(ImageSource), typeof(ImageSource), typeof(RoundCircleImage), null,
        propertyChanged: OnImageSourceChanged);
    public RoundCircleImage()
	{
		InitializeComponent();
	}
    private static void onImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is RoundCircleImage control && newValue is ImageSource source)
        {
            RoundCircleImage.In
        }
    }
}