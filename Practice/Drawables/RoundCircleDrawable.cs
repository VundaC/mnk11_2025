using IImage = Microsoft.Maui.Graphics.IImage;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Controls;
using System.Net.Http;

namespace Practice.Drawables;

internal class RoundCircleDrawable : GraphicsView, IDrawable
{
    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(RoundCircleDrawable), default(ImageSource), propertyChanged: OnImageSourceChanged);

    public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(RoundCircleDrawable), 5f);

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(RoundCircleDrawable), Colors.Black);

    private IImage _image;

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public float BorderWidth
    {
        get => (float)GetValue(BorderWidthProperty);
        set => SetValue(BorderWidthProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public RoundCircleDrawable()
    {
        Drawable = this;
    }

    private static async void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is RoundCircleDrawable control && newValue is ImageSource source)
        {
            control._image = await LoadImageAsync(source);
            control.Invalidate(); // Force redraw
        }
    }

    private static async Task<IImage> LoadImageAsync(ImageSource imageSource)
    {
        try
        {
            if (imageSource is FileImageSource file)
            {
                string path = file.File;
                if (File.Exists(path))
                {
                    using var stream = File.OpenRead(path);
                    return PlatformImage.FromStream(stream);
                }
            }
            else if (imageSource is UriImageSource uriSource)
            {
                using HttpClient client = new();
                using var stream = await client.GetStreamAsync(uriSource.Uri);
                return PlatformImage.FromStream(stream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading image: {ex.Message}");
        }

        return null;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (_image == null)
            return;

        float padding = BorderWidth / 2f;
        float size = Math.Min(dirtyRect.Width, dirtyRect.Height) - BorderWidth;
        float radius = size / 2;
        float centerX = dirtyRect.Center.X;
        float centerY = dirtyRect.Center.Y;

        float left = centerX - radius;
        float top = centerY - radius;

        canvas.SaveState();

        var clipPath = new PathF();
        clipPath.AppendEllipse(left, top, size, size);
        canvas.ClipPath(clipPath);

        canvas.DrawImage(_image, left, top, size, size);

        canvas.RestoreState();

        if (BorderWidth > 0)
        {
            canvas.StrokeColor = BorderColor;
            canvas.StrokeSize = BorderWidth;
            canvas.DrawEllipse(left, top, size, size);
        }
    }

}
