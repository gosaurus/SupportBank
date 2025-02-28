using System.Diagnostics.Contracts;
using System.Reflection;
using System.Xml;

public class User 
{
    public string Name { get; }

    public User(string name)
    {
        Name=name;
    }

    public override string ToString()
    {
        return "Unique User: " + Name;
    }

    public void getTransactionsPaidFrom(List<Transaction> transactionsList)
    {
        Console.WriteLine($"All transactions paid FROM {this.Name}");
        var filteredTransactions = from transaction in transactionsList where transaction.PaidFrom == this.Name select transaction;
        foreach(var transaction in filteredTransactions)
        {
            Console.WriteLine(transaction);
        }
        Console.WriteLine(getTotalPaidFrom(filteredTransactions));
    }

    public float getTotalPaidFrom(IEnumerable<Transaction> filteredTransactions)
    {
        int totalAmountInPencePaidFrom = 0;
        foreach(var transaction in filteredTransactions)
        {
            totalAmountInPencePaidFrom += transaction.AmountInPence;
        }
        
        return MoneyMath.MoneyIntToFloat(totalAmountInPencePaidFrom);
    }

    public void getTransactionsPaidTo(List<Transaction> transactionsList)
    {
        Console.WriteLine($"All transactions paid TO {this.Name}");
        var filteredTransactions = from transaction in transactionsList where transaction.PaidTo == this.Name select transaction;
        foreach(var transaction in filteredTransactions)
        {
            Console.WriteLine(transaction);
        }
    }

}
