using System;
using System.Collections.Generic;

    public class MyQueue
    {
     public void AcceptandPrint()
    {
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Enqueue(40);
        queue.Enqueue(50);

        Console.WriteLine("All Generic Queue Element count: "+ queue.Count);
        foreach(var  item in queue)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"\nDequeued Element: {queue.Dequeue()}\n");

        Console.WriteLine($"All queue elements after dequeue: Count {queue.Count}");
        foreach(var item in queue)
        {
            Console.WriteLine(item); 
        }
        Console.WriteLine($"\nIs Value 40 present in the queue: {queue.Contains(40)}");
        Console.WriteLine($"Is Value 90 present in the queue: {queue.Contains(90)}");

        Queue<int> callerIds= new Queue<int>();
        callerIds.Enqueue(1);
        callerIds.Enqueue(2);
        callerIds.Enqueue(3);
        callerIds.Enqueue(4);

        if(callerIds.Count > 0)
        {
            Console.WriteLine(callerIds.Peek());
            Console.WriteLine(callerIds.Peek());
        }

        if (callerIds.Count > 0 && callerIds.Contains(4))
        {
            Console.WriteLine("CallerId contains 4\n");
        }

        while (callerIds.Count > 0)
        {
            Console.WriteLine(callerIds.Dequeue());
        }
        //Copy the queue to an object array
        int[] queueCopy = new int[5];
        queue.CopyTo(queueCopy, 0); //number of elements in Q has to be '>=' as array size

        Console.WriteLine("\nCopied Queue\n");
        foreach (var items in queueCopy)
        {
            Console.Write(items+" ");
        }
        Console.ReadKey();
    }
    }

