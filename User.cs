
using System.Collections;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

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

    public static int getTotals(IEnumerable<Transaction> filteredTransactions)
    {
        int totalAmountInPence = 0;
        foreach(var transaction in filteredTransactions)
        {
            totalAmountInPence += transaction.AmountInPence;
        }
        
        return totalAmountInPence;
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
        List<Transaction> transactionsList
    )
    {
        foreach (var transaction in transactionsList)
        {
            Console.WriteLine($"\t {transaction}");
        }
    }
    public static void listUserPaidToFromTransactions(
        List<Transaction> transactionsList,
        User user,
        string transactionsListName
    )
    {
        if (transactionsList.Count != 0) 
        {
            Console.WriteLine($"Transactions " + transactionsListName);
            Console.WriteLine($"====================");
            printTransactionsForUser(transactionsList);
        
            Console.WriteLine("\nTotal value of transactions " + transactionsListName +
            $" £{MoneyMath.MoneyIntToFloat(getTotals(transactionsList))}\n");
        }
        else 
            Console.WriteLine($"{user.Name} has no transactions paid TO.");

    }

    public static void listEverythingForAUser(
        User user
    )
    {
        Console.WriteLine($"{user.Name}");
        listUserPaidToFromTransactions(
            transactionsList: user.TransactionsPaidTo,
            user: user,
            transactionsListName: "paid TO"
        );
        listUserPaidToFromTransactions(
            transactionsList: user.TransactionsPaidFrom,
            user: user,
            transactionsListName: "paid FROM"
        );
        
        if (userHasTransactions(user))
        {
            int paidFrom = getTotals(user.TransactionsPaidFrom);
            int paidTo = getTotals(user.TransactionsPaidTo);
            if (paidFrom > paidTo)
            {
                int diff = paidFrom - paidTo;
                Console.WriteLine($"{user.Name} is owed £" +
                MoneyMath.MoneyIntToFloat(diff));
            }
            else if (paidTo > paidFrom)
            {
                int diff = paidTo - paidFrom;
                Console.WriteLine($"{user.Name} owes £" +
                MoneyMath.MoneyIntToFloat(diff));
            }
            else
                Console.WriteLine($"Amount paid to {paidTo} and amount paid from {paidFrom} is even.");
        }
    }

    public static bool userHasTransactions(User user)
    {
        if (user.TransactionsPaidFrom.Count > 0 ||
            user.TransactionsPaidTo.Count > 0)
            {
                return true;
            }
        else
            return false; 
    }
}
