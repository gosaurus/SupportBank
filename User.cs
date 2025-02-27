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

    
   
    // Methods for user
    // public List<Transaction> TransactionsPaidFrom = new List<Transaction>();

    public void getTransactionsPaidFrom(List<Transaction> transactionsList)
    {
        Console.WriteLine($"All transactions paid FROM {this.Name}");
        var filteredTransactions = from transaction in transactionsList where transaction.PaidFrom == this.Name select transaction;
        foreach(var transaction in filteredTransactions)
        {
            Console.WriteLine(transaction);
        }
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
    // pass in transactions list, User.name
    // from transactions in transactionsList
    // where transactison.PaidFrom == this.name

    // public List<Transaction> TransactionPaidTo = new List<Transaction>(); 

}



// // method - how much money they owe/are owed
//  //private properties, using shorthand getters
//     public string teamName { get; }
//     public string? HomeCourse { get; }
//     public List<Member>? Members = new List<Member>(); //https://stackoverflow.com/questions/4462921/how-to-create-a-property-for-a-listt
//     public int? MemberCount { get; } 

//     //constructor
//     public Team(string teamname, string homeCourse, List<Member> members)
//     {
//         teamName = teamname;
//         HomeCourse = homeCourse;
//         Members = members;
//         MemberCount= members.Count;
//     }