using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyDelegate
{
    public delegate double AddNumberDelegate(int no1, float no2, double no3);
    public delegate void AddNumber2Delegate(int no1, float no2, double no3);
    public delegate bool CheckLengthDelegate(string name);

    public void AcceptandPrint()
    {
        AddNumberDelegate obj1 = new AddNumberDelegate(AddNumber1);
        double Result = obj1.Invoke(100, 125.45f, 456.789);
        Console.WriteLine(Result);
        AddNumber2Delegate obj2=new AddNumber2Delegate(AddNumber2);
        obj2.Invoke(10, 15.45f, 1456.789);
        CheckLengthDelegate obj3= new CheckLengthDelegate(CheckLength);
        bool Status=obj3.Invoke("Pranaya");
        Console.WriteLine(Status);
         
    }

    public static double AddNumber1(int no1, float no2, double no3)
    {
        return no1 + no2 + no3;
    }

    public static void AddNumber2(int no1, float no2, double no3)
    {
        Console.WriteLine( no1 + no2 + no3);
    }

    public static bool CheckLength(string name)
    {
        if (name.Length > 5)
        {
            return true;
        }
        return false;
    }
}
