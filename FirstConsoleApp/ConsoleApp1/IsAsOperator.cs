using System;

class Class1 { }
class Class2 { }

public class Test
{
    public void isTest(object obj)
    {
        Class1 c1;
        Class2 c2;
        if (obj is Class1)
        {
            Console.WriteLine("{0} is of Class1", obj);
            c1 = (Class1)obj;
        }
        else if (obj is Class2)
        {
            Console.WriteLine($"{obj} is of Class2");
            c2 = obj as Class2;
        }
        else
        {
            Console.WriteLine($"{obj} is neither Class1 or Class2");
        }

    }

    public void CallisTest()
    {
        Class1 a = new Class1();
        Class2 b = new Class2();
        isTest(a);
        isTest(b);
        isTest("Random String");
        Console.ReadKey();  //keeps the app running so we can look into it and accepts any key to turn off
    }

    public void AsTest() { }
}
