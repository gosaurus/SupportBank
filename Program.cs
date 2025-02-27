using System.Runtime.CompilerServices;

class Program
{
    public static void Main()
    {

        var rawTransactionsList = Extraction.CSVExtraction();

        var transactionsList = Extraction.MakeTransactionListObjects(rawTransactionsList);

        List<string> UniqueUserList = [];
        
        foreach(var transaction in transactionsList)
        {
            if (!UniqueUserList.Contains(transaction.PaidFrom))
            {
                UniqueUserList.Add(transaction.PaidFrom);
            }
            if (!UniqueUserList.Contains(transaction.PaidTo))
            {
                UniqueUserList.Add(transaction.PaidTo);
            }
        }  

        List<User> AllUsersList = [];

        foreach(var uniqueUser in UniqueUserList)
        {
            var user = new User(uniqueUser);

            AllUsersList.Add(user);
            Console.WriteLine(user);
        }

    }
}