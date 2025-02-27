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