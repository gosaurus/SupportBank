public class MoneyMath 
{
    public static int MoneyStringToInt(string poundsDisplayed)
    {
        // try 
        // {
            int number = int.Parse(poundsDisplayed.Replace(".", ""));
            int pence = number * 10;
            return pence;
        // }
        // catch(Exception e)
        // {
        //     Console.WriteLine($"{e}Pounds to pence conversion failed");
        // }
    
       
    }
}


