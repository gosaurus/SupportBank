using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

class Extraction
{
    public static void CSVExtraction()
    {
        string filePath =
        @".\Transactions2014.csv";
        StreamReader reader = null;
        if (File.Exists(filePath))
        {
            reader = new StreamReader(File.OpenRead(filePath));
            List<string> transactions2014List = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                transactions2014List.Add(line);
            }
            for (var count = 1; count < 5; count++)
            {
                string transactionRawString = transactions2014List[count];
                Console.WriteLine(transactionRawString, transactions2014List[count]);
                string[] transactionElements = transactionRawString.Split(','); 
                {
                    Transaction transaction = new Transaction(count,
                    transactionElements[0],
                    transactionElements[1],
                    transactionElements[2],
                    transactionElements[3],
                    MoneyMath.MoneyStringToInt(transactionElements[4]));

                    Console.WriteLine(transaction);


                }
            }
        }
        else 
        {
            Console.WriteLine("File doesn't exist");
        }
    Console.ReadLine();
    }

}

