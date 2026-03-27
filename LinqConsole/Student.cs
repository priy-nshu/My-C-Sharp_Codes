using System;
using System.Collections.Generic;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int StandardID { get; set; }

    public List<Student> GetStudents()
    {
        return new List<Student>()
        {
            new Student() { Id = 1, Name = "A", Age = 18, StandardID = 2 },
            new Student() { Id = 2, Name = "B", Age = 18, StandardID = 3 },
            new Student() { Id = 3, Name = "C", Age = 16, StandardID = 4 },
            new Student() { Id = 4, Name = "D", Age = 15, StandardID = 5 },
            new Student() { Id = 5, Name = "E", Age = 15, StandardID = 6 },
            new Student() { Id = 6, Name = "F", Age = 14, StandardID = 7 },
            new Student() { Id = 7, Name = "G", Age = 18, StandardID = 8 },
            new Student() { Id = 8, Name = "I", Age = 17, StandardID = 9 },
        };
    }
}

