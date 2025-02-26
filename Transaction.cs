using System.Data.Common;
using System.Reflection;
//using System.Transaction;

public class Transaction
{
    public int Id { get; }
    public DateOnly TransactionDate { get; }
    public string PaidFrom { get; }
    public string PaidTo { get; }
    public string Narrative { get; }
    public int AmountInPence { get; }

    public Transaction(
        int id,
        DateOnly transactionDate,
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