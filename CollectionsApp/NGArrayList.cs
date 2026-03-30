using System;
using System.Collections;

    internal class NGArrayList
    {
    public void AcceptandPrint()
    {
        ArrayList arr1 = new ArrayList();
        arr1.Add(101);
        arr1.Add("James");
        arr1.Add("James");
        arr1.Add(" ");
        arr1.Add(true);
        arr1.Add(4.5);
        arr1.Add(null);
        foreach (var item in arr1)
        {
            Console.WriteLine(item);
        }

        //Addingobjects to the arraylist using objects initializar syntax

        var arr2 = new ArrayList()
        {
            102,"Smith","Smith",true,15.6
        };
        foreach(var item in arr2)
        {
            Console.WriteLine(item);
        }

        //Accessing individual elments from ArrayLIST   using Indexer

        int firstElement=(int)arr1 [0];
        string secondElement=(string)arr1 [1];

        //Update Elements
        arr1[0] = "Smith";
        arr1[1] = "1010";
        //arr1[5]=500; //Indexout of range

        foreach(var item in arr1)
        {
            Console.WriteLine($"{item} "); 
        }

        //using For Loop

        for(int i = 0; i < arr1.Count; i++)
        {
            Console.WriteLine($"{arr1[i]} ");
        }

        ArrayList arr3 = new ArrayList() { 100, 200, 600 };
        ArrayList arr4 = new ArrayList() { 300, 400, 500 };

        arr3.InsertRange(2,arr4);
        foreach(var item in arr3)
        {
            Console.WriteLine(item);
        }

        arr3.Remove(null);
        arr3.RemoveAt(4);
        arr3.RemoveRange(0, 2);//removes 2 items staring from index 0

        Console.WriteLine(arr3.Contains(300));
        Console.WriteLine(arr2.Contains("Bill"));
        Console.WriteLine(arr3.Contains(10));
        Console.WriteLine(arr1.Contains("Steve"));

        arr1.Capacity = 123;

    Console.WriteLine($"Capacity: {arr1.Capacity}");
        Console.WriteLine($"IsFixed Size: {arr1.IsFixedSize}");
        Console.WriteLine("{0,6}", arr1.IndexOf(400));
        arr1.TrimToSize();
        Console.WriteLine($"Trimmed Size:{arr1.Capacity}");
        Console.WriteLine($"Trimmed Count:{arr1.Count}");   
        arr1.Clear();
        Console.WriteLine($"Number of elements: {arr1.Count}");
    }

 }

