
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

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
                usersDictionary = User.addNewUserToDictionary(name: transaction.PaidFrom, usersDictionary);
            usersDictionary = User.addTransactionToUser(name: transaction.PaidFrom, usersDictionary, transaction);

            if (!User.isExistingUser(transaction.PaidTo, usersDictionary))
                usersDictionary = User.addNewUserToDictionary(name: transaction.PaidTo, usersDictionary);
            usersDictionary = User.addTransactionToUser(name: transaction.PaidTo, usersDictionary, transaction);
        }

        Welcome();

        while (true)
        {
            mainProgramCall(usersDictionary);
        }
    }

    public static void Welcome()
    {
        Console.WriteLine("Welcome to the Support Bank");
    }

    public static int getMenuOption()
    {
        Console.WriteLine("\nEnter a number to pick an option:");
        Console.WriteLine("Option 1: Print ALL users and transactions");
        Console.WriteLine("Option 2: View transactions for a single user");
        bool isValidInput = int.TryParse(Console.ReadLine(), out int option);
        if (isValidInput)
            return option;
        else
            return getMenuOption();
    }

    public static void ListAllForAllUsers(Dictionary<string, User> usersDictionary)
    {
        foreach (KeyValuePair<string, User> kvp in usersDictionary)
        {
            User.listEverythingForAUser(user: kvp.Value);
        }
    }

    public static void listUserNames(Dictionary<string, User> usersDictionary)
    {
        foreach (KeyValuePair<string, User> kvp in usersDictionary)
        {
            Console.WriteLine(kvp.Key);
        }
    }

    public static void mainProgramCall(Dictionary<string, User> usersDictionary)
    {
        int option = getMenuOption();
        if (option == 1)
        {
            foreach (KeyValuePair<string, User> kvp in usersDictionary)
                User.listEverythingForAUser(kvp.Value);
        }
        else if (option == 2)
        {
            listUserNames(usersDictionary);
            Console.WriteLine("Enter the user's name: ");
            string name = Console.ReadLine()!;
            if (User.isExistingUser(name, usersDictionary))
            {
                User.listEverythingForAUser(usersDictionary[name]);
            }
            else
                Console.WriteLine("Invalid name.");
        }
    }
}
       