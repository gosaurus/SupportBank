public class Transaction
{
    public DateOnly TransactionDate { get; }
    public string PaidFrom { get; }
    public string PaidTo { get; }
    public string Narrative { get; }
    public int AmountInPence { get; }

    public Transaction(
        DateOnly transactionDate,
        string paidFrom,
        string paidTo,
        string narrative,
        int amountInPence
    )
    {
        TransactionDate = transactionDate;
        PaidFrom = paidFrom;
        PaidTo = paidTo;
        Narrative = narrative;
        AmountInPence = amountInPence;
    }

    public override string ToString()
    {
        return "Transaction Date: " + TransactionDate + " Narrative: " + Narrative + " Amount: " + AmountInPence;
    }
}