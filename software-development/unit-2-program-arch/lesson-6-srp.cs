using System;
using System.Collections.Generic;

public class MarketAnalyzer
{
	public void Main()
    {
        var ta = new TradeAdvisor();
        var at = new AccountingTracker();

        var factors = ta.GetCurrentMarketChangeFactors();
        foreach(var factor in factors)
        {
            ta.ExecuteTrade(factor);
            at.LogTrade(factor);
        }
    }
}

public class MarketChangeFactor
{
    public string Name { get; set; }
    public decimal DollarAmount { get; set; }
    public string TickerSymbol { get; set; }
}

public class TradeAdvisor
{
    public List<MarketChangeFactor> GetCurrentMarketChangeFactors()
    {
    }

    public void ExecuteTrade(MarketChangeFactor factor)
    {
    }
}

public class AccountingTracker
{
    public void LogTrade(MarketChangeFactor factor)
    {
        //add business analyst code
    }
}