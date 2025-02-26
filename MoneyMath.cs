public class MoneyMath 
{
    public static int MoneyStringToInt(string poundsDisplayed)
    {
            string regexString = @"\d+(\.{1}\d{2})";
            new RegexStringValidator(regexString);

            int number = int.Parse(poundsDisplayed.Replace(".", ""));
            int pence = number * 10;
            return pence;
    
       
    }
}
