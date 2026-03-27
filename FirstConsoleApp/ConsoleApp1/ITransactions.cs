using System;

    public interface ITransactions
    {
    //string CustID;    //not allowed

    void showTransaction() //some implementation allowed
    {
        Console.WriteLine("Interface Call");
    }

    double getAmount();
    }
    
public class Transaction : ITransactions
{
    private string tCode, date;
    private double amount;

    public Transaction()
    {
        tCode = " ";
        date = " ";
        amount = 0;
    }
    public Transaction(string tCode, string date, double amount) { 
        this.tCode = tCode;
        this.date = date;
        this.amount = amount;
    }
    public double getAmount()
    {
        return amount;
    }

    public void showTransaction()
    {
       // ((ITransactions)this).showTransaction();
        Console.WriteLine("Transaction: {0}", tCode);
        Console.WriteLine("Date: {0}",date);
        Console.WriteLine("Amount: {0}", getAmount());

    }

}