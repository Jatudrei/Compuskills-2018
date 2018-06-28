using System;

public class G
{
	public static int Dist(int a, int b, int c, int d)
    {
        // distance formula: sqrt((x1+x2)^2 + (y1+y2)^2)
        return Math.Sqrt(Math.Pow((a + c), 2) + Math.Pow(b + d));
    }
}
