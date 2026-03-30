using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void MyDelegate1(String msg);
public delegate int MyIntDelegate();


public class ClassA1
{
    public static void MethodA(String message)
    {
        Console.WriteLine(message);
    }
    public static int MethodC()
    {
        return 100;
    }
}
public class ClassB1
{
    public static void MethodB(String message) { Console.WriteLine(message); }
    public static int MethodD() { return 200; }
}

public class MultiCastDelegate
{
    public void AcceptandPrint()
    {
        MyDelegate1 del1 = ClassA1.MethodA;
        MyDelegate1 del2=ClassB1.MethodB;

        MyDelegate1 del = del1 + del2;
        Console.Clear();

        del("Hello World");
        MyDelegate1 del3=(string msg) => { Console.WriteLine("Called Lambda: "+msg); };
        del += del3;
        del("Hello World");
        del -= del1 - del2; //removes del 2
        del -= del1;//removes del1

        MyIntDelegate del4 = ClassA1.MethodC;
        MyIntDelegate del5 = ClassB1.MethodD;

        MyIntDelegate Multi = del4 + del5;
        Console.WriteLine(Multi);

    }
}