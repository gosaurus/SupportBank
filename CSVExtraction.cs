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
            // foreach (var transactionRawString in transactions2014List)
            // {
            //     transactionRawString.Split(',');
            //     Transactions.Transaction(transactionRawString);

            //     var values = line.Split(',');
            // }
            for (var count = 1; count < 5; count++)
            {
                int id = count;
                string transactionRawString = transactions2014List[count];
                Console.WriteLine(transactionRawString, transactions2014List[count]);
                string[] splitString = transactionRawString.Split(','); 
                foreach (var element in splitString) //why do we need to do foreach and console.writeline(element) to see each thing in splitString
                {
                    Console.WriteLine(element);
                }
                // Transactions.Transaction(id,transactionSplitString);
            }
        }
        else 
        {
            Console.WriteLine("File doesn't exist");
        }
    Console.ReadLine();
    }


}

