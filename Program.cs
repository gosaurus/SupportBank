
class Program
{
    public static void Main()
    {
        var rawTransactionsList = Extraction.CSVExtraction();

        var transactionsList = Extraction.MakeTransactionListObjects(rawTransactionsList);
        Dictionary<string, User> usersDictionary = [];

        foreach(var transaction in transactionsList)
        {
            if (!isExistingUser(transaction.PaidFrom, usersDictionary))
            {
                usersDictionary = addNewUserToDictionary(transaction.PaidFrom, usersDictionary);
                usersDictionary[transaction.PaidFrom].TransactionsPaidFrom?.Add(transaction);
            }
            else
            {
                usersDictionary[transaction.PaidFrom].TransactionsPaidFrom?.Add(transaction);
            }
            if (!isExistingUser(transaction.PaidTo, usersDictionary))
            {
                usersDictionary = addNewUserToDictionary(transaction.PaidTo, usersDictionary);
                usersDictionary[transaction.PaidTo].TransactionsPaidTo?.Add(transaction);
            }
            else
            {
                usersDictionary[transaction.PaidTo].TransactionsPaidTo?.Add(transaction);
            }
         
        }

        foreach (KeyValuePair<string, User> kvp in usersDictionary)
        {
            Console.WriteLine(kvp.Key);
            Console.WriteLine("Transactions paidTO: ");
            
            foreach (var transaction in kvp.Value.TransactionsPaidTo)
            {
                Console.WriteLine($"\t {transaction}");
            }
            Console.WriteLine($"\t TOTAL TRANSACTION PAID TO: £{User.getTotals(kvp.Value.TransactionsPaidTo)}");
            Console.WriteLine("Transactions paidFROM: ");
            foreach (var transaction in kvp.Value.TransactionsPaidFrom)
            {
                Console.WriteLine($"\t {transaction}");
            }
            Console.WriteLine($"\t TOTAL TRANSACTION PAID FROM: £{User.getTotals(kvp.Value.TransactionsPaidFrom)}");
        }
        
    }

    public static bool isExistingUser (
        string name, 
        Dictionary<string, User> usersDictionary
    )
    {
        return usersDictionary.ContainsKey(name);
    }

    public static Dictionary<string, User> addNewUserToDictionary (
        string name, 
        Dictionary<string, User> usersDictionary
    )
    {
        var user = new User(name);
        usersDictionary.Add(name, user);
        return usersDictionary;
    }
}
       