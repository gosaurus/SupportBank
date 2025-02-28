
public class User 
{
    public string Name { get; }

    public List<Transaction>? TransactionsPaidTo = [];
    public List<Transaction>? TransactionsPaidFrom = [];

    public User(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return "Unique User: " + Name;
    }

    public static float getTotals(IEnumerable<Transaction> filteredTransactions)
    {
        int totalAmountInPencePaidFrom = 0;
        foreach(var transaction in filteredTransactions)
        {
            totalAmountInPencePaidFrom += transaction.AmountInPence;
        }
        
        return MoneyMath.MoneyIntToFloat(totalAmountInPencePaidFrom);
    }

}
