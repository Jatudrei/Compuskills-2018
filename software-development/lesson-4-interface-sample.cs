using System;

public interface ICalculator
{
    int CaluclateExponent(int @base, int power);
}

public class PositiveNumberCalculator : ICalculator
{
	public int CalculateExponent(int @base, int power)
    {
        int result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= @base;
        }

        return result;
    }
}

public class AnyNumberCalculator : ICalculator
{
    public int CalculateExponent(int @base, int power)
    {
        return Math.Pow(@base, power);
    }
}

public class Finances
{
    public void Main()
    {
        ICalculator calc = new PositiveNumberCalculator();
        var e = calc.CalculateExponent(5, -1);
    }
}
