namespace Practice.Controls;

internal class RoundCircleRect : IDrawable
{

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        PathF path = new PathF();
    
        path.MoveTo(10, 0);            
        path.LineTo(190, 0);
        path.AddArc(190, 0, 200, 10, 90, 0, true);


        //path.LineTo();


        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 5;
        canvas.DrawPath(path);
    }
}


