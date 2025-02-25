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
            await DisplayAlert("Clicked", "The button labeled '" + button.Text + button.FontFamily + "' has been clicked", "OK");
        }
    }
}