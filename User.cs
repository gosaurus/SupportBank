
using System.ComponentModel.Design;

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

    public static bool isExistingUser(
        string name, 
        Dictionary<string, User> usersDictionary
    )
    {
        return usersDictionary.ContainsKey(name);
    }

    public static Dictionary<string, User> addNewUserToDictionary(
        string name, 
        Dictionary<string, User> usersDictionary
    )
    {
        var user = new User(name);
        usersDictionary.Add(name, user);
        return usersDictionary;
    }

    public static Dictionary<string, User> addTransactionToUser(
        string name,
        Dictionary<string, User> usersDictionary,
        Transaction transaction
    )
    {
        if (name == transaction.PaidFrom)
        {
            usersDictionary[name].TransactionsPaidFrom?.Add(transaction);
        } 
        if (name == transaction.PaidTo)
        {
            usersDictionary[name].TransactionsPaidTo?.Add(transaction);
        } 

        return usersDictionary;
    }

    public static void printTransactionsForUser(
        List<Transaction> transactionsList,
        KeyValuePair<string, User> kvp
    )
    {
        foreach (var transaction in transactionsList)
        {
            Console.WriteLine($"\t {transaction}");
        }
    }
    public static void ListAll(
        List<Transaction> transactionsList,
        KeyValuePair<string, User> user,
        string transactionsListName
    )
    {
        if (transactionsList.Count != 0) 
        {
            Console.WriteLine($"Transactions " + transactionsListName);
            Console.WriteLine($"====================");
            printTransactionsForUser(transactionsList, user);
            Console.WriteLine($"\nTotal value of transactions {transactionsListName} " +
            $"£{getTotals(transactionsList)}\n");
        }
        else 
            Console.WriteLine($"{user.Key} has no transactions paid TO.");
    }
}
