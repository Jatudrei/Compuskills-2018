using System;

public class Program
{
	public void Main()
	{
        IDateProvider provider;

        Console.WriteLine("Testing mode: ");
        var mode = Console.ReadLine();
        if (mode == "y")
        {
            provider = new InjectedDateProvider(new DateTime(2018, 1, 1));
        }
        else
        {
            provider = new SystemClockDateProvider();
        }


        if (provider.GetDate().Date == 10)
        {
            Console.WriteLine($"Today ({provider.GetDate()}) is the 10th of the month.");
        }
	}
}

public interface IDateProvider
{
    DateTime GetDate();
}

public class SystemClockDateProvider : IDateProvider
{
    public DateTime GetDate()
    {
        return DateTime.Now;
    }
}

public class InjectedDateProvider : IDateProvider
{
    private DateTime InjectedDate { get; set; }

    public InjectedDateProvider(DateTime injectedDate)
    {
        InjectedDate = injectedDate;
    }

    public DateTime GetDate()
    {
        return InjectedDate;
    }
}