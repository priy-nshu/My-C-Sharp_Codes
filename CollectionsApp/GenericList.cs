using System;
using System.Collections.Generic;

internal class GenericList
{
    public void AcceptandPrint()
    {
        List<string> countries=new List<string>();
        countries.Add("India");
        countries.Add("USA");

        List<string> newCountries=new List<string>();
        newCountries.Add("Japan");
        newCountries.Add("UK");

        countries.AddRange(newCountries);
        Console.WriteLine("Accessing the List");
        foreach(var items in countries)
        {
            Console.WriteLine(items); 
        }
        countries.Insert(1, "China");
        Console.WriteLine($"\nIndex of China:{countries.IndexOf("China")}");

        Console.WriteLine("\nAfter Adding China:");
        foreach (var items in countries)
        {
            Console.WriteLine(items);
        }
        Console.WriteLine();
        List<string> newCountries2 = new List<string>() { "Sri-Lanka","MALDIVES"};
        countries.InsertRange(2, newCountries2);
        foreach(var items in countries)
        {
            Console.WriteLine(items); 
        }

        Console.WriteLine("\n is India Exists in List: "+countries.Contains("India"));
        Console.WriteLine("Is NZ Exists in List: " + countries.Contains("NZ"));

        Console.WriteLine($"\nRemoving Srilanka: {countries.Remove("Srilanka")}");
        Console.WriteLine("\nAfter removing Srilanka");
        Console.WriteLine($"element count: {countries.Count}    ");

        countries.RemoveAt(2);
        Console.WriteLine($"After removing 2 count:{countries.Count}");

        countries.RemoveRange(0, 2);
        Console.WriteLine($"Count After range function:{countries.Count}") ;
        countries.Clear();

    }

    public void MoreListFunctions()
    {
        string[] cities = new string[] { "Mumbai", "London", "New York" };
        var popularCities = new List<string>();
        popularCities.AddRange(cities);
        Console.WriteLine("\n Accessing List");
        foreach (var c in cities)
        {
            Console.WriteLine(c);
        }
        var favouratieCities = new List<string>();
        favouratieCities.AddRange(popularCities);
        favouratieCities.Sort();

        Console.WriteLine("Accessing after addrange and sort\n");
        foreach(var c in favouratieCities)
        {
            Console.WriteLine(c); 
        }
    }
}

