using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class InvalidStudentNameException : Exception
{
    public InvalidStudentNameException() { }

    public InvalidStudentNameException(string name) : base(String.Format("Invalid Student Name: {0}", name))
    {
        //We use this to Log anything to our database
    }

    public InvalidStudentNameException(Student std) : base(String.Format("Invalid Student Name: {0}", std.StudentName))
    {
        //We use this to Log anything to our database
    }
}
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }

public class Exceptions
{
    public void TryBlock()
    {
        try
        {
            Student student = new Student();
            //student.StudentName = "Priyanshu";
            //student.StudentName = "Tanmay007";

            Validate(student);
        }
        catch (InvalidStudentNameException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(Exception e) {
            Console.WriteLine("Error:- {0}", e.Message);
            }
        Console.ReadKey();
    }

    private void Validate(Student studentName)
    {
        Regex regex = new Regex("^[a-zA-Z]+$");
        if (!regex.IsMatch(studentName.StudentName))
        {
            throw new InvalidStudentNameException(studentName.StudentName);
        }
        else
        {
            Console.WriteLine(studentName.StudentName);
        }
    }

}

