using System;

public class G
{
	public static int OffsetSplit(Point pointX, Point pointY)
    {
        var a = Math.Pow(pointX.X + pointY.X, 2);
        var b = Math.Pow(pointX.Y + pointY.Y, 2);

        return Math.Sqrt(a + b);
    }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}