using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public class Program
{
    public void Main()
    {
        var processor = new CreditCardTransactionProcessor();
        processor.AddValidator(new ValidateBillingAddress());

        processor.Process(new CreditCardTransaction());
    }
}

public class CreditCardTransactionProcessor
{
    private List<ICreditCardTransactionValidator> Validators { get; set; } = new List<ICreditCardTransactionValidator>();

    public void AddValidator(ICreditCardTransactionValidator v)
    {
        Validators.Add(v);
    }

    public void Process(CreditCardTransaction t)
    {
        if (!Validate(t)) throw new ArgumentException("Could not validate transaction");
        // processing code;;;
    }

	public bool Validate(CreditCardTransaction t)
	{
        foreach(ICreditCardTransactionValidator validator in Validators)
        {
            if (!validator.Validate(t)) return false;
        }

        return true;
	}
}

public class CreditCardTransaction
{
    public decimal TransactionAmount { get; set; }
}

public interface ICreditCardTransactionValidator
{
    bool Validate(CreditCardTransaction t);
}

public class ValidateCCBalance : ICreditCardTransactionValidator
{
    public bool Validate(CreditCardTransaction t)
    {
        var card; // lookup credit card
        return t.TransactionAmount <= card.AvailableBalance;
    }
}

public class ValidateBillingAddress : ICreditCardTransactionValidator
{
    public bool Validate(CreditCardTransaction t)
    {
        var card; // lookup credit card
        return t.BillingAddress == card.BillingAddress;
    }
}
