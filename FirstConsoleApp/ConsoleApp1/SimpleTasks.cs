using System;

public class SimpleTasks
{
    public void Reader()
    {
        string userInput;
        int intVal;
        double doubleVal;
        Console.Write("Enter an interger value: ");
        userInput = Console.ReadLine();
        intVal = Convert.ToInt32(userInput);
        Console.Write("Enter an double value:");
        userInput = Console.ReadLine();
        doubleVal = Convert.ToDouble(userInput);
        Console.WriteLine($"The Interger Value is: {intVal} and Double Value is: {doubleVal}");
    }
    public void FindGreatest()
    {
        int n1, n2, n3;
        Console.WriteLine("Enter 1st Interger");
        n1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter 2nd Interger");
        n2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter 3rd Integer");
        n3 = Convert.ToInt32(Console.ReadLine());
        if (n1 > n2)
        {
            if (n1 > n3)
            {
                Console.WriteLine("N1 is greatest");
            }
            else
            {
                Console.WriteLine("N3 is greatest");
            }
        }
        else
        {
            if (n2 < n3)
            {
                Console.WriteLine("N3 is greatest");
            }
            else
            {
                Console.WriteLine("N2 is greatest");
            }

        }
    }
    public void First10Primes()
    {
        int count = 0, ctr = 0;
        for (int i = 2; ; i++)
        {
            bool isPrime = true;
            for (int j = 2; j < i / 2; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.Write(i + " ");
                ctr++;
            }
            if (ctr == 10)
            {
                break;
            }
        }
    }

    public static void Sum(ref int G)
    {
        //G = 80;
        G += G;
    }

}
