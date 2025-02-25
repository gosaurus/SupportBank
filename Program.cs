class Program
{
    public static void Main()
    {
        string filePath =
        @".\Transactions2014.csv";
        StreamReader reader = null;
        if (File.Exists(filePath))
        {
            reader = new StreamReader(File.OpenRead(filePath));
            List<string> listA = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                listA.Add(line);
            }
            foreach (var transaction in listA)
            {
                Console.WriteLine(transaction);
            }
        } 
        else 
        {
            Console.WriteLine("File doesn't exist");
        }
    Console.ReadLine();
    }
}