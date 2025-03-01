
class Program
{
    public static void Main()
    {
        var rawTransactionsList = Extraction.CSVExtraction();

        var transactionsList = Extraction.MakeTransactionListObjects(rawTransactionsList);
        Dictionary<string, User> usersDictionary = [];

        foreach(var transaction in transactionsList)
        {
            if (!User.isExistingUser(transaction.PaidFrom, usersDictionary))
            {
                usersDictionary = User.addNewUserToDictionary(name: transaction.PaidFrom, usersDictionary);
                usersDictionary = User.addTransactionToUser(name: transaction.PaidFrom, usersDictionary, transaction);
            }
            else
            {
                usersDictionary = User.addTransactionToUser(name: transaction.PaidFrom, usersDictionary, transaction);
            }
            if (!User.isExistingUser(transaction.PaidTo, usersDictionary))
            {
                usersDictionary = User.addNewUserToDictionary(name: transaction.PaidTo, usersDictionary);
                usersDictionary = User.addTransactionToUser(name: transaction.PaidTo, usersDictionary, transaction);
            }
            else
            {
                usersDictionary = User.addTransactionToUser(name: transaction.PaidTo, usersDictionary, transaction);
            }
         
        }

        foreach (KeyValuePair<string, User> kvp in usersDictionary)
        {
            Console.WriteLine($"{kvp.Key}");
            User.ListAll(
                transactionsList: kvp.Value.TransactionsPaidTo,
                user: kvp,
                transactionsListName: "paid TO"
            );
            User.ListAll(
                transactionsList: kvp.Value.TransactionsPaidFrom,
                user: kvp,
                transactionsListName: "paid FROM"
            );
        }
        
    }

    public static void centre(string text)
    {
        int padLeft = (Console.WindowWidth/2) - (text.Length/2);
        Console.WriteLine(text.PadLeft(padLeft));
    }

}
       