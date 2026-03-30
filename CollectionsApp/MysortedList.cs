using System;
using System.Collections;


internal class MysortedList
{
    public void SortList()
    {
        SortedList<int, string> numberNames = new SortedList<int, string>();
        numberNames.Add(3, "Three");
        numberNames.Add(1, "One");
        numberNames.Add(10, "Ten");
        numberNames.Add(5, "Five");

        SortedList<string, string> cities = new SortedList<string, string> {
            {"London","UK" },
            {"New York","USA" },
            {"Mumbai","India" },
            {"Johannesburg","South Africa" }
            };
        Console.WriteLine("Initial Key Value");
        foreach (KeyValuePair<int, string> kvp in numberNames)
        {
            Console.WriteLine(kvp.Key + ": " + kvp.Value);
        }
        numberNames.Add(6, "Six");
        numberNames.Add(2, "Two");
        numberNames.Add(4, "Four");

        Console.WriteLine("\nAfter adding new value\n");

        foreach(var kvp in numberNames)
        {
            Console.WriteLine("Key:{0}, value:{1}",kvp.Key,kvp.Value);

        }
        Console.WriteLine();
        Console.WriteLine(numberNames[1]);
        Console.WriteLine(numberNames[2]);
        Console.WriteLine(numberNames[3]);

        if (numberNames.ContainsKey(4))
        {
            numberNames[4] = "Four";
        }
        string result;
        if (numberNames.TryGetValue(4, out result))
        {
            Console.WriteLine("Key:{0},Value:{1}", 4, result);
        }
        Console.WriteLine() ;
        for (int i = 0; i < numberNames.Count; i++)
        {
            Console.WriteLine("key:{0},value:{1}", numberNames.Keys[i], numberNames.Values[i]);
        }

        numberNames.Remove(1);
        numberNames.Remove(10);

        numberNames.RemoveAt(0);

        foreach (var kvp in numberNames)
        {
            Console.WriteLine("Key: {0},value: {1}", kvp.Key, kvp.Value);
        }
    }

}    