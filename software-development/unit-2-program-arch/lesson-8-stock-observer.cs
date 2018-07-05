using System.Collections.Generic;

public interface IObservable<T>
{
    void Observe(IObserver<T> observer);
}

public interface IObserver<T>
{
    void Update(T data);
}

public class StockExchange : IObservable<StockChangeData>
{
    private List<IObserver<StockChangeData>> Observers { get; set; } = new List<IObserver<StockChangeData>>();

    public void Observe(IObserver<StockChangeData> observer)
    {
        Observers.Add(observer);
    }

    private void Update(StockChangeData data)
    {
        foreach(var observer in Observers)
        {
            observer.Update(data);
        }
    }
}

public class StockChangeData
{
    public string TickerSymbol { get; set; }
    public decimal PreviousPrice { get; set; }
    public decimal CurrentPrice { get; set; }
}

public class HistoricalArchiveStockObserver: IObserver<StockChangeData>
{
    public void Update(StockChangeData data)
    {
        // log the data
    }
}

public class PriceDropStockObserver : IObserver<StockChangeData>
{
    public string TargetSymbol { get; set; }
    public decimal TargetDrop { get; set; }

    public PriceDropStockObserver(string targetSymbol, decimal targetDrop)
    {
        TargetSymbol = targetSymbol;
        TargetDrop = targetDrop;
    }

    public void Update(StockChangeData data)
    {
        if(data.TickerSymbol == TargetSymbol && (data.PreviousPrice - data.CurrentPrice) > TargetDrop)
        {
            // handle price drop
        }
    }
}

public class Program
{
    public void Main()
    {
        StockExchange exchange = new StockExchange();
        exchange.Observe(new HistoricalArchiveStockObserver());
        exchange.Observe(new PriceDropStockObserver("NASDAQ", 10));
        exchange.Observe(new PriceDropStockObserver("DOW", 100));
    }
}