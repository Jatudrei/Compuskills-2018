using System;

public class Program
{
    public void Main()
    {
        Rectangle rectangle = GetShape();
        rectangle.Width = 10;
        rectangle.Height = 20;

        Console.WriteLine(rectangle.GetArea());
    }

    private Rectangle GetShape()
    {
        return new Square();
    }
}

public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public int GetArea()
    {
        return Width * Height;
    }
}

public class Square : Rectangle
{
    private int _Width;
    public override int Width
    {
        get
        {
            return _Width;
        }
        set
        {
            _Width = _Height = value;
        }
    }

    private int _Height;
    public override int Height
    {
        get
        {
            return _Height;
        }
        set
        {
            _Width = _Height = value;
        }
    }
}
