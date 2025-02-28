public class MoneyMath 
{
    public static int MoneyStringToInt(string poundsDisplayed)
    {
            float number = float.Parse(poundsDisplayed);
            int pence = (int)(number*100);
            return pence;
    }
    
    // public
    //     float totalAmountInPoundsPaidFrom = (float)(totalAmountInPencePaidFrom)/100;
}

