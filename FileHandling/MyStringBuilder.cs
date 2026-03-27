using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class myStringBuilder
{
    public static void SimpleMethods()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append("World");
        sb.Append(1011);
        sb.Append(DateTime.Now);
        Console.WriteLine($"Length: {sb.Length}, {sb}");

        StringBuilder sb1 = new StringBuilder();
        sb1.Append("Welcome to");
        sb1.Append("C#");
        Console.WriteLine(sb1);

        sb1.Insert(11, "the Beautiful World of ");
        Console.WriteLine(sb1);

        sb1.Remove(11, 14);
        Console.WriteLine($"Length: {sb1.Length}, Capacity:{sb1.Capacity} = {sb1}");

        sb1.Replace('o', 'a');
        Console.WriteLine(sb1);
    }

    public static void MoreSBMethods()
    {
        Console.WriteLine("Enter a multi word string");
        string str = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        sb.Append(str);

        for (int i = 0, j = str.Length; i < j; i++, j--)
        {
            char temp = sb[i];
            sb[i] = sb[j];
            sb[j] = temp;
        }
        Console.WriteLine("reverse of string is: " + sb);
        Console.WriteLine($"Capacity of sb is : {sb.Capacity}, Length is {sb.Length}");

        sb.Clear();

        Console.WriteLine($"Capacity of sb is : {sb.Capacity}, Length is {sb.Length}");

        StringBuilder sb2 = new StringBuilder("She sells sea shells on the sea shore");
        Console.WriteLine(sb2);

        sb2.Replace("sh", "h");
        Console.WriteLine(sb2);

        sb2.Replace("sh", "", 0, 5);
        Console.WriteLine(sb2);
    }
}
