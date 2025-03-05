namespace Practice.Views.Me
{
    public partial class MePage : ContentPage
    {
        public MePage()
        {
            InitializeComponent();
            BindingContext = new MePageViewModel();
            Image image = new Image
            {
                Source = ImageSource.FromFile("dotnet_bot.png")

            };
            using var memoryStream = new MemoryStream();
            //image.Source.CopyTo(memoryStream);

            base64EncodedImage.Text = Convert.ToBase64String(memoryStream.ToArray());

            var imageBytes = Convert.FromBase64String(base64EncodedImage.Text);

        }
    }
}
