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
        var path = new PathF();
        var r = (float)CornerRadius;
        var width = dirtyRect.Width;
        var height = dirtyRect.Height;
        canvas.StrokeColor = Color;
        
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