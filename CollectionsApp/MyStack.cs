using System;
using System.Collections.Generic;

   internal class MyStack
   {
    public void AcceptandPrint()
    {
        Stack<int> myStack = new Stack<int>();
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);

        Console.Write("Number of elements in Stack: {0}", myStack.Count +" Which are: \n");

        while (myStack.Count > 0)
        {
            Console.Write(myStack.Pop() + ",");
        }
        Console.Write("\nNumber of elements in Stack: {0}\n", myStack.Count);

        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);

        if (myStack.Count > 0)
        {
            Console.Write(myStack.Peek());
        }
        Console.Write("\nNumber of elements in Stack: {0}\n", myStack.Count);


        Console.WriteLine(myStack.Contains(2));
        Console.WriteLine(myStack.Contains(10));

        myStack.Clear();
        Console.Write("\nNumber of elements in Stack: {0}\n", myStack.Count);
    }

   }

