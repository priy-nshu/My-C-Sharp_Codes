using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SystemDelegate
{
    public static int Sum(int x,int y)
    {
        return x + y; 
    }
    public static string Concat(string str1,string str2)
    {
        return str1 + str2; 
    }
    public static bool IsUpperCase(string str)
    {
        return str.Equals(str.ToUpper());
    }
    public void AcceptandPrint()
    {
        Func<int,int,int> add =Sum;
        int result =add(10,10);
        Console.WriteLine(result);

        Func<string, string, string> str = Concat;
        Console.WriteLine(str("Hello"," World"));

        Func<int> getRandomNumber = delegate ()
        {
            Random rmd = new Random();
            return rmd.Next(1, 100);
        };  

        Console.WriteLine($"Random Number is {getRandomNumber()}");

        Predicate<String> preDel =IsUpperCase;
        string str2 = "hello world";
        bool res=preDel(str2);

        Console.WriteLine($"{str2} is in Upper Case: {res}");
    }
}
