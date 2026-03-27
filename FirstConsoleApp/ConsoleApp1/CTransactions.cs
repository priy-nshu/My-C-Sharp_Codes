using System;

    public abstract class AbstractTransactions
    {
    public AbstractTransactions()
    {
        CustID=string.Empty;
        Console.WriteLine("Base Class Constructor call");
    }

    public AbstractTransactions(string CustID)
    {
        this.CustID = CustID;
    }

    public string CustID;
    public virtual void showTransaction() //Virtual methods are allowed to have implementation
    {
        Console.WriteLine("Base Class Show Transaction");
    }
    public abstract double getAmount();//Abstract Keyword doesn't allow to have implementation
    }

public class CTransaction : AbstractTransactions
{
    private string tCode, date;
    private double amount;

    public CTransaction() : base()
    {
        tCode = " ";
        date = " ";
        amount = 67;
    }
    public CTransaction(string tCode) : base(tCode)
    {
        this.tCode = tCode;
        this.date = date;
        this.amount = amount;
    }
    public override double getAmount()
    {
        return amount;
    }
    public override void showTransaction()
    {
        base.showTransaction(); //Calling the base class for implementation
        Console.WriteLine("Show transaction Override");
        Console.WriteLine("Amount: {0}", getAmount());
    }

}