using System;

public class StringFunctions
{
    public void AcceptandPrint()
    {
        string str1 = "C# Programming";
        string str2 = "C# Programming";
        string str3 = "ProgrammingWhiz";

        //Compare str1 and str2
        Boolean result1 = false;
        if (str1 == str2) { result1 = true; }
        Console.WriteLine("string str1 and str2 are equal: " + result1);

        //compare str1 and str3
        Boolean result2 = str1.Equals(str3);
        Console.WriteLine("String str1 and str3 are equal: " + result2);

        //join two string
    }

    public void MoreStringFunctions()
    {
        string[] sArray = { "Hello", "From", "DotNet", "World" };
        string message = string.Join(" ", sArray);
        Console.WriteLine("Message: {0}", message);

        string[] sArray2 = new string[] { "Down the way nights are dark" };
        String[] str5 = new String[6];
        Console.WriteLine("Split strings are :");
        str5 = sArray2[0].Split(' ');
        for (int i = 0; i < str5.Length; i++)
        {
            Console.WriteLine(str5[i]);
        }
    }
}