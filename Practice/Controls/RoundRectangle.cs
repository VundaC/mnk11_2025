using System.Runtime.CompilerServices;

namespace Practice.Controls;

public class RoundRectangle: GraphicsView, IDrawable
{
    #region variables

    internal static readonly BindableProperty ColorProperty = BindableProperty.Create(
        propertyName: nameof(Color),
        returnType: typeof(Color),
        declaringType: typeof(RoundRectangle),
        defaultValue: Colors.Black,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnRectanlgePropertyChanged);

    internal static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
        propertyName: nameof(BorderWidth),
        returnType: typeof(double),
        declaringType: typeof(RoundRectangle),
        defaultValue: 1.0,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnRectanlgePropertyChanged);

    internal static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
        propertyName: nameof(CornerRadius),
        returnType: typeof(double),
        declaringType: typeof(RoundRectangle),
        defaultValue: 0.0,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnRectanlgePropertyChanged);
      
    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }
    
    public double BorderWidth
    {
        get => (double)GetValue(BorderWidthProperty);
        set => SetValue(BorderWidthProperty, value);
    }
    
    public double CornerRadius
    {
        get => (double)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    
    #endregion

    public RoundRectangle()
    {
        Drawable = this;
    }
    
    #region methods
    
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Color;
        canvas.StrokeSize = (int)BorderWidth;
        canvas.StrokeLineJoin = LineJoin.Round;
        var path = new PathF();
        var r = (float)CornerRadius;
        var p = (float)BorderWidth / 2;
        var x0 = p;
        var y0 = p;
        var width = dirtyRect.Width - 2 * p;
        var height = dirtyRect.Height - 2 * p;
        r = Math.Min(r, Math.Min(width, height) / 2);
        canvas.StrokeColor = Color;
        canvas.StrokeSize = (float)(BorderWidth / DeviceDisplay.Current.MainDisplayInfo.Density);
        path.MoveTo(x0 + r, y0);
        path.LineTo(width - r, y0);
        path.AddArc(width - 2 * r, y0, width, y0 + 2 * r, 90, 0, true);
        path.LineTo(width, height - r);
        path.AddArc(width- 2 * r, height - 2 * r, width, height, 0, 270, true);
        path.LineTo(x0 + r, height);
        path.AddArc(x0, height- 2 * r, x0 + 2 * r, height, 270, 180, true);
        path.LineTo(x0, y0 + r);
        path.AddArc(x0, y0, x0 + 2 * r, y0 + 2 * r, 180, 90, true);
        path.Close();
        canvas.DrawPath(path);
    }
    
    #endregion
    #region handlers
    
    private static void OnRectanlgePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is RoundRectangle roundRectangle)
            roundRectangle.Invalidate();
    }

    #endregion
}