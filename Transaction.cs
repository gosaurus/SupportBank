using System.Data.Common;
using System.Reflection;
//using System.Transaction;

public class Transaction
{
    public int Id { get; }
    public string TransactionDate { get; }
    public string PaidFrom { get; }
    public string PaidTo { get; }
    public string Narrative { get; }
    public int AmountInPence { get; }

    public Transaction(
        int id,
        string transactionDate,
        string paidFrom,
        string paidTo,
        string narrative,
        int amountInPence
    )
    {
        Id = id;
        TransactionDate = transactionDate;
        PaidFrom = paidFrom;
        PaidTo = paidTo;
        Narrative = narrative;
        AmountInPence = amountInPence;

    }

    public override string ToString()
    {
        return "Transaction id: " + Id + " Date: " + TransactionDate + " Narrative: " + Narrative + " Amount: " + AmountInPence;
    }
}
// class Person
// {
//     public string Name { get; set; }
//     public int Age { get; set; }

//     public override string ToString()
//     {
//         return "Person: " + Name + " " + Age;
//     }
// }

// public class Dog
// {
// //properties below
// public string Name { get; }
// public int Age { get; }
// //constructor below
// public Dog(string name)
// {
// Name = name;
// Age = 0;
// }
// //(object) method below
// public void Bark()
// {
// Console.WriteLine("Woof");
// }
// }

// Dog osha = new Dog("Osha");
// osha.Bark();
// var ageOfOsha = osha.Age;
