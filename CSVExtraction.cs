using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq.Expressions;

class Extraction
{
    public static List<string> CSVExtraction()
    {
        string filePath =
        @".\Transactions2014.csv";
        StreamReader reader = null;
        {
            reader = new StreamReader(File.OpenRead(filePath));
            List<string> transactions2014List = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                transactions2014List.Add(line);
            }
            return transactions2014List;
        }
    }
    

    public static DateOnly formatDate(string stringDate)
    {
        DateOnly formattedDate = DateOnly.ParseExact
        (
            stringDate,
            "dd/MM/yyyy",
            CultureInfo.GetCultureInfo("en-GB")
        );
        return formattedDate;
    }

    public static List<Transaction> MakeTransactionListObjects(List<string> transactions2014List)
    {
        List<Transaction> transactionsList = [];

            for (var count = 1; count < transactions2014List.Count; count++)
            {
                string transactionRawString = transactions2014List[count];
                string[] transactionElements = transactionRawString.Split(','); 
                {
                    Transaction transaction = new Transaction(
                        formatDate(transactionElements[0]),
                        transactionElements[1],
                        transactionElements[2],
                        transactionElements[3],
                        MoneyMath.MoneyStringToInt(transactionElements[4])
                    );

                    transactionsList.Add(transaction);
                }
            }

        return transactionsList;
    }
}

