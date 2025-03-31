using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;

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
        if (bindable is RoundCircleDrawable control && newValue is ImageSource imageSource)
        {
            control.Invalidate(); // Redraw the control
        }
    }





    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (_image == null)
            return;

        float size = Math.Min(dirtyRect.Width, dirtyRect.Height);
        float radius = size / 2;
        float centerX = dirtyRect.Center.X;
        float centerY = dirtyRect.Center.Y;

        // Save state before clipping
        canvas.SaveState();

        // Create a circular clipping path
        PathF clipPath = new PathF();
        clipPath.AppendEllipse(centerX - radius, centerY - radius, size, size);
        canvas.ClipPath(clipPath);

        // Draw the image inside the clipped circle
        canvas.DrawImage(_image, centerX - radius, centerY - radius, size, size);

        // Restore state after clipping
        canvas.RestoreState();

        // Draw the border
        if (BorderWidth > 0)
        {
            canvas.StrokeColor = BorderColor;
            canvas.StrokeSize = BorderWidth;
            canvas.DrawEllipse(centerX - radius, centerY - radius, size, size);
        }
    }
}
