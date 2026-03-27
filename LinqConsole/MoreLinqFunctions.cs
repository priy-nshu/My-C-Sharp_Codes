using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

    internal class MoreLinqFunctions
    {
    public void Aggregation()
    {
        Student std = new Student();
        List<Student> students = std.GetStudents();
        bool areaAllStudentsTeenager = students.All(s => s.Age >12 && s.Age < 20);
        //if true then all the teenagers and display
        if (areaAllStudentsTeenager) {
            var teenAgeStudent = students.Where(s => s.Age > 12 && s.Age < 20).ToList();
            foreach (Student student in teenAgeStudent) { 
                Console.Write(student.Name+" ");
            }
            Console.WriteLine();
        }
    }
    public void StringAggregation()
    {
        IList<String> strList = new List<String>() { "One","Two","Three","Four","Five"};
        var commonSeperatedString = strList.Aggregate((s1, s2) => s1 + "," + s2);
        Console.WriteLine(commonSeperatedString);
    }
    public void intAgg()
    {
        IList<int> intList = new List<int>() {10,20,30,45,50,87};
        var largest = intList.Max();
        Console.WriteLine("largest element: "+largest);

        var largestEven = intList.Max(i =>
        {
            if (i % 2 == 0)
                return i;
            return 0;
        });
        Console.WriteLine("Largest Even Number is: "+largestEven);
        Console.WriteLine("2nd element in the list: "+intList.ElementAt(0));
        Console.WriteLine("10th Element in the list: " + intList.ElementAtOrDefault(10));

        Console.WriteLine("\nFirst Function:- Even element in the list: " + intList.First(i=>i%2==0));
        Console.WriteLine("First Function:- 5th Element in the list: " + intList.FirstOrDefault(i=>i%27==0));

        Console.WriteLine("\nSingle Function:- Even element in the list: " + intList.Single(i => i % 2 == 0));

    }

    //Data Source
    List<int> numbers =new List<int>() { 1,2,3,4,5,6,7,8,9,10};
    List<string> Collection1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };
    List<string> Collections2 = new List<string>() { "Five", "Three", "Six", "One", "Six" };

    public void SetOperator()
    {
        //Distinct List
        IEnumerable<string> dList = Collection1.Distinct();
        Console.WriteLine("\nDistinct List:");
        foreach(string d in dList) Console.WriteLine(d);

        //Except List
        dList=Collection1.Except(Collections2).ToList();
        Console.WriteLine("\nExcept List:");
        foreach (var d in dList) Console.WriteLine(d);

        //Intersect List
        dList=Collection1.Intersect(Collections2).ToList();
        Console.WriteLine("\nIntersect List:");
        foreach (var d in dList) Console.WriteLine(d);
        
        //Union List
        dList = Collection1.Union(Collections2).ToList();
        Console.WriteLine("\nUnion List:");
        foreach (var d in dList) Console.WriteLine(d);
       
    }

    public void SkipFunctions()
    {
        Console.WriteLine("Original List");
        foreach(var num in numbers) Console.Write(num+" ");

        //Skip top 2
        List<int> sList= numbers.Skip(2).ToList();
        Console.WriteLine("\nAfter Skipping 2");
        foreach (int i in sList) Console.WriteLine($"{i} ");

        sList= numbers.Skip(2).Take(5).ToList();
        Console.WriteLine("\nList after Skipping 2 and taking next 4");
        foreach (int i in sList) Console.WriteLine($"{i} ");

        Console.WriteLine("\nSkip While");
        IEnumerable<int> result=numbers.SkipWhile(x => x < 5);
        foreach (int i in result) Console.WriteLine($"{i} ");

    }
}

