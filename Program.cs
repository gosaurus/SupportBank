class Program
{
    public static void Main()
    {
        // extract raw data from csv file
        var rawTransactionsList = Extraction.CSVExtraction();

        // create transaction instances
        var transactionsList = Extraction.MakeTransactionListObjects(rawTransactionsList);

        foreach (var transaction in transactionsList) {
            Console.WriteLine(transaction);
        }

    }
}