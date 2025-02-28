using System.Runtime.CompilerServices;

class Program
{
    public static void Main()
    {

        var rawTransactionsList = Extraction.CSVExtraction();

        var transactionsList = Extraction.MakeTransactionListObjects(rawTransactionsList);

        Dictionary<string,List<Transaction>> usersDictionary = 
            new Dictionary<string, List<Transaction>>();


        foreach(var transaction in transactionsList)
        {
            if (!usersDictionary.ContainsKey(transaction.PaidFrom))
            {
                List<Transaction> uniqueUserTransactionList = [];
                usersDictionary.Add(transaction.PaidFrom, uniqueUserTransactionList);
                uniqueUserTransactionList.Add(transaction);
            }
            else if (!usersDictionary.ContainsKey(transaction.PaidTo))
            {
                List<Transaction> uniqueUserTransactionList = [];
                usersDictionary.Add(transaction.PaidTo, uniqueUserTransactionList);
                uniqueUserTransactionList.Add(transaction);
            }
            else
            {
                
                var uniqueUserTransactionList = usersDictionary[transaction.PaidFrom];
                uniqueUserTransactionList.Add(transaction);
            }
        }
    }

    public static bool isExistingUser (
        string name, Dictionary<string,
        List<Transaction>> usersDictionary
    )
    {
        return usersDictionary.ContainsKey(name);
    }
}
        // List<string> UniqueUserList = [];
        
        // foreach(var transaction in transactionsList)
        // {
        //     if (!UniqueUserList.Contains(transaction.PaidFrom))
        //     {
        //         UniqueUserList.Add(transaction.PaidFrom);
        //     }
        //     if (!UniqueUserList.Contains(transaction.PaidTo))
        //     {
        //         UniqueUserList.Add(transaction.PaidTo);
        //     }
        // }  

        // List<User> AllUsersList = [];

        // foreach(var uniqueUser in UniqueUserList)
        // {
        //     var user = new User(uniqueUser);

        //     AllUsersList.Add(user);
        //     Console.WriteLine(user);
        //     user.getTransactionsPaidFrom(transactionsList);
        //     user.getTransactionsPaidTo(transactionsList);
        // }