using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    internal class HashTableList
    {
    public void AcceptandPrint()
    {
        Hashtable numberNames = new Hashtable();
        numberNames.Add(1, "One");
        numberNames.Add(2, "Two");
        numberNames.Add(3, "Three");

        foreach (DictionaryEntry de in numberNames)
        {
            Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);
        }
        Console.WriteLine();
        Dictionary<int,string> dict= new Dictionary<int,string>();
        dict.Add(1, "one");
        dict.Add(2, "two");
        dict.Add(3, "three");

        Hashtable ht= new Hashtable(dict);
        foreach(DictionaryEntry de in ht)
        {
            Console.WriteLine("Key: {0},Value: {1}",de.Key, de.Value);
        }
        Console.WriteLine() ;

        var cities = new Hashtable()
        {
            { "UK","LN,MAN,BIRM" },
            {"USA","CHI,NY,DC" },
            {"INDIA","MUM,DELHI,Pune" }
        };

        string citiesOfUK = (string)cities["UK"];
        string citiesOfUSA = (string)cities["USA"];

        Console.WriteLine(citiesOfUK);
        Console.WriteLine(citiesOfUSA);

        cities["UK"] = "LIV,BRIS";
        cities["USA"] = "LA,BOS";

        if (!cities.ContainsKey("France"))
        {
            cities["France"] = "Paris";
        }

        cities.Remove("UK");
        cities.Remove("China");

        if (cities.ContainsKey("France"))
            cities.Remove("France");

        cities.Clear();
        Console.WriteLine($"Elements in cities: {cities.Count}");
    }
}
