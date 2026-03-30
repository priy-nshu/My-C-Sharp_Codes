using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class LinqStudent
{
    public void SomeLinq()
    {
        IList<Student> studentList = new List<Student>()
        {
            new Student(){Id = 1,Name="John",Age=18},
            new Student(){Id = 2,Name="Steve",Age =15 },
            new Student(){Id = 3,Name="Bill",Age=25 },
            new Student(){Id = 4,Name="Ram",Age=20 },
            new Student(){Id = 5,Name="Ron",Age=19 }
        };

        Console.WriteLine("Teen Student List\n");
        var teenAgeStudent = studentList.Where(s => s.Age > 12 && s.Age < 20).ToList<Student>();
        foreach (Student student in teenAgeStudent)
        {
            Console.WriteLine($"{student.Name}, {student.Age}"); 
        }

        //Method Syntax
        var studentsInAscOrder = studentList.Where(s => s.Age > 12 && s.Age < 20).OrderBy(s => s.Name); 

        //Query Syntax
        var orderByResult= from s in studentList
                           where s.Age>12 && s.Age < 20
                           orderby s.Name
                           select s;
        Console.WriteLine("\nDescending Order List");
        foreach(Student student in orderByResult) { Console.WriteLine(student.Name+" " +student.Age); }

        var orderByDescendingResult = from s in studentList
                                      orderby s.Name descending
                                      select s;
        Console.WriteLine("\nDescending Order StudentList");
        foreach(Student student in orderByDescendingResult) {
            Console.WriteLine(student.Name + " " + student.Age);
        }
    }

    public void DelayedExecution()
    {
        IList<string> stringList = new List<string>() { "C# Tutorial","VB.Net Tutorial","LearnC++","MVC Tutorial","JAVA"};

        var result = stringList.Where(s => s.Contains("Tutorial"));

        Console.WriteLine("\nDelay\n");
        foreach(var i in result)
        {
            Console.WriteLine(i); 
        }
    }

    public void GroupByExecution()
    {
        IList<Student> studentList = new List<Student>()
        {
            new Student(){Id = 1,Name="John",Age=18},
            new Student(){Id = 2,Name="Steve",Age =25 },
            new Student(){Id = 3,Name="Bill",Age=25 },
            new Student(){Id = 4,Name="Ram",Age=20 },
            new Student(){Id = 5,Name="Ron",Age=18 }
        };

        //Group
        var querySyntax = from s in studentList
                          group s by s.Age;

        Console.WriteLine("\nGroup in queueSyntax---------");
        foreach (var item in querySyntax)
        {
            Console.WriteLine(item.Key+":"+item.Count());
            foreach(Student s in item)
            {
                Console.WriteLine($"Student ID: {s.Id} Student Name: {s.Name}");
            }
            Console.WriteLine();
        }

        //Use method syntax to query for teenager and retrieve only thier name

        var teenAgeStudent = studentList.Where(s => s.Age > 12 && s.Age < 20).Select(s => s.Name).ToList();

        foreach (var item in teenAgeStudent)
        {
            Console.WriteLine(item);
        }
    }
}
