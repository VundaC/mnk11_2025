namespace Playground
{
    public partial class XamlPlusCodePage : ContentPage
    {
        public XamlPlusCodePage()
        {
            InitializeComponent();
        }
        
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double slidervalue = args.NewValue * 100;
            valueLabel.Text = slidervalue.ToString("F2") + '%';
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await image.RotateTo(360, 2000);
            image.Rotation = 0;
            await image.ScaleTo(2, 2000);
            await image.ScaleTo(1, 2000);
            image.Opacity = 0;
            await image.FadeTo(1, 4000);
            double radius = Math.Min(absoluteLayout.Width, absoluteLayout.Height);
            image.AnchorY = radius / image.Height;
            await image.RotateTo(360, 2000);
            await DisplayAlert("Clicked", "The button labeled '" + button.Text + button.FontFamily + "' has been clicked", "OK");
        }
    }
}